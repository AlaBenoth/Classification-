namespace Classification.RandomForest;

public class SimpleRandomForest
{
	public SimpleRandomForest(int[][] xTrain, int[] yTrain, int treeCount = 10, int sampleSize = 0)
	{
		this.xTrain = xTrain;
		this.yTrain = yTrain;
		this.treeCount = treeCount;
		this.sampleSize = sampleSize == 0
			? yTrain.Length
			: sampleSize;
		trees = CreateTrees();
	}

	private readonly int[][] xTrain;
	private readonly int[] yTrain;
	private readonly int treeCount;
	private readonly int sampleSize;
	private readonly List<SimpleDecisionTree> trees;

	private List<SimpleDecisionTree> CreateTrees()
	{
		var treeList = new List<SimpleDecisionTree>();
		for (var index = 0; index < treeCount; index++)
			treeList.Add(CreateTree());
		return treeList;
	}

	private SimpleDecisionTree CreateTree()
	{
		var selectedXTrain = new List<int[]>();
		var selectedYTrain = new List<int>();
		var random = new Random();
		for (var innerIndex = 0; innerIndex < sampleSize; innerIndex++)
		{
			selectedXTrain.Add(xTrain[random.Next(yTrain.Length)]);
			selectedYTrain.Add(yTrain[random.Next(yTrain.Length)]);
		}
		return new SimpleDecisionTree(selectedXTrain.ToArray(), selectedYTrain.ToArray());
	}

	public int[] Predict(int[][] xTest)
	{
		var percentages = new List<int>();
		var predictions = new int[][] { };
		var counter = 0;
		foreach (var tree in trees)
		{
			predictions[counter] = tree.Predict(xTest);
			counter++;
		}
		for (var index = 0; index < xTest[index].Count(); index++)
		{
			var i = index;
			percentages.Add(Enumerable.Range(0, xTest[index].Length).Select(x => xTest[x][i]).Average() >
				0.5
					? 1
					: 0);
		}
		return percentages.ToArray();
	}
}