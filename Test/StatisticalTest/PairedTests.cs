using Classification.Classifier;
using Classification.DistanceMetric;
using Classification.Experiment;
using Classification.Parameter;
using Classification.StatisticalTest;
using Classification.Tests.Classifier;
using NUnit.Framework;

namespace Classification.Tests.StatisticalTest;

public class PairedTests : ClassifierTests
{
	[Ignore("Slow")]
	[Test]
	// ReSharper disable once MethodTooLong
	public void TestCompare()
	{
		var kFoldRun = new KFoldRun(10);
		var experimentPerformance1 = kFoldRun.Execute(
			new Classification.Experiment.Experiment(new C45(), new C45Parameter(1, true, 0.2),
				iris));
		var experimentPerformance2 = kFoldRun.Execute(new Classification.Experiment.Experiment(
			new LinearPerceptron(), new LinearPerceptronParameter(1, 0.1, 0.99, 0.2, 100), iris));
		var pairedt = new Pairedt();
		Assert.AreEqual(0.136,
			pairedt.Compare(experimentPerformance1, experimentPerformance2).GetPValue(), 0.001);
		experimentPerformance1 = kFoldRun.Execute(
			new Classification.Experiment.Experiment(new C45(), new C45Parameter(1, true, 0.2),
				tictactoe));
		experimentPerformance2 = kFoldRun.Execute(
			new Classification.Experiment.Experiment(new Bagging(), new BaggingParameter(1, 50),
				tictactoe));
		Assert.AreEqual(0.00000006,
			pairedt.Compare(experimentPerformance1, experimentPerformance2).GetPValue(),
			0.00000001);
		experimentPerformance1 = kFoldRun.Execute(
			new Classification.Experiment.Experiment(new Lda(), new Parameter.Parameter(1),
				dermatology));
		experimentPerformance2 = kFoldRun.Execute(new Classification.Experiment.Experiment(
			new LinearPerceptron(), new LinearPerceptronParameter(1, 0.1, 0.99, 0.2, 100),
			dermatology));
		Assert.AreEqual(0.2935,
			pairedt.Compare(experimentPerformance1, experimentPerformance2).GetPValue(), 0.0001);
		experimentPerformance1 = kFoldRun.Execute(
			new Classification.Experiment.Experiment(new Dummy(), new Parameter.Parameter(1),
				nursery));
		experimentPerformance2 = kFoldRun.Execute(
			new Classification.Experiment.Experiment(new NaiveBayes(), new Parameter.Parameter(1),
				nursery));
		Assert.AreEqual(0.0,
			pairedt.Compare(experimentPerformance1, experimentPerformance2).GetPValue(), 0.0000001);
		experimentPerformance1 = kFoldRun.Execute(
			new Classification.Experiment.Experiment(new NaiveBayes(), new Parameter.Parameter(1),
				car));
		experimentPerformance2 = kFoldRun.Execute(
			new Classification.Experiment.Experiment(new Bagging(), new BaggingParameter(1, 50),
				car));
		Assert.AreEqual(0.0000098,
			pairedt.Compare(experimentPerformance1, experimentPerformance2).GetPValue(), 0.0000001);
		experimentPerformance1 = kFoldRun.Execute(
			new Classification.Experiment.Experiment(new Knn(),
				new KnnParameter(1, 3, new EuclidianDistance()), bupa));
		experimentPerformance2 = kFoldRun.Execute(
			new Classification.Experiment.Experiment(new Lda(), new Parameter.Parameter(1), bupa));
		Assert.AreEqual(0.1020,
			pairedt.Compare(experimentPerformance1, experimentPerformance2).GetPValue(), 0.0001);
	}
}