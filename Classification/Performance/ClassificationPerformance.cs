namespace Classification.Performance;

public class ClassificationPerformance : Performance
{
	private readonly double accuracy;

	/**
	 * <summary> A constructor that sets the accuracy and errorRate as 1 - accuracy via given accuracy.</summary>
	 * <param name="accuracy">Double value input.</param>
	 */
	public ClassificationPerformance(double accuracy) : base(1 - accuracy) =>
		this.accuracy = accuracy;

	/**
	 * <summary> A constructor that sets the accuracy and errorRate via given input.</summary>
	 * <param name="accuracy"> Double value input.</param>
	 * <param name="errorRate">Double value input.</param>
	 */
	public ClassificationPerformance(double accuracy, double errorRate) : base(errorRate) =>
		this.accuracy = accuracy;

	/**
	 * <summary> Accessor for the accuracy.</summary>
	 * <returns>Accuracy value.</returns>
	 */
	public double GetAccuracy() => accuracy;
}