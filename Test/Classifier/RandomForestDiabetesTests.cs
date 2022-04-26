using Classification.Attribute;
using Classification.Classifier;
using Classification.DataSet;
using Classification.Parameter;
using NUnit.Framework;

namespace Classification.Tests.Classifier;

public class RandomForestDiabetesTests
{
	[SetUp]
	public void CreateClassifier()
	{
		randomForest = new RandomForest();
		var attributeTypes = new List<AttributeType>();
		for (var i = 0; i < 19; i++)
			attributeTypes.Add(AttributeType.DISCRETE);
		var dataDefinition = new DataDefinition(attributeTypes);
		data = new Classification.DataSet.DataSet(dataDefinition, ",",
			"../../../datasets/diabetes.data");
		randomForest.Train(data.SplitDataSet(70), new RandomForestParameter(5, 100, 10));
	}

	private RandomForest randomForest;
	private Classification.DataSet.DataSet data;

	[TestCase(10, 0, "1")]
	[TestCase(15, 1, "0")]
	[TestCase(20, 2, "0")]
	[TestCase(25, 5, "1")]
	public void ValidateModelWithTwentyPercentOfData(int percentage, int index, string expected)
	{
		var accuracy = 100 * (1 - randomForest.Test(data.SplitDataSet(percentage)).GetErrorRate());
		Assert.That(accuracy, Is.GreaterThanOrEqualTo(80));
		Console.WriteLine(accuracy);
		var prediction = randomForest.GetModel().Predict(data.GetInstanceList().Get(index));
		Assert.That(prediction, Is.EqualTo(expected));
	}
}