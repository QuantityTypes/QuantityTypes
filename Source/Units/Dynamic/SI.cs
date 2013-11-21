namespace Units.Dynamic
{
    using Units;

    public static class SI
    {
        [Unit("kg")]
        public static DynamicQuantity Kilogram
        {
            get
            {
                return kilogram;
            }
        }

        [Unit("m", true)]
        public static DynamicQuantity Metre
        {
            get
            {
                return metre;
            }
        }

        [Unit("m/s", true)]
        public static DynamicQuantity MetrePerSecond
        {
            get
            {
                return metrePerSecond;
            }
        }

        [Unit("km/h")]
        public static DynamicQuantity KilometrePerHour
        {
            get
            {
                return kilometrePerHour;
            }
        }

        public static DynamicQuantity kilogram = new DynamicQuantity(1, new Dimensions(1, 0, 0));
        public static DynamicQuantity metre = new DynamicQuantity(1, new Dimensions(0, 1, 0));
        public static DynamicQuantity Kilometre = 1000 * Metre;
        public static DynamicQuantity Centrimetre = 0.01 * Metre;
        public static DynamicQuantity Millimetre = 0.001 * Metre;

        public static DynamicQuantity Second = new DynamicQuantity(1, new Dimensions(0, 0, 1));
        public static DynamicQuantity Minute = 60 * Second;
        public static DynamicQuantity Hour = 60 * Minute;

        public static DynamicQuantity metrePerSecond = Metre / Second;
        public static DynamicQuantity kilometrePerHour = Kilometre / Hour;
        public static DynamicQuantity MetrePerSecondSquared = Metre / (Second * Second);

        public static DynamicQuantity SquareMetre = new DynamicQuantity(1, new Dimensions(0, 2, 0));
        public static DynamicQuantity CubicMetre = new DynamicQuantity(1, new Dimensions(0, 3, 0));
        public static DynamicQuantity CubicDecimetre = new DynamicQuantity(0.001, new Dimensions(0, 3, 0));
        public static DynamicQuantity Litre = CubicDecimetre;
    }
}