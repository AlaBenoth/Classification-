namespace Classification.InstanceList;

public class Partition
{
	private readonly List<InstanceList> multiList;

	/**
         * <summary> Constructor for generating a partition.</summary>
         */
	public Partition() => multiList = new List<InstanceList>();

	/**
	 * <summary> Adds given instance list to the list of instance lists.</summary>
	 * <param name="list">Instance list to add.</param>
	 */
	public void Add(InstanceList list) => multiList.Add(list);

	/**
	 * <summary> Returns the size of the list of instance lists.</summary>
	 * <returns>The size of the list of instance lists.</returns>
	 */
	public int Size() => multiList.Count;

	/**
	 * <summary> Returns the corresponding instance list at given index of list of instance lists.</summary>
	 * <param name="index">Index of the instance list.</param>
	 * <returns>Instance list at given index of list of instance lists.</returns>
	 */
	public InstanceList Get(int index) => multiList[index];

	/**
	 * <summary> Returns the instances of the items at the list of instance lists.</summary>
	 * <returns>Instances of the items at the list of instance lists.</returns>
	 */
	public List<Instance.Instance>[] GetLists()
	{
		var result = new List<Instance.Instance>[multiList.Count];
		for (var i = 0; i < multiList.Count; i++)
			result[i] = multiList[i].GetInstances();
		return result;
	}
}