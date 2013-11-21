namespace Units.Dynamic
{
    using System;
    using System.Text;

    public struct Dimensions : IEquatable<Dimensions>
    {
        // http://en.wikipedia.org/wiki/ISO_80000
        // http://en.wikipedia.org/wiki/SI_base_unit
        // http://en.wikipedia.org/wiki/International_System_of_Units
        // http://en.wikipedia.org/wiki/Dimensional_analysis
        public short Length
        {
            get
            {
                return length;
            }
        }
        public short Time
        {
            get
            {
                return time;
            }
        }
        private short mass;
        private short length;
        private short time;
        private short current;
        private short temperature;
        private short amountOfSubstance;
        private short luminousIntensity;

        public Dimensions(int mass = 0, int length = 0, int time = 0, int current = 0, int temperature = 0, int amount = 0, int intensity = 0)
            : this((short)mass, (short)length, (short)time, (short)current, (short)temperature, (short)amount, (short)intensity)
        {
        }

        public Dimensions(short mass, short length, short time, short current = 0, short temperature = 0, short amount = 0, short intensity = 0)
        {
            this.mass = mass;
            this.length = length;
            this.time = time;
            this.current = current;
            this.temperature = temperature;
            this.amountOfSubstance = amount;
            this.luminousIntensity = intensity;
        }

        public static Dimensions operator +(Dimensions q1, Dimensions q2)
        {
            return new Dimensions(q1.mass + q2.mass, q1.length + q2.length, q1.time + q2.time, q1.current + q2.current, q1.temperature + q2.temperature, q1.amountOfSubstance + q2.amountOfSubstance, q1.luminousIntensity + q1.luminousIntensity);
        }

        public static Dimensions operator -(Dimensions q1, Dimensions q2)
        {
            return new Dimensions(q1.mass - q2.mass, q1.length - q2.length, q1.time - q2.time, q1.current - q2.current, q1.temperature - q2.temperature, q1.amountOfSubstance - q2.amountOfSubstance, q1.luminousIntensity - q1.luminousIntensity);
        }

        public bool Equals(Dimensions other)
        {
            return other.mass == this.mass && other.length == this.length && other.time == this.time && other.current == this.current && other.temperature == this.temperature && other.amountOfSubstance == this.amountOfSubstance && other.luminousIntensity == this.luminousIntensity;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            if (this.mass != 0)
            {
                if (this.mass > 1 || this.mass < 0) sb.AppendFormat("M^{0}", this.mass);
                else sb.Append("M");
            }

            if (this.length != 0)
            {
                if (sb.Length > 0) sb.Append("*");
                if (this.length > 1 || this.length < 0) sb.AppendFormat("L^{0}", this.length);
                else sb.Append("L");
            }

            if (this.time != 0)
            {
                if (sb.Length > 0) sb.Append("*");
                if (this.time > 1 || this.time < 0) sb.AppendFormat("T^{0}", this.time);
                else sb.Append("T");
            }

            if (this.current != 0)
            {
                if (sb.Length > 0) sb.Append("*");
                if (this.time > 1 || this.time < 0) sb.AppendFormat("I^{0}", this.time);
                else sb.Append("I");
            }

            if (this.temperature != 0)
            {
                if (sb.Length > 0) sb.Append("*");
                if (this.time > 1 || this.time < 0) sb.AppendFormat("Θ^{0}", this.time);
                else sb.Append("Θ");
            }

            if (this.amountOfSubstance != 0)
            {
                if (sb.Length > 0) sb.Append("*");
                if (this.time > 1 || this.time < 0) sb.AppendFormat("N^{0}", this.time);
                else sb.Append("N");
            }

            if (this.luminousIntensity != 0)
            {
                if (sb.Length > 0) sb.Append("*");
                if (this.time > 1 || this.time < 0) sb.AppendFormat("J^{0}", this.time);
                else sb.Append("J");
            }

            return sb.ToString();
        }
    }
}