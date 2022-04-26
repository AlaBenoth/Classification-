using Classification.Model;

namespace Classification.Classifier;

public class RandomClassifier : Classifier
{
	/**
	 * <summary> Training algorithm for random classifier.</summary>
	 * <param name="trainSet">  Training data given to the algorithm.</param>
	 * <param name="parameters">-</param>
	 */
	public override void
		Train(InstanceList.InstanceList trainSet, Parameter.Parameter parameters) =>
		model = new RandomModel(new List<string>(trainSet.ClassDistribution().Keys),
			parameters.GetSeed());
}