namespace Classification.RandomForest;

public class SimpleDecisionTree
{
	public SimpleDecisionTree(int[][] xTrain, int[] yTrain, int minimumLeaves = 5)
	{
		this.xTrain = xTrain;
		this.yTrain = yTrain;
		this.minimumLeaves = minimumLeaves;
	}

	private readonly int[][] xTrain;
	private readonly int[] yTrain;
	private readonly int minimumLeaves;

	//TODO needs to be done
	public int[] Predict(int[][] xTest) => new int[] { 0 };
}