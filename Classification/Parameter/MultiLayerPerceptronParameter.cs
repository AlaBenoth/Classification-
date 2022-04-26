namespace Classification.Parameter;

public class MultiLayerPerceptronParameter : LinearPerceptronParameter
{
	private readonly ActivationFunction activationFunction;
	private readonly int hiddenNodes;

	/**
	 * <summary> Parameters of the multi layer perceptron algorithm.</summary>
	 * <param name="seed">                Seed is used for random number generation.</param>
	 * <param name="learningRate">        Double value for learning rate of the algorithm.</param>
	 * <param name="etaDecrease">         Double value for decrease in eta of the algorithm.</param>
	 * <param name="crossValidationRatio">Double value for cross validation ratio of the algorithm.</param>
	 * <param name="epoch">               Integer value for epoch number of the algorithm.</param>
	 * <param name="hiddenNodes">         Integer value for the number of hidden nodes.</param>
	 * <param name="activationFunction">         Activation function.</param>
	 */
	// ReSharper disable once TooManyDependencies
	public MultiLayerPerceptronParameter(int seed, double learningRate, double etaDecrease,
		double crossValidationRatio, int epoch, int hiddenNodes,
		ActivationFunction activationFunction) : base(seed, learningRate, etaDecrease,
		crossValidationRatio, epoch)
	{
		this.hiddenNodes = hiddenNodes;
		this.activationFunction = activationFunction;
	}

	/**
	 * <summary> Accessor for the hiddenNodes.</summary>
	 * <returns>The hiddenNodes.</returns>
	 */
	public int GetHiddenNodes() => hiddenNodes;

	/**
	 * <summary> Accessor for the activation function.</summary>
	 * <returns>The activation function.</returns>
	 */
	public ActivationFunction GetActivationFunction() => activationFunction;
}