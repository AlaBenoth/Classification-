using Classification.Attribute;
using Classification.FeatureSelection;

namespace Classification.DataSet;

public class DataDefinition
{
	private readonly List<AttributeType> attributeTypes;

	/**
         * <summary> Constructor for creating a new {@link DataDefinition}.</summary>
         */
	public DataDefinition() => attributeTypes = new List<AttributeType>();

	/**
	 * <summary> Constructor for creating a new {@link DataDefinition} with given attribute types.</summary>
	 * <param name="attributeTypes">Attribute types of the data definition.</param>
	 */
	public DataDefinition(List<AttributeType> attributeTypes) =>
		this.attributeTypes = attributeTypes;

	/**
	 * <summary> Returns the number of attribute types.</summary>
	 * <returns>Number of attribute types.</returns>
	 */
	public int AttributeCount() => attributeTypes.Count;

	/**
	 * <summary> Counts the occurrences of binary and discrete type attributes.</summary>
	 * <returns>Count of binary and discrete type attributes.</returns>
	 */
	public int DiscreteAttributeCount()
	{
		var count = 0;
		foreach (var attributeType in attributeTypes)
			if (attributeType.Equals(AttributeType.DISCRETE) ||
				attributeType.Equals(AttributeType.BINARY))
				count++;
		return count;
	}

	/**
	 * <summary> Counts the occurrences of binary and continuous type attributes.</summary>
	 * <returns>Count of of binary and continuous type attributes.</returns>
	 */
	public int ContinuousAttributeCount()
	{
		var count = 0;
		foreach (var attributeType in attributeTypes)
			if (attributeType.Equals(AttributeType.CONTINUOUS))
				count++;
		return count;
	}

	/**
	 * <summary> Returns the attribute type of the corresponding item at given index.</summary>
	 * <param name="index">Index of the attribute type.</param>
	 * <returns>Attribute type of the corresponding item at given index.</returns>
	 */
	public AttributeType GetAttributeType(int index) => attributeTypes[index];

	/**
	 * <summary> Adds an attribute type to the list of attribute types.</summary>
	 * <param name="attributeType">Attribute type to add to the list of attribute types.</param>
	 */
	public void AddAttribute(AttributeType attributeType) => attributeTypes.Add(attributeType);

	/**
	 * <summary> Removes the attribute type at given index from the list of attributes.</summary>
	 * <param name="index">Index to remove attribute type from list.</param>
	 */
	public void RemoveAttribute(int index) => attributeTypes.RemoveAt(index);

	/**
         * <summary> Clears all the attribute types from list.</summary>
         */
	public void RemoveAllAttributes() => attributeTypes.Clear();

	/**
	 * <summary>Generates new subset of attribute types by using given feature subset.</summary>
	 * <param name="featureSubSet">{@link FeatureSubSet} input.</param>
	 * <returns>DataDefinition with new subset of attribute types.</returns>
	 */
	public DataDefinition GetSubSetOfFeatures(FeatureSubSet featureSubSet)
	{
		var newAttributeTypes = new List<AttributeType>();
		for (var i = 0; i < featureSubSet.Size(); i++)
			newAttributeTypes.Add(attributeTypes[featureSubSet.Get(i)]);
		return new DataDefinition(newAttributeTypes);
	}
}