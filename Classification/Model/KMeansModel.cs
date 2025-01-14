using Math;

namespace Classification.Model;

public class KMeansModel : GaussianModel
{
	private readonly InstanceList.InstanceList classMeans;
	private readonly DistanceMetric.DistanceMetric distanceMetric;

	/**
	 * <summary> The constructor that sets the classMeans, priorDistribution and distanceMetric according to given inputs.</summary>
	 * <param name="priorDistribution">{@link DiscreteDistribution} input.</param>
	 * <param name="classMeans">       {@link InstanceList} of class means.</param>
	 * <param name="distanceMetric">   {@link DistanceMetric} input.</param>
	 */
	public KMeansModel(DiscreteDistribution priorDistribution,
		InstanceList.InstanceList classMeans, DistanceMetric.DistanceMetric distanceMetric)
	{
		this.classMeans = classMeans;
		this.priorDistribution = priorDistribution;
		this.distanceMetric = distanceMetric;
	}

	/**
	 * <summary>
	 *   The calculateMetric method takes an {@link Instance} and a String as inputs. It loops through the class means, if
	 *   the corresponding class label is same as the given String it returns the negated distance between given instance and
	 *   the
	 *   current item of class means. Otherwise it returns the smallest negative number.
	 * </summary>
	 * <param name="instance">{@link Instance} input.</param>
	 * <param name="Ci">      String input.</param>
	 * <returns>The negated distance between given instance and the current item of class means.</returns>
	 */
	protected override double CalculateMetric(Instance.Instance instance, string ci)
	{
		for (var i = 0; i < classMeans.Size(); i++)
			if (classMeans.Get(i).GetClassLabel() == ci)
				return -distanceMetric.Distance(instance, classMeans.Get(i));
		return double.MinValue;
	}
}