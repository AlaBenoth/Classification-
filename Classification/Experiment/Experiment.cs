using Classification.FeatureSelection;

namespace Classification.Experiment;

public class Experiment
{
	private readonly Classifier.Classifier classifier;
	private readonly DataSet.DataSet dataSet;
	private readonly Parameter.Parameter parameter;

	/**
         * <summary> Constructor for a specific machine learning experiment</summary>
         * <param name="classifier">Classifier used in the machine learning experiment</param>
         * <param name="parameter">Parameter(s) of the classifier.</param>
         * <param name="dataSet">DataSet on which the classifier is run.</param>
         */
	public Experiment(Classifier.Classifier classifier, Parameter.Parameter parameter,
		DataSet.DataSet dataSet)
	{
		this.classifier = classifier;
		this.parameter = parameter;
		this.dataSet = dataSet;
	}

	/**
         * <summary> Accessor for the classifier attribute.</summary>
         * <returns>Classifier attribute.</returns>
         */
	public Classifier.Classifier GetClassifier() => classifier;

	/**
         * <summary> Accessor for the parameter attribute.</summary>
         * <returns>Parameter attribute.</returns>
         */
	public Parameter.Parameter GetParameter() => parameter;

	/**
         * <summary> Accessor for the dataSet attribute.</summary>
         * <returns>DataSet attribute.</returns>
         */
	public DataSet.DataSet GetDataSet() => dataSet;

	/**
         * <summary>Construct and returns a feature selection experiment.</summary>
         * <param name="featureSubSet">Feature subset used in the feature selection experiment</param>
         * <returns>Experiment constructed</returns>
         */
	public Experiment FeatureSelectedExperiment(FeatureSubSet featureSubSet) =>
		new(classifier, parameter, dataSet.GetSubSetOfFeatures(featureSubSet));
}