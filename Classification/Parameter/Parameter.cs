namespace Classification.Parameter;

public class Parameter
{
	private readonly int seed;

	/**
	 * <summary>Constructor of {@link Parameter} class which assigns given seed value to seed.</summary>
	 * <param name="seed">Seed is used for random number generation.</param>
	 */
	public Parameter(int seed) => this.seed = seed;

	/**
	 * <summary>Accessor for the seed.</summary>
	 * <returns>The seed.</returns>
	 */
	public int GetSeed() => seed;
}