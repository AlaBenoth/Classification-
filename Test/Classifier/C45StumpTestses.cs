using Classification.Classifier;
using NUnit.Framework;

namespace Classification.Tests.Classifier;

public class C45StumpTestses : ClassifierTests
{
	[Test]
	// ReSharper disable once MethodTooLong
	public void TestTrain()
	{
		var c45Stump = new C45Stump();
		c45Stump.Train(iris.GetInstanceList(), null);
		Assert.AreEqual(33.33, 100 * c45Stump.Test(iris.GetInstanceList()).GetErrorRate(), 0.01);
		c45Stump.Train(bupa.GetInstanceList(), null);
		Assert.AreEqual(42.03, 100 * c45Stump.Test(bupa.GetInstanceList()).GetErrorRate(), 0.01);
		c45Stump.Train(dermatology.GetInstanceList(), null);
		Assert.AreEqual(49.73, 100 * c45Stump.Test(dermatology.GetInstanceList()).GetErrorRate(),
			0.01);
		c45Stump.Train(car.GetInstanceList(), null);
		Assert.AreEqual(29.98, 100 * c45Stump.Test(car.GetInstanceList()).GetErrorRate(), 0.01);
		c45Stump.Train(tictactoe.GetInstanceList(), null);
		Assert.AreEqual(30.06, 100 * c45Stump.Test(tictactoe.GetInstanceList()).GetErrorRate(),
			0.01);
		c45Stump.Train(nursery.GetInstanceList(), null);
		Assert.AreEqual(29.03, 100 * c45Stump.Test(nursery.GetInstanceList()).GetErrorRate(),
			0.01);
		c45Stump.Train(chess.GetInstanceList(), null);
		Assert.AreEqual(80.76, 100 * c45Stump.Test(chess.GetInstanceList()).GetErrorRate(), 0.01);
	}
}