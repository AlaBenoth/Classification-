namespace Classification.Attribute;

public class DiscreteAttribute : Attribute
{
	private readonly string value;

	/**
	 * <summary>Constructor for a discrete attribute.</summary>
	 * <param name="value">Value of the attribute.</param>
	 */
	public DiscreteAttribute(string value) => this.value = value;

	/**
	 * <summary>Accessor method for value.</summary>
	 * <returns>value</returns>
	 */
	public string GetValue() => value;

	/**
	 * <summary>Converts value to {@link string}.</summary>
	 * <returns>string representation of value.</returns>
	 */
	public override string ToString() =>
		value == ","
			? "comma"
			: value;

	public override int ContinuousAttributeSize() => 0;
	public override List<double> ContinuousAttributes() => new List<double>();
}