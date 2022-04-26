namespace Classification.Instance;

public class CompositeInstance : Instance
{
	private List<string> possibleClassLabels;

	/**
	 * <summary>
	 *   Constructor of {@link CompositeInstance} class which takes a class label as an input. It generates a new composite
	 *   instance
	 *   with given class label.
	 * </summary>
	 * <param name="classLabel">Class label of the composite instance.</param>
	 */
	public CompositeInstance(string classLabel) : base(classLabel) =>
		possibleClassLabels = new List<string>();

	/**
	 * <summary>
	 *   Constructor of {@link CompositeInstance} class which takes a class label and attributes as inputs. It generates
	 *   a new composite instance with given class label and attributes.
	 * </summary>
	 * <param name="classLabel">Class label of the composite instance.</param>
	 * <param name="attributes">Attributes of the composite instance.</param>
	 */
	public CompositeInstance(string classLabel, List<Attribute.Attribute> attributes) :
		base(classLabel, attributes) =>
		possibleClassLabels = new List<string>();

	/**
	 * <summary>
	 *   Constructor of {@link CompositeInstance} class which takes an {@link java.lang.reflect.Array} of possible labels as
	 *   input. It generates a new composite instance with given labels.
	 * </summary>
	 * <param name="possibleLabels">Possible labels of the composite instance.</param>
	 */
	public CompositeInstance(string[] possibleLabels) : this(possibleLabels[0]) =>
		possibleClassLabels = possibleClassLabels.
			Concat(possibleLabels.ToList().GetRange(1, possibleClassLabels.Count - 1)).ToList();

	/**
	 * <summary>
	 *   Constructor of {@link CompositeInstance} class which takes a class label, attributes and an {@link List} of
	 *   possible labels as inputs. It generates a new composite instance with given labels, attributes and possible labels.
	 * </summary>
	 * <param name="classLabel">         Class label of the composite instance.</param>
	 * <param name="attributes">         Attributes of the composite instance.</param>
	 * <param name="possibleClassLabels">Possible labels of the composite instance.</param>
	 */
	public CompositeInstance(string classLabel, List<Attribute.Attribute> attributes,
		List<string> possibleClassLabels) : base(classLabel, attributes) =>
		this.possibleClassLabels = possibleClassLabels;

	/**
	 * <summary> Accessor for the possible class labels.</summary>
	 * <returns>Possible class labels of the composite instance.</returns>
	 */
	public List<string> GetPossibleClassLabels() => possibleClassLabels;

	/**
	 * <summary> Mutator method for possible class labels.</summary>
	 * <param name="possibleClassLabels">Ner value of possible class labels.</param>
	 */
	public void SetPossibleClassLabels(List<string> possibleClassLabels) =>
		this.possibleClassLabels = possibleClassLabels;

	/**
	 * <summary> Converts composite instance to {@link string}.</summary>
	 * <returns>string representation of composite instance.</returns>
	 */
	public override string ToString()
	{
		var result = base.ToString();
		foreach (var possibleClassLabel in possibleClassLabels)
			result = result + ";" + possibleClassLabel;
		return result;
	}
}