namespace Classification.StatisticalTest;

public class StatisticalTestResult
{
	private readonly bool onlyTwoTailed;
	private readonly double pValue;

	public StatisticalTestResult(double pValue, bool onlyTwoTailed)
	{
		this.pValue = pValue;
		this.onlyTwoTailed = onlyTwoTailed;
	}

	public StatisticalTestResultType OneTailed(double alpha)
	{
		if (pValue < alpha)
			return StatisticalTestResultType.Reject;
		return StatisticalTestResultType.FailedToReject;
	}

	public StatisticalTestResultType TwoTailed(double alpha)
	{
		if (onlyTwoTailed)
		{
			if (pValue < alpha)
				return StatisticalTestResultType.Reject;
			return StatisticalTestResultType.FailedToReject;
		}
		if (pValue < alpha / 2 || pValue > 1 - alpha / 2)
			return StatisticalTestResultType.Reject;
		return StatisticalTestResultType.FailedToReject;
	}

	public double GetPValue() => pValue;
}