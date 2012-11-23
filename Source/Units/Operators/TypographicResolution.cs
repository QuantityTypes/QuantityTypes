namespace Units
{
    public partial struct TypographicResolution
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static TypographicLength operator /(double x, TypographicResolution y)
        {
            return new TypographicLength(x / y.Value);
        }

        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static double operator *(TypographicResolution x, TypographicLength y)
        {
            return x.Value * y.Value;
        }

    }
}