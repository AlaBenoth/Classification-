using Classification.Classifier;
using NUnit.Framework;

namespace Classification.Tests.Classifier;

public class DummyTests : ClassifierTests
{
	[Test]
	// ReSharper disable once MethodTooLong
	public void TestTrain()
	{
		var dummy = new Dummy();
		dummy.Train(iris.GetInstanceList(), null);
		Assert.AreEqual(66.67, 100 * dummy.Test(iris.GetInstanceList()).GetErrorRate(), 0.01);
		dummy.Train(bupa.GetInstanceList(), null);
		Assert.AreEqual(42.03, 100 * dummy.Test(bupa.GetInstanceList()).GetErrorRate(), 0.01);
		dummy.Train(dermatology.GetInstanceList(), null);
		Assert.AreEqual(69.40, 100 * dummy.Test(dermatology.GetInstanceList()).GetErrorRate(),
			0.01);
		dummy.Train(car.GetInstanceList(), null);
		Assert.AreEqual(29.98, 100 * dummy.Test(car.GetInstanceList()).GetErrorRate(), 0.01);
		dummy.Train(tictactoe.GetInstanceList(), null);
		Assert.AreEqual(34.66, 100 * dummy.Test(tictactoe.GetInstanceList()).GetErrorRate(),
			0.01);
		dummy.Train(nursery.GetInstanceList(), null);
		Assert.AreEqual(66.67, 100 * dummy.Test(nursery.GetInstanceList()).GetErrorRate(), 0.01);
		dummy.Train(chess.GetInstanceList(), null);
		Assert.AreEqual(83.77, 100 * dummy.Test(chess.GetInstanceList()).GetErrorRate(), 0.01);
	}
}