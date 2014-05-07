// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Imperial.cs" company="Units.NET">
//   The MIT License (MIT)
//   
//   Copyright (c) 2012 Oystein Bjorke
//   
//   Permission is hereby granted, free of charge, to any person obtaining a
//   copy of this software and associated documentation files (the
//   "Software"), to deal in the Software without restriction, including
//   without limitation the rights to use, copy, modify, merge, publish,
//   distribute, sublicense, and/or sell copies of the Software, and to
//   permit persons to whom the Software is furnished to do so, subject to
//   the following conditions:
//   
//   The above copyright notice and this permission notice shall be included
//   in all copies or substantial portions of the Software.
//   
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
//   OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//   MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//   IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//   CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//   TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//   SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary>
//   Provides (British) Imperial units
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units.Dynamic
{
    /// <summary>
    /// Provides (British) Imperial units
    /// </summary>
    public static class Imperial
    {
        //// http://en.wikipedia.org/wiki/Imperial_units

        /// <summary>
        /// The Thou length unit.
        /// </summary>
        public static readonly DynamicQuantity Thou = 0.0254 * SI.Millimetre;

        /// <summary>
        /// The Inch length unit.
        /// </summary>
        public static readonly DynamicQuantity Inch = 100 * Thou;

        /// <summary>
        /// The Foot length unit.
        /// </summary>
        public static readonly DynamicQuantity Foot = 12 * Inch;

        /// <summary>
        /// The Yard length unit.
        /// </summary>
        public static readonly DynamicQuantity Yard = 3 * Foot;

        /// <summary>
        /// The Chain length unit.
        /// </summary>
        public static readonly DynamicQuantity Chain = 22 * Yard;

        /// <summary>
        /// The Furlong length unit.
        /// </summary>
        public static readonly DynamicQuantity Furlong = 10 * Chain;

        /// <summary>
        /// The Mile length unit.
        /// </summary>
        public static readonly DynamicQuantity Mile = 8 * Furlong;

        /// <summary>
        /// The League length unit.
        /// </summary>
        public static readonly DynamicQuantity League = 3 * Mile;

        /// <summary>
        /// The Fathom length unit.
        /// </summary>
        public static readonly DynamicQuantity Fathom = 6.08 * Foot;

        /// <summary>
        /// The Cable length unit.
        /// </summary>
        public static readonly DynamicQuantity Cable = 100 * Fathom;

        /// <summary>
        /// The Nautical mile length unit.
        /// </summary>
        public static readonly DynamicQuantity NauticalMile = 10 * Cable;

        /// <summary>
        /// The Link length unit.
        /// </summary>
        public static readonly DynamicQuantity Link = 0.66d * Foot;

        /// <summary>
        /// The Rod length unit.
        /// </summary>
        public static readonly DynamicQuantity Rod = 25 * Link;

        /// <summary>
        /// The Chain length unit.
        /// </summary>
        public static readonly DynamicQuantity Chain2 = 4 * Rod;

        /// <summary>
        /// The Gallon volume unit.
        /// </summary>
        public static readonly DynamicQuantity Gallon = 4.546 * SI.Litre;
    }
}