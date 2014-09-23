// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypographicLength.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Implements the operator /.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes
{
    public partial struct TypographicLength
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static TypographicResolution operator /(double x, TypographicLength y)
        {
            return new TypographicResolution(x / y.Value);
        }

        /// <summary>
        ///     Implements the operator *.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static double operator *(TypographicLength x, TypographicResolution y)
        {
            return x.value * y.Value;
        }
    }
}