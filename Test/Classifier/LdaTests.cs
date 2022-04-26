using Classification.Classifier;
using NUnit.Framework;

namespace Classification.Tests.Classifier;

public class LdaTests : ClassifierTests
{
	[Test]
	public void TestTrain()
	{
		var lda = new Lda();
		lda.Train(iris.GetInstanceList(), null);
		Assert.AreEqual(2.00, 100 * lda.Test(iris.GetInstanceList()).GetErrorRate(), 0.01);
		lda.Train(bupa.GetInstanceList(), null);
		Assert.AreEqual(29.57, 100 * lda.Test(bupa.GetInstanceList()).GetErrorRate(), 0.01);
		lda.Train(dermatology.GetInstanceList(), null);
		Assert.AreEqual(1.91, 100 * lda.Test(dermatology.GetInstanceList()).GetErrorRate(), 0.01);
	}
}