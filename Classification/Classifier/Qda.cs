using Classification.InstanceList;
using Classification.Model;
using Math;

namespace Classification.Classifier;

public class Qda : Classifier
{
	/**
	 * <summary>
	 *   Training algorithm for the quadratic discriminant analysis classifier (Introduction to Machine Learning,
	 *   Alpaydin, 2015).
	 * </summary>
	 * <param name="trainSet">  Training data given to the algorithm.</param>
	 * <param name="parameters">-</param>
	 */
	// ReSharper disable once MethodTooLong
	public override void Train(InstanceList.InstanceList trainSet,
		Parameter.Parameter parameters)
	{
		var w0 = new Dictionary<string, double>();
		var W = new Dictionary<string, Vector>();
		var w = new Dictionary<string, Matrix>();
		var classLists = trainSet.DivideIntoClasses();
		var priorDistribution = trainSet.ClassDistribution();
		for (var i = 0; i < classLists.Size(); i++)
		{
			var ci = ((InstanceListOfSameClass) classLists.Get(i)).GetClassLabel();
			var averageVector = new Vector(classLists.Get(i).ContinuousAttributeAverage());
			var classCovariance = classLists.Get(i).Covariance(averageVector);
			var determinant = classCovariance.Determinant();
			classCovariance.Inverse();
			var Wi = (Matrix) classCovariance.Clone();
			Wi.MultiplyWithConstant(-0.5);
			w[ci] = Wi;
			var wi = classCovariance.MultiplyWithVectorFromLeft(averageVector);
			w[ci] = Wi;
			var w0I = -0.5 * (wi.DotProduct(averageVector) + System.Math.Log(determinant)) +
				System.Math.Log(priorDistribution.GetProbability(ci));
			w0[ci] = w0I;
		}
		model = new QdaModel(priorDistribution, w, W, w0);
	}
}