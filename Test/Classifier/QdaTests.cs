using Classification.Classifier;
using NUnit.Framework;

namespace Classification.Tests.Classifier;

public class QdaTests : ClassifierTests
{
	[Ignore("Slow")]
	[Test]
	public void TestTrain()
	{
		var qda = new Qda();
		qda.Train(iris.GetInstanceList(), null);
		Assert.AreEqual(2.00, 100 * qda.Test(iris.GetInstanceList()).GetErrorRate(), 0.01);
		qda.Train(bupa.GetInstanceList(), null);
		Assert.AreEqual(36.52, 100 * qda.Test(bupa.GetInstanceList()).GetErrorRate(), 0.01);
	}
}