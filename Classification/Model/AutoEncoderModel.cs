using Classification.Parameter;
using Math;

namespace Classification.Model;

public class AutoEncoderModel : NeuralNetworkModel
{
	private Matrix v, w;

	/**
	 * <summary>
	 *   The {@link AutoEncoderModel} method takes two {@link InstanceList}s as inputs; train set and validation set. First it
	 *   allocates
	 *   the weights of W and V matrices using given {@link MultiLayerPerceptronParameter} and takes the clones of these
	 *   matrices as the bestW and bestV.
	 *   Then, it gets the epoch and starts to iterate over them. First it shuffles the train set and tries to find the new W
	 *   and V matrices.
	 *   At the end it tests the autoencoder with given validation set and if its performance is better than the previous one,
	 *   it reassigns the bestW and bestV matrices. Continue to iterate with a lower learning rate till the end of an episode.
	 * </summary>
	 * <param name="trainSet">     {@link InstanceList} to use as train set.</param>
	 * <param name="validationSet">{@link InstanceList} to use as validation set.</param>
	 * <param name="parameters">   {@link MultiLayerPerceptronParameter} is used to get the parameters.</param>
	 */
	public AutoEncoderModel(InstanceList.InstanceList trainSet,
		InstanceList.InstanceList validationSet, MultiLayerPerceptronParameter parameters) :
		base(trainSet)
	{
		K = trainSet.Get(0).ContinuousAttributeSize();
		AllocateWeights(parameters.GetHiddenNodes(), new Random(parameters.GetSeed()));
		var bestW = (Matrix) w.Clone();
		var bestV = (Matrix) v.Clone();
		var bestPerformance = new Performance.Performance(double.MaxValue);
		var epoch = parameters.GetEpoch();
		var learningRate = parameters.GetLearningRate();
		for (var i = 0; i < epoch; i++)
		{
			trainSet.Shuffle(parameters.GetSeed());
			for (var j = 0; j < trainSet.Size(); j++)
			{
				CreateInputVector(trainSet.Get(j));
				r = trainSet.Get(j).ToVector();
				var hidden = CalculateHidden(x, w, ActivationFunction.Sigmoid);
				var hiddenBiased = hidden.Biased();
				y = v.MultiplyWithVectorFromRight(hiddenBiased);
				var rMinusY = r.Difference(y);
				var deltaV = rMinusY.Multiply(hiddenBiased);
				var oneMinusHidden = CalculateOneMinusHidden(hidden);
				var tmph = v.MultiplyWithVectorFromLeft(rMinusY);
				tmph.Remove(0);
				var tmpHidden = oneMinusHidden.ElementProduct(hidden.ElementProduct(tmph));
				var deltaW = tmpHidden.Multiply(x);
				deltaV.MultiplyWithConstant(learningRate);
				v.Add(deltaV);
				deltaW.MultiplyWithConstant(learningRate);
				w.Add(deltaW);
			}
			var currentPerformance = TestAutoEncoder(validationSet);
			if (currentPerformance.GetErrorRate() < bestPerformance.GetErrorRate())
			{
				bestPerformance = currentPerformance;
				bestW = (Matrix) w.Clone();
				bestV = (Matrix) v.Clone();
			}
			learningRate *= 0.95;
		}
		w = bestW;
		v = bestV;
	}

	/**
	 * <summary>
	 *   The allocateWeights method takes an integer number and sets layer weights of W and V matrices according to
	 *   given number.
	 * </summary>
	 * <param name="h">Integer input.</param>
	 */
	private void AllocateWeights(int h, Random random)
	{
		w = AllocateLayerWeights(h, d + 1, random);
		v = AllocateLayerWeights(K, h + 1, random);
	}

	/**
	 * <summary>
	 *   The testAutoEncoder method takes an {@link InstanceList} as an input and tries to predict a value and finds the
	 *   difference with the
	 *   actual value for each item of that InstanceList. At the end, it returns an error rate by finding the mean of total
	 *   errors.
	 * </summary>
	 * <param name="data">{@link InstanceList} to use as validation set.</param>
	 * <returns>Error rate by finding the mean of total errors.</returns>
	 */
	public Performance.Performance TestAutoEncoder(InstanceList.InstanceList data)
	{
		double total = data.Size();
		var error = 0.0;
		for (var i = 0; i < total; i++)
		{
			y = PredictInput(data.Get(i));
			r = data.Get(i).ToVector();
			error += r.Difference(y).DotProduct();
		}
		return new Performance.Performance(error / total);
	}

	/**
	 * <summary>
	 *   The predictInput method takes an {@link Instance} as an input and calculates a forward single hidden layer
	 *   and returns the predicted value.
	 * </summary>
	 * <param name="instance">{@link Instance} to predict.</param>
	 * <returns>Predicted value.</returns>
	 */
	private Vector PredictInput(Instance.Instance instance)
	{
		CreateInputVector(instance);
		CalculateForwardSingleHiddenLayer(w, v, ActivationFunction.Sigmoid);
		return y;
	}

	/**
         * <summary> The calculateOutput method calculates a forward single hidden layer.</summary>
         */
	protected override void CalculateOutput() =>
		CalculateForwardSingleHiddenLayer(w, v, ActivationFunction.Sigmoid);

	public override Dictionary<string, double> PredictProbability(Instance.Instance instance) =>
		null;
}