using Classification.Parameter;
using Classification.Performance;
using Math;

namespace Classification.Model;

public class DeepNetworkModel : NeuralNetworkModel
{
	private readonly ActivationFunction activationFunction;
	private int hiddenLayerSize;
	private List<Matrix> weights;

	/**
	 * <summary>
	 *   Constructor that takes two {@link InstanceList} train set and validation set and {@link DeepNetworkParameter} as
	 *   inputs.
	 *   First it sets the class labels, their sizes as K and the size of the continuous attributes as d of given train set
	 *   and
	 *   allocates weights and sets the best weights. At each epoch, it shuffles the train set and loops through the each item
	 *   of that train set,
	 *   it multiplies the weights Matrix with input Vector than applies the sigmoid function and stores the result as hidden
	 *   and add bias.
	 *   Then updates weights and at the end it compares the performance of these weights with validation set. It updates the
	 *   bestClassificationPerformance and
	 *   bestWeights according to the current situation. At the end it updates the learning rate via etaDecrease value and
	 *   finishes
	 *   with clearing the weights.
	 * </summary>
	 * <param name="trainSet">     {@link InstanceList} to be used as trainSet.</param>
	 * <param name="validationSet">{@link InstanceList} to be used as validationSet.</param>
	 * <param name="parameters">   {@link DeepNetworkParameter} input.</param>
	 */
	public DeepNetworkModel(InstanceList.InstanceList trainSet,
		InstanceList.InstanceList validationSet, DeepNetworkParameter parameters) : base(trainSet)
	{
		var deltaWeights = new List<Matrix>();
		var hidden = new List<Vector>();
		var hiddenBiased = new List<Vector>();
		activationFunction = parameters.GetActivationFunction();
		AllocateWeights(parameters);
		var bestWeights = SetBestWeights();
		var bestClassificationPerformance = new ClassificationPerformance(0.0);
		var epoch = parameters.GetEpoch();
		var learningRate = parameters.GetLearningRate();
		Vector tmph;
		var tmpHidden = new Vector(1, 0.0);
		var activationDerivative = new Vector(1, 0.0);
		for (var i = 0; i < epoch; i++)
		{
			trainSet.Shuffle(parameters.GetSeed());
			for (var j = 0; j < trainSet.Size(); j++)
			{
				CreateInputVector(trainSet.Get(j));
				hidden.Clear();
				hiddenBiased.Clear();
				deltaWeights.Clear();
				for (var k = 0; k < hiddenLayerSize; k++)
				{
					if (k == 0)
						hidden.Add(CalculateHidden(x, weights[k], activationFunction));
					else
						hidden.Add(CalculateHidden(hiddenBiased[k - 1], weights[k], activationFunction));
					hiddenBiased.Add(hidden[k].Biased());
				}
				var rMinusY = CalculateRMinusY(trainSet.Get(j), hiddenBiased[hiddenLayerSize - 1],
					weights[weights.Count - 1]);
				deltaWeights.Insert(0, rMinusY.Multiply(hiddenBiased[hiddenLayerSize - 1]));
				for (var k = weights.Count - 2; k >= 0; k--)
				{
					if (k == weights.Count - 2)
						tmph = weights[k + 1].MultiplyWithVectorFromLeft(rMinusY);
					else
						tmph = weights[k + 1].MultiplyWithVectorFromLeft(tmpHidden);
					tmph.Remove(0);
					switch (activationFunction)
					{
					case ActivationFunction.Sigmoid:
						var oneMinusHidden = CalculateOneMinusHidden(hidden[k]);
						activationDerivative = oneMinusHidden.ElementProduct(hidden[k]);
						break;
					case ActivationFunction.Tanh:
						var one = new Vector(hidden.Count, 1.0);
						hidden[k].Tanh();
						activationDerivative = one.Difference(hidden[k].ElementProduct(hidden[k]));
						break;
					case ActivationFunction.Relu:
						hidden[k].ReluDerivative();
						activationDerivative = hidden[k];
						break;
					}
					tmpHidden = tmph.ElementProduct(activationDerivative);
					if (k == 0)
						deltaWeights.Insert(0, tmpHidden.Multiply(x));
					else
						deltaWeights.Insert(0, tmpHidden.Multiply(hiddenBiased[k - 1]));
				}
				for (var k = 0; k < weights.Count; k++)
				{
					deltaWeights[k].MultiplyWithConstant(learningRate);
					weights[k].Add(deltaWeights[k]);
				}
			}
			var currentClassificationPerformance = TestClassifier(validationSet);
			if (currentClassificationPerformance.GetAccuracy() >
				bestClassificationPerformance.GetAccuracy())
			{
				bestClassificationPerformance = currentClassificationPerformance;
				bestWeights = SetBestWeights();
			}
			learningRate *= parameters.GetEtaDecrease();
		}
		weights.Clear();
		foreach (var m in bestWeights)
			weights.Add(m);
	}

	/**
	 * <summary>
	 *   The allocateWeights method takes {@link DeepNetworkParameter}s as an input. First it adds random weights to the
	 *   {@link List}
	 *   of {@link Matrix} weights' first layer. Then it loops through the layers and adds random weights till the last layer.
	 *   At the end it adds random weights to the last layer and also sets the hiddenLayerSize value.
	 * </summary>
	 * <param name="parameters">{@link DeepNetworkParameter} input.</param>
	 */
	private void AllocateWeights(DeepNetworkParameter parameters)
	{
		weights = new List<Matrix>
		{
			AllocateLayerWeights(parameters.GetHiddenNodes(0), d + 1,
				new Random(parameters.GetSeed()))
		};
		for (var i = 0; i < parameters.LayerSize() - 1; i++)
			weights.Add(AllocateLayerWeights(parameters.GetHiddenNodes(i + 1),
				parameters.GetHiddenNodes(i) + 1, new Random(parameters.GetSeed())));
		weights.Add(AllocateLayerWeights(K,
			parameters.GetHiddenNodes(parameters.LayerSize() - 1) + 1,
			new Random(parameters.GetSeed())));
		hiddenLayerSize = parameters.LayerSize();
	}

	/**
	 * <summary>
	 *   The setBestWeights method creates an {@link List} of Matrix as bestWeights and clones the values of weights {@link
	 *   List}
	 *   into this newly created {@link List}.
	 * </summary>
	 * <returns>An {@link List} clones from the weights List.</returns>
	 */
	private List<Matrix> SetBestWeights()
	{
		var bestWeights = new List<Matrix>();
		foreach (var m in weights)
			bestWeights.Add((Matrix) m.Clone());
		return bestWeights;
	}

	/**
	 * <summary>
	 *   The calculateOutput method loops size of the weights times and calculate one hidden layer at a time and adds bias
	 *   term.
	 *   At the end it updates the output y value.
	 * </summary>
	 */
	protected override void CalculateOutput()
	{
		Vector hiddenBiased = null;
		for (var i = 0; i < weights.Count - 1; i++)
		{
			Vector hidden;
			if (i == 0)
				hidden = CalculateHidden(x, weights[i], activationFunction);
			else
				hidden = CalculateHidden(hiddenBiased, weights[i], activationFunction);
			hiddenBiased = hidden.Biased();
		}
		y = weights[weights.Count - 1].MultiplyWithVectorFromRight(hiddenBiased);
	}
}