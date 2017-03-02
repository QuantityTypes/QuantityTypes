using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuantityTypes
{
    public partial struct Frequency
    {
        /// <summary>
        ///     Implements the operator /.
        /// </summary>
        /// <param name="x"> The x. </param>
        /// <param name="y"> The y. </param>
        /// <returns> The result of the operator. </returns>
        public static Time operator /(double x, Frequency y)
        {
            return new Time(x / y.value);
        }

    }
}
