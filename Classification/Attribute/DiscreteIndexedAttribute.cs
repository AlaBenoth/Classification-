namespace Classification.Attribute;

public class DiscreteIndexedAttribute : DiscreteAttribute
{
	private readonly int index;
	private readonly int maxIndex;

	/**
	 * <summary>Constructor for a discrete attribute.</summary>
	 * <param name="value">Value of the attribute.</param>
	 * <param name="index">Index of the attribute.</param>
	 * <param name="maxIndex">Maximum index of the attribute.</param>
	 */
	public DiscreteIndexedAttribute(string value, int index, int maxIndex) : base(value)
	{
		this.index = index;
		this.maxIndex = maxIndex;
	}

	/**
	 * <summary>Accessor method for index.</summary>
	 * <returns>index.</returns>
	 */
	public int GetIndex() => index;

	/**
	 * <summary>Accessor method for maxIndex.</summary>
	 * <returns>maxIndex.</returns>
	 */
	public int GetMaxIndex() => maxIndex;

	public override int ContinuousAttributeSize() => maxIndex;

	public override List<double> ContinuousAttributes()
	{
		var result = new List<double>();
		for (var i = 0; i < maxIndex; i++)
			if (i != index)
				result.Add(0.0);
			else
				result.Add(1.0);
		return result;
	}
}