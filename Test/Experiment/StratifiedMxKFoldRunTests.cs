using Classification.Classifier;
using Classification.DistanceMetric;
using Classification.Experiment;
using Classification.Parameter;
using Classification.Tests.Classifier;
using NUnit.Framework;

namespace Classification.Tests.Experiment;

public class StratifiedMxKFoldRunTests : ClassifierTests
{
	[Test]
	// ReSharper disable once MethodTooLong
	public void TestExecute()
	{
		var stratifiedMxKFoldRun = new StratifiedMxKFoldRun(5, 2);
		var experimentPerformance = stratifiedMxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new C45(), new C45Parameter(1, true, 0.2),
				iris));
		Assert.AreEqual(4.00, 100 * experimentPerformance.MeanPerformance().GetErrorRate(), 0.01);
		experimentPerformance = stratifiedMxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new C45(), new C45Parameter(1, true, 0.2),
				tictactoe));
		Assert.AreEqual(22.23, 100 * experimentPerformance.MeanPerformance().GetErrorRate(),
			0.01);
		experimentPerformance = stratifiedMxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new Knn(),
				new KnnParameter(1, 3, new EuclidianDistance()), bupa));
		Assert.AreEqual(40.58, 100 * experimentPerformance.MeanPerformance().GetErrorRate(),
			0.01);
		experimentPerformance = stratifiedMxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new Knn(),
				new KnnParameter(1, 3, new EuclidianDistance()), dermatology));
		Assert.AreEqual(18.31, 100 * experimentPerformance.MeanPerformance().GetErrorRate(),
			0.01);
		experimentPerformance = stratifiedMxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new Lda(), new Parameter.Parameter(1), bupa));
		Assert.AreEqual(34.49, 100 * experimentPerformance.MeanPerformance().GetErrorRate(),
			0.01);
		experimentPerformance = stratifiedMxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new Lda(), new Parameter.Parameter(1), dermatology));
		Assert.AreEqual(5.46, 100 * experimentPerformance.MeanPerformance().GetErrorRate(), 0.01);
		experimentPerformance = stratifiedMxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new LinearPerceptron(),
				new LinearPerceptronParameter(1, 0.1, 0.99, 0.2, 100), iris));
		Assert.AreEqual(5.33, 100 * experimentPerformance.MeanPerformance().GetErrorRate(), 0.01);
		experimentPerformance = stratifiedMxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new LinearPerceptron(),
				new LinearPerceptronParameter(1, 0.1, 0.99, 0.2, 100), dermatology));
		Assert.AreEqual(3.83, 100 * experimentPerformance.MeanPerformance().GetErrorRate(), 0.01);
		experimentPerformance = stratifiedMxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new NaiveBayes(), new Parameter.Parameter(1), car));
		Assert.AreEqual(14.87, 100 * experimentPerformance.MeanPerformance().GetErrorRate(),
			0.01);
		experimentPerformance = stratifiedMxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new NaiveBayes(), new Parameter.Parameter(1), nursery));
		Assert.AreEqual(9.77, 100 * experimentPerformance.MeanPerformance().GetErrorRate(), 0.01);
		experimentPerformance = stratifiedMxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new Bagging(), new BaggingParameter(1, 50),
				tictactoe));
		Assert.AreEqual(7.41, 100 * experimentPerformance.MeanPerformance().GetErrorRate(), 0.01);
		experimentPerformance = stratifiedMxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new Bagging(), new BaggingParameter(1, 50),
				car));
		Assert.AreEqual(9.61, 100 * experimentPerformance.MeanPerformance().GetErrorRate(), 0.01);
		experimentPerformance = stratifiedMxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new Dummy(), new Parameter.Parameter(1), nursery));
		Assert.AreEqual(66.67, 100 * experimentPerformance.MeanPerformance().GetErrorRate(),
			0.01);
		experimentPerformance = stratifiedMxKFoldRun.Execute(
			new Classification.Experiment.Experiment(new Dummy(), new Parameter.Parameter(1), iris));
		Assert.AreEqual(66.67, 100 * experimentPerformance.MeanPerformance().GetErrorRate(),
			0.01);
	}
}