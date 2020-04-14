using Sampling;

namespace Classification.Experiment
{
    public class SingleRunWithK : SingleRun
    {
        private readonly int _k;

        /**
         * <summary> Constructor for SingleRunWithK class. Basically sets K parameter of the K-fold cross-validation.</summary>
         *
         * <param name="k">K of the K-fold cross-validation.</param>
         */
        public SingleRunWithK(int k)
        {
            this._k = k;
        }

        protected Performance.Performance runExperiment(Classifier.Classifier classifier, Parameter.Parameter parameter,
            CrossValidation<Instance.Instance> crossValidation)
        {
            var trainSet = new InstanceList.InstanceList(crossValidation.GetTrainFold(0));
            var testSet = new InstanceList.InstanceList(crossValidation.GetTestFold(0));
            return classifier.SingleRun(parameter, trainSet, testSet);
        }


        /**
         * <summary> Execute Single K-fold cross-validation with the given classifier on the given data set using the given parameters.</summary>
         *
         * <param name="experiment">Experiment to be run.</param>
         * <returns>A Performance instance</returns>
         */
        public Performance.Performance Execute(Experiment experiment)
        {
            var crossValidation =
                new KFoldCrossValidation<Instance.Instance>(experiment.GetDataSet().GetInstances(), _k,
                    experiment.GetParameter().GetSeed());
            return runExperiment(experiment.GetClassifier(), experiment.GetParameter(), crossValidation);
        }
    }
}