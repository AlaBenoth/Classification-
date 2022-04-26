using Classification.Parameter;
using Classification.Performance;
using Math;

namespace Classification.Model;

public class MultiLayerPerceptronModel : LinearPerceptronModel
{
	private readonly ActivationFunction activationFunction;
	private Matrix v;

	/**
	 * <summary>
	 *   A constructor that takes {@link InstanceList}s as trainsSet and validationSet. It  sets the {@link
	 *   NeuralNetworkModel}
	 *   nodes with given {@link InstanceList} then creates an input vector by using given trainSet and finds error.
	 *   Via the validationSet it finds the classification performance and reassigns the allocated weight Matrix with the
	 *   matrix
	 *   that has the best accuracy and the Matrix V with the best Vector input.
	 * </summary>
	 * <param name="trainSet">     InstanceList that is used to train.</param>
	 * <param name="validationSet">InstanceList that is used to validate.</param>
	 * <param name="parameters">
	 *   Multi layer perceptron parameters; seed, learningRate, etaDecrease, crossValidationRatio,
	 *   epoch, hiddenNodes.
	 * </param>
	 */
	public MultiLayerPerceptronModel(InstanceList.InstanceList trainSet,
		InstanceList.InstanceList validationSet, MultiLayerPerceptronParameter parameters) :
		base(trainSet)
	{
		activationFunction = parameters.GetActivationFunction();
		AllocateWeights(parameters.GetHiddenNodes(), new Random(parameters.GetSeed()));
		var bestW = (Matrix) W.Clone();
		var bestV = (Matrix) v.Clone();
		var bestClassificationPerformance = new ClassificationPerformance(0.0);
		var epoch = parameters.GetEpoch();
		var learningRate = parameters.GetLearningRate();
		var activationDerivative = new Vector(1, 0.0);
		for (var i = 0; i < epoch; i++)
		{
			trainSet.Shuffle(parameters.GetSeed());
			for (var j = 0; j < trainSet.Size(); j++)
			{
				CreateInputVector(trainSet.Get(j));
				var hidden = CalculateHidden(x, W, activationFunction);
				var hiddenBiased = hidden.Biased();
				var rMinusY = CalculateRMinusY(trainSet.Get(j), hiddenBiased, v);
				var deltaV = rMinusY.Multiply(hiddenBiased);
				var tmph = v.MultiplyWithVectorFromLeft(rMinusY);
				tmph.Remove(0);
				switch (activationFunction)
				{
				case ActivationFunction.Sigmoid:
					var oneMinusHidden = CalculateOneMinusHidden(hidden);
					activationDerivative = oneMinusHidden.ElementProduct(hidden);
					break;
				case ActivationFunction.Tanh:
					var one = new Vector(hidden.Size(), 1.0);
					hidden.Tanh();
					activationDerivative = one.Difference(hidden.ElementProduct(hidden));
					break;
				case ActivationFunction.Relu:
					hidden.ReluDerivative();
					activationDerivative = hidden;
					break;
				}
				var tmpHidden = tmph.ElementProduct(activationDerivative);
				var deltaW = tmpHidden.Multiply(x);
				deltaV.MultiplyWithConstant(learningRate);
				v.Add(deltaV);
				deltaW.MultiplyWithConstant(learningRate);
				W.Add(deltaW);
			}
			var currentClassificationPerformance = TestClassifier(validationSet);
			if (currentClassificationPerformance.GetAccuracy() >
				bestClassificationPerformance.GetAccuracy())
			{
				bestClassificationPerformance = currentClassificationPerformance;
				bestW = (Matrix) W.Clone();
				bestV = (Matrix) v.Clone();
			}
			learningRate *= parameters.GetEtaDecrease();
		}
		W = bestW;
		v = bestV;
	}

	/**
	 * <summary> The allocateWeights method allocates layers' weights of Matrix W and V.</summary>
	 * <param name="h">Integer value for weights.</param>
	 */
	private void AllocateWeights(int h, Random random)
	{
		W = AllocateLayerWeights(h, d + 1, random);
		v = AllocateLayerWeights(K, h + 1, random);
	}

	/**
         * <summary> The calculateOutput method calculates the forward single hidden layer by using Matrices W and V.</summary>
         */
	protected override void CalculateOutput() =>
		CalculateForwardSingleHiddenLayer(W, v, activationFunction);
}