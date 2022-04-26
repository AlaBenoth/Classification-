namespace Classification.Filter;

public abstract class TrainedFeatureFilter : FeatureFilter
{
	/**
	 * <summary> Constructor that sets the dataSet.</summary>
	 * <param name="dataSet">DataSet that will bu used.</param>
	 */
	public TrainedFeatureFilter(DataSet.DataSet dataSet) : base(dataSet) { }

	protected abstract void Train();
}