using Classification.Classifier;
using Classification.DistanceMetric;
using Classification.Parameter;
using NUnit.Framework;

namespace Classification.Tests.Classifier;

public class KnnTests : ClassifierTests
{
	[Test]
	public void TestTrain()
	{
		var knn = new Knn();
		var knnParameter = new KnnParameter(1, 3, new EuclidianDistance());
		knn.Train(iris.GetInstanceList(), knnParameter);
		Assert.AreEqual(4.00, 100 * knn.Test(iris.GetInstanceList()).GetErrorRate(), 0.01);
		knn.Train(bupa.GetInstanceList(), knnParameter);
		Assert.AreEqual(19.42, 100 * knn.Test(bupa.GetInstanceList()).GetErrorRate(), 0.01);
		knn.Train(dermatology.GetInstanceList(), knnParameter);
		Assert.AreEqual(3.01, 100 * knn.Test(dermatology.GetInstanceList()).GetErrorRate(), 0.01);
		knn.Train(car.GetInstanceList(), knnParameter);
		Assert.AreEqual(4.75, 100 * knn.Test(car.GetInstanceList()).GetErrorRate(), 0.01);
		knn.Train(tictactoe.GetInstanceList(), knnParameter);
		Assert.AreEqual(5.64, 100 * knn.Test(tictactoe.GetInstanceList()).GetErrorRate(), 0.01);
	}
}