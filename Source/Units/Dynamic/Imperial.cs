namespace Units.Dynamic
{
    /// <summary>
    /// Provides (British) Imperial units
    /// </summary>
    public static class Imperial
    {
        //// http://en.wikipedia.org/wiki/Imperial_units
        /// 
        public static DynamicQuantity Thou = 0.0254 * SI.Millimetre;
        public static DynamicQuantity Inch = 100 * Thou;
        public static DynamicQuantity Foot = 12 * Inch;
        public static DynamicQuantity Yard = 3 * Foot;
        public static DynamicQuantity Chain = 22 * Yard;
        public static DynamicQuantity Furlong = 10 * Chain;
        public static DynamicQuantity Mile = 8 * Furlong;
        public static DynamicQuantity League = 3 * Mile;

        public static DynamicQuantity Fathom = 6.08 * Foot;
        public static DynamicQuantity Cable = 100 * Fathom;
        public static DynamicQuantity NauticalMile = 10 * Cable;

        public static DynamicQuantity Link = 0.66d * Foot;
        public static DynamicQuantity Rod = 25 * Link;
        public static DynamicQuantity Chain2 = 4 * Rod;

        public static DynamicQuantity Gallon = 4.546 * SI.Litre;
    }
}