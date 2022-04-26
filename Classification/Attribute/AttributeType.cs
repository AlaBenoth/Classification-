namespace Classification.Attribute;

public enum AttributeType
{
	/**
         * Continuous Attribute
         */
	// ReSharper disable InconsistentNaming
	CONTINUOUS,
	/**
         * Discrete Attribute
         */
	DISCRETE,
	/**
         * Binary Attribute
         */
	BINARY,
	/**
         * Discrete Indexed Attribute is used to store the indices.
         */
	DISCRETE_INDEXED
}