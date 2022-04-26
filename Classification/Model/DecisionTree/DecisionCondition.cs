using Classification.Attribute;

namespace Classification.Model.DecisionTree;

public class DecisionCondition
{
	/**
	 * <summary>
	 *   A constructor that sets attributeIndex and {@link Attribute} value. It also assigns equal sign to the
	 *   comparison character.
	 * </summary>
	 * <param name="attributeIndex">Integer number that shows attribute index.</param>
	 * <param name="value">         The value of the {@link Attribute}.</param>
	 */
	public DecisionCondition(int attributeIndex, Attribute.Attribute value)
	{
		this.attributeIndex = attributeIndex;
		comparison = '=';
		this.value = value;
	}

	/**
	 * <summary> A constructor that sets attributeIndex, comparison and {@link Attribute} value.</summary>
	 * <param name="attributeIndex">Integer number that shows attribute index.</param>
	 * <param name="value">         The value of the {@link Attribute}.</param>
	 * <param name="comparison">    Comparison character.</param>
	 */
	public DecisionCondition(int attributeIndex, char comparison, Attribute.Attribute value)
	{
		this.attributeIndex = attributeIndex;
		this.comparison = comparison;
		this.value = value;
	}

	private readonly int attributeIndex;
	private readonly char comparison;
	private readonly Attribute.Attribute value;

	/**
	 * <summary>
	 *   The satisfy method takes an {@link Instance} as an input.
	 *   <p />
	 *   If defined {@link Attribute} value is a {@link DiscreteIndexedAttribute} it compares the index of {@link Attribute}
	 *   of instance at the
	 *   attributeIndex and the index of {@link Attribute} value and returns the result.
	 *   <p />
	 *   If defined {@link Attribute} value is a {@link DiscreteAttribute} it compares the value of {@link Attribute} of
	 *   instance at the
	 *   attributeIndex and the value of {@link Attribute} value and returns the result.
	 *   <p />
	 *   If defined {@link Attribute} value is a {@link ContinuousAttribute} it compares the value of {@link Attribute} of
	 *   instance at the
	 *   attributeIndex and the value of {@link Attribute} value and returns the result according to the comparison character
	 *   whether it is
	 *   less than or greater than signs.
	 * </summary>
	 * <param name="instance">Instance to compare.</param>
	 * <returns>True if gicen instance satisfies the conditions.</returns>
	 */
	// ReSharper disable MethodTooLong
	public bool Satisfy(Instance.Instance instance)
	{
		if (value is DiscreteIndexedAttribute discreteIndexedAttribute)
		{
			if (discreteIndexedAttribute.GetIndex() != -1)
				return ((DiscreteIndexedAttribute) instance.GetAttribute(attributeIndex)).
					GetIndex() == discreteIndexedAttribute.GetIndex();
			return true;
		}
		if (value is DiscreteAttribute discreteAttribute)
			return ((DiscreteAttribute) instance.GetAttribute(attributeIndex)).GetValue() ==
				discreteAttribute.GetValue();
		if (value is ContinuousAttribute continuousAttribute)
		{
			if (comparison == '<')
				return ((ContinuousAttribute) instance.GetAttribute(attributeIndex)).GetValue() <=
					continuousAttribute.GetValue();
			if (comparison == '>')
				return ((ContinuousAttribute) instance.GetAttribute(attributeIndex)).GetValue() >
					continuousAttribute.GetValue();
		}
		return false;
	}
}