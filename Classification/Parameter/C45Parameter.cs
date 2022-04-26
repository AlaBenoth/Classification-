namespace Classification.Parameter;

public class C45Parameter : Parameter
{
	private readonly double crossValidationRatio;
	private readonly bool prune;

	/**
	 * <summary> Parameters of the C4.5 univariate decision tree classifier.</summary>
	 * <param name="seed">                Seed is used for random number generation.</param>
	 * <param name="prune">               Boolean value for prune.</param>
	 * <param name="crossValidationRatio">Double value for cross crossValidationRatio ratio.</param>
	 */
	public C45Parameter(int seed, bool prune, double crossValidationRatio) : base(seed)
	{
		this.prune = prune;
		this.crossValidationRatio = crossValidationRatio;
	}

	/**
	 * <summary> Accessor for the prune.</summary>
	 * <returns>Prune.</returns>
	 */
	public bool IsPrune() => prune;

	/**
	 * <summary> Accessor for the crossValidationRatio.</summary>
	 * <returns>crossValidationRatio.</returns>
	 */
	public double GetCrossValidationRatio() => crossValidationRatio;
}