using Classification.Classifier;
using Classification.Parameter;
using NUnit.Framework;

namespace Classification.Tests.Classifier;

public class DeepNetworkTests : ClassifierTests
{
	[Test]
	public void TestTrain()
	{
		var deepNetwork = new DeepNetwork();
		var deepNetworkParameter = new DeepNetworkParameter(1, 0.1, 0.99, 0.2, 100,
			new List<int> {5, 5}, ActivationFunction.Sigmoid);
		deepNetwork.Train(iris.GetInstanceList(), deepNetworkParameter);
		Assert.AreEqual(3.33, 100 * deepNetwork.Test(iris.GetInstanceList()).GetErrorRate(),
			0.01);
		deepNetworkParameter = new DeepNetworkParameter(1, 0.01, 0.99, 0.2, 100,
			new List<int> {15, 15}, ActivationFunction.Sigmoid);
		deepNetwork.Train(bupa.GetInstanceList(), deepNetworkParameter);
		Assert.AreEqual(30.14, 100 * deepNetwork.Test(bupa.GetInstanceList()).GetErrorRate(),
			0.01);
		deepNetworkParameter = new DeepNetworkParameter(1, 0.01, 0.99, 0.2, 100,
			new List<int> {20}, ActivationFunction.Sigmoid);
		deepNetwork.Train(dermatology.GetInstanceList(), deepNetworkParameter);
		Assert.AreEqual(2.19,
			100 * deepNetwork.Test(dermatology.GetInstanceList()).GetErrorRate(), 0.01);
	}
}