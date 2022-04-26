using Classification.Attribute;
using Classification.FeatureSelection;
using Math;

namespace Classification.Instance;

public class Instance
{
	private readonly List<Attribute.Attribute> attributes;
	private readonly string classLabel;

	/**
	 * <summary> Constructor for a single instance. Given the attributes and class label, it generates a new instance.</summary>
	 * <param name="classLabel">Class label of the instance.</param>
	 * <param name="attributes">Attributes of the instance.</param>
	 */
	public Instance(string classLabel, List<Attribute.Attribute> attributes)
	{
		this.classLabel = classLabel;
		this.attributes = attributes;
	}

	/**
	 * <summary>
	 *   Constructor for a single instance. Given the class label, it generates a new instance with 0 attributes.
	 *   Attributes must be added later with different addAttribute methods.
	 * </summary>
	 * <param name="classLabel">Class label of the instance.</param>
	 */
	public Instance(string classLabel)
	{
		this.classLabel = classLabel;
		attributes = new List<Attribute.Attribute>();
	}

	/**
	 * <summary> Adds a discrete attribute with the given {@link string} value.</summary>
	 * <param name="value">Value of the discrete attribute.</param>
	 */
	public void AddAttribute(string value) => attributes.Add(new DiscreteAttribute(value));

	/**
	 * <summary> Adds a continuous attribute with the given {@link double} value.</summary>
	 * <param name="value">Value of the continuous attribute.</param>
	 */
	public void AddAttribute(double value) => attributes.Add(new ContinuousAttribute(value));

	/**
	 * <summary> Adds a new attribute.</summary>
	 * <param name="attribute">Attribute to be added.</param>
	 */
	public void AddAttribute(Attribute.Attribute attribute) => attributes.Add(attribute);

	/**
	 * <summary> Adds a {@link Vector} of continuous attributes.</summary>
	 * <param name="vector">{@link Vector} that has the continuous attributes.</param>
	 */
	public void AddVectorAttribute(Vector vector)
	{
		for (var i = 0; i < vector.Size(); i++)
			attributes.Add(new ContinuousAttribute(vector.GetValue(i)));
	}

	/**
	 * <summary> Removes attribute with the given index from the attributes list.</summary>
	 * <param name="index">Index of the attribute to be removed.</param>
	 */
	public void RemoveAttribute(int index) => attributes.RemoveAt(index);

	/**
         * <summary> Removes all the attributes from the attributes list.</summary>
         */
	public void RemoveAllAttributes() => attributes.Clear();

	/**
	 * <summary> Accessor for a single attribute.</summary>
	 * <param name="index">Index of the attribute to be accessed.</param>
	 * <returns>Attribute with index 'index'.</returns>
	 */
	public Attribute.Attribute GetAttribute(int index) => attributes[index];

	/**
	 * <summary> Returns the number of attributes in the attributes list.</summary>
	 * <returns>Number of attributes in the attributes list.</returns>
	 */
	public int AttributeSize() => attributes.Count;

	/**
	 * <summary> Returns the number of continuous and discrete indexed attributes in the attributes list.</summary>
	 * <returns>Number of continuous and discrete indexed attributes in the attributes list.</returns>
	 */
	public int ContinuousAttributeSize()
	{
		var size = 0;
		foreach (var attribute in attributes)
			size += attribute.ContinuousAttributeSize();
		return size;
	}

	/**
	 * <summary>
	 *   The continuousAttributes method creates a new {@link List} result and it adds the continuous attributes of the
	 *   attributes list and also it adds 1 for the discrete indexed attributes.
	 * </summary>
	 * <returns>result {@link List} that has continuous and discrete indexed attributes.</returns>
	 */
	public List<double> ContinuousAttributes()
	{
		var result = new List<double>();
		foreach (var attribute in attributes)
			result = result.Concat(attribute.ContinuousAttributes()).ToList();
		return result;
	}

	/**
	 * <summary> Accessor for the class label.</summary>
	 * <returns>Class label of the instance.</returns>
	 */
	public string GetClassLabel() => classLabel;

	/**
	 * <summary> Converts instance to a {@link string}.</summary>
	 * <returns>A string of attributes separated with comma character.</returns>
	 */
	public override string ToString()
	{
		var result = "";
		foreach (var attribute in attributes)
			result = result + attribute + ",";
		result += classLabel;
		return result;
	}

	/**
	 * <summary>
	 *   The getSubSetOfFeatures method takes a {@link FeatureSubSet} as an input. First it creates a result {@link Instance}
	 *   with the class label, and adds the attributes of the given featureSubSet to it.
	 * </summary>
	 * <param name="featureSubSet">{@link FeatureSubSet} an {@link ArrayList} of indices.</param>
	 * <returns>result Instance.</returns>
	 */
	public Instance GetSubSetOfFeatures(FeatureSubSet featureSubSet)
	{
		var result = new Instance(classLabel);
		for (var i = 0; i < featureSubSet.Size(); i++)
			result.AddAttribute(attributes[featureSubSet.Get(i)]);
		return result;
	}

	/**
	 * <summary> The toVector method returns a {@link Vector} of continuous attributes and discrete indexed attributes.</summary>
	 * <returns>{@link Vector} of continuous attributes and discrete indexed attributes.</returns>
	 */
	public Vector ToVector()
	{
		var values = new List<double>();
		foreach (var attribute in attributes)
			values = values.Concat(attribute.ContinuousAttributes()).ToList();
		return new Vector(values);
	}
}