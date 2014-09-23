// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShortLength.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Forte
{
    public partial struct ShortLength
    {
        public static implicit operator Length(ShortLength l)
        {
            return l.value * Length.Meter;
        }
    }

}