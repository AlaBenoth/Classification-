using Classification.Classifier;
using Classification.Parameter;
using NUnit.Framework;

namespace Classification.Tests.Classifier;

public class BaggingTestses : ClassifierTests
{
	[Test]
	public void TestTrain()
	{
		var bagging = new Bagging();
		var baggingParameter = new BaggingParameter(1, 100);
		bagging.Train(iris.GetInstanceList(), baggingParameter);
		Assert.AreEqual(2.00, 100 * bagging.Test(iris.GetInstanceList()).GetErrorRate(), 0.01);
		bagging.Train(bupa.GetInstanceList(), baggingParameter);
		Assert.AreEqual(42.03, 100 * bagging.Test(bupa.GetInstanceList()).GetErrorRate(), 0.01);
		bagging.Train(dermatology.GetInstanceList(), baggingParameter);
		Assert.AreEqual(2.46, 100 * bagging.Test(dermatology.GetInstanceList()).GetErrorRate(), 0.01);
		bagging.Train(car.GetInstanceList(), baggingParameter);
		Assert.AreEqual(0.0, 100 * bagging.Test(car.GetInstanceList()).GetErrorRate(), 0.01);
		bagging.Train(tictactoe.GetInstanceList(), baggingParameter);
		Assert.AreEqual(0.0, 100 * bagging.Test(tictactoe.GetInstanceList()).GetErrorRate(), 0.01);
		bagging.Train(nursery.GetInstanceList(), baggingParameter);
		Assert.AreEqual(0.0, 100 * bagging.Test(nursery.GetInstanceList()).GetErrorRate(), 0.01);
	}
}