using Classification.Classifier;
using Classification.Parameter;
using NUnit.Framework;

namespace Classification.Tests.Classifier;

public class RandomForestTests : ClassifierTests
{
	[Test]
	public void TestTrain()
	{
		var randomForest = new RandomForest();
		var randomForestParameter = new RandomForestParameter(1, 100, 10);
		randomForest.Train(diabetes.GetInstanceList(), randomForestParameter);
		var accuracy = 100 * (1 - randomForest.Test(diabetes.GetInstanceList()).GetErrorRate());
		Console.WriteLine(accuracy);
		Assert.That(accuracy, Is.GreaterThanOrEqualTo(98));
		randomForest.Train(bupa.GetInstanceList(), randomForestParameter);
		Assert.AreEqual(42.03, 100 * randomForest.Test(bupa.GetInstanceList()).GetErrorRate(),
			0.01);
		randomForest.Train(dermatology.GetInstanceList(), randomForestParameter);
		Assert.AreEqual(18,
			100 * randomForest.Test(dermatology.GetInstanceList()).GetErrorRate(), 1);
		randomForest.Train(car.GetInstanceList(), randomForestParameter);
		Assert.AreEqual(0.0, 100 * randomForest.Test(car.GetInstanceList()).GetErrorRate(), 0.01);
		randomForest.Train(tictactoe.GetInstanceList(), randomForestParameter);
		Assert.AreEqual(0.0, 100 * randomForest.Test(tictactoe.GetInstanceList()).GetErrorRate(),
			0.01);
		randomForest.Train(nursery.GetInstanceList(), randomForestParameter);
		Assert.AreEqual(0.0, 100 * randomForest.Test(nursery.GetInstanceList()).GetErrorRate(),
			0.01);
	}
}