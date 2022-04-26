using Classification.Performance;
using Sampling;

namespace Classification.Experiment;

public class MxKFoldRunSeparateTests : KFoldRunSeparateTests
{
	private readonly int m;

	/**
         * Constructor for KFoldRunSeparateTests class. Basically sets K parameter of the K-fold cross-validation and M for the number of times..
         *
         * @param M number of cross-validation times.
         * @param K K of the K-fold cross-validation.
         */
	public MxKFoldRunSeparateTests(int m, int k) : base(k) => this.m = m;

	/**
         * Execute the MxKFold run with separate test set with the given classifier on the given data set using the given parameters.
         *
         * @param experiment Experiment to be run.
         * @return An ExperimentPerformance instance.
         */
	public new ExperimentPerformance Execute(Experiment experiment)
	{
		var result = new ExperimentPerformance();
		var instanceList = experiment.GetDataSet().GetInstanceList();
		var partition =
			instanceList.Partition(0.25, new Random(experiment.GetParameter().GetSeed()));
		for (var j = 0; j < m; j++)
		{
			var crossValidation = new KFoldCrossValidation<Instance.Instance>(
				partition.Get(1).GetInstances(), K, experiment.GetParameter().GetSeed());
			RunExperiment(experiment.GetClassifier(), experiment.GetParameter(), result,
				crossValidation, partition.Get(0));
		}
		return result;
	}
}