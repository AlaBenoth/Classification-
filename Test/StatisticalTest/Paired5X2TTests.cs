using Classification.Classifier;
using Classification.DistanceMetric;
using Classification.Experiment;
using Classification.Parameter;
using Classification.StatisticalTest;
using Classification.Tests.Classifier;
using NUnit.Framework;

namespace Classification.Tests.StatisticalTest;

public class Paired5X2TTests : ClassifierTests
{
	[Ignore("Slow")]
	[Test]
	// ReSharper disable once MethodTooLong
	public void TestCompare()
	{
		var mxKFoldRun = new MxKFoldRun(5, 2);
		var experimentPerformance1 = mxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new C45(), new C45Parameter(1, true, 0.2),
				iris));
		var experimentPerformance2 = mxKFoldRun.Execute(new Classification.Experiment.Experiment(
			new LinearPerceptron(), new LinearPerceptronParameter(1, 0.1, 0.99, 0.2, 100), iris));
		var paired5X2T = new Paired5X2T();
		Assert.AreEqual(0.329,
			paired5X2T.Compare(experimentPerformance1, experimentPerformance2).GetPValue(), 0.001);
		experimentPerformance1 = mxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new C45(), new C45Parameter(1, true, 0.2),
				tictactoe));
		experimentPerformance2 = mxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new Bagging(), new BaggingParameter(1, 50),
				tictactoe));
		Assert.AreEqual(0.00159,
			paired5X2T.Compare(experimentPerformance1, experimentPerformance2).GetPValue(),
			0.00001);
		experimentPerformance1 = mxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new Lda(), new Parameter.Parameter(1), dermatology));
		experimentPerformance2 = mxKFoldRun.Execute(new Classification.Experiment.Experiment(
			new LinearPerceptron(), new LinearPerceptronParameter(1, 0.1, 0.99, 0.2, 100),
			dermatology));
		Assert.AreEqual(0.769,
			paired5X2T.Compare(experimentPerformance1, experimentPerformance2).GetPValue(), 0.001);
		experimentPerformance1 = mxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new Dummy(), new Parameter.Parameter(1), nursery));
		experimentPerformance2 = mxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new NaiveBayes(), new Parameter.Parameter(1), nursery));
		Assert.AreEqual(0.0,
			paired5X2T.Compare(experimentPerformance1, experimentPerformance2).GetPValue(), 0.0001);
		experimentPerformance1 = mxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new NaiveBayes(), new Parameter.Parameter(1), car));
		experimentPerformance2 = mxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new Bagging(), new BaggingParameter(1, 50),
				car));
		Assert.AreEqual(0.0078,
			paired5X2T.Compare(experimentPerformance1, experimentPerformance2).GetPValue(), 0.0001);
		experimentPerformance1 = mxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new Knn(),
				new KnnParameter(1, 3, new EuclidianDistance()), bupa));
		experimentPerformance2 =
			mxKFoldRun.Execute(
				new Classification.Experiment.Experiment(new Lda(), new Parameter.Parameter(1), bupa));
		Assert.AreEqual(0.035,
			paired5X2T.Compare(experimentPerformance1, experimentPerformance2).GetPValue(), 0.001);
	}
}