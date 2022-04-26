namespace Classification.Attribute;

public class ContinuousAttribute : Attribute
{
	private double value;

	/**
	 * <summary>Constructor for a continuous attribute.</summary>
	 * <param name="value">Value of the attribute.</param>
	 */
	public ContinuousAttribute(double value) => this.value = value;

	/**
	 * <summary>Accessor method for value.</summary>
	 * <returns>value</returns>
	 */
	public double GetValue() => value;

	/**
	 * <summary>Mutator method for value</summary>
	 * <param name="value">New value of value.</param>
	 */
	public void SetValue(double value) => this.value = value;

	/**
	 * <summary>Converts value to {@link String}.</summary>
	 * <returns>String representation of value.</returns>
	 */
	public override string ToString() => value.ToString("F4");

	public override int ContinuousAttributeSize() => 1;

	public override List<double> ContinuousAttributes()
	{
		var result = new List<double> {value};
		return result;
	}
}