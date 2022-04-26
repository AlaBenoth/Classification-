using Classification.Instance;

namespace Classification.Model;

public class RandomModel : Model
{
	private readonly List<string> classLabels;
	private readonly Random random;

	/**
	 * <summary> A constructor that sets the class labels.</summary>
	 * <param name="classLabels">An List of class labels.</param>
	 */
	public RandomModel(List<string> classLabels, int seed)
	{
		this.classLabels = classLabels;
		random = new Random(seed);
	}

	/**
	 * <summary>
	 *   The predict method gets an Instance as an input and retrieves the possible class labels as an List. Then selects a
	 *   random number as an index and returns the class label at this selected index.
	 * </summary>
	 * <param name="instance">{@link Instance} to make prediction.</param>
	 * <returns>The class label at the randomly selected index.</returns>
	 */
	public override string Predict(Instance.Instance instance)
	{
		if (instance is CompositeInstance compositeInstance)
		{
			var possibleClassLabels = compositeInstance.GetPossibleClassLabels();
			var size = possibleClassLabels.Count;
			var index = random.Next(size);
			return possibleClassLabels[index];
		}
		else
		{
			var size = classLabels.Count;
			var index = random.Next(size);
			return classLabels[index];
		}
	}

	public override Dictionary<string, double> PredictProbability(Instance.Instance instance)
	{
		var result = new Dictionary<string, double>();
		foreach (var classLabel in classLabels)
			result[classLabel] = 1.0 / classLabels.Count;
		return result;
	}
}