namespace Units.Dynamic
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Reflection;

    public class DynamicUnitProvider : IDynamicUnitProvider
    {
        private IFormatProvider provider;

        public DynamicUnitProvider(IFormatProvider provider = null, params Type[] types)
        {
            this.provider = provider;
            foreach (var type in types)
                this.Register(type);
        }

        Dictionary<string, DynamicQuantity> units = new Dictionary<string, DynamicQuantity>();
        Dictionary<Dimensions, string> displayUnits = new Dictionary<Dimensions, string>();

        public void Register(string s, DynamicQuantity q)
        {
            this.units[s] = q;
        }

        public bool TryGetUnit(string s, out DynamicQuantity q)
        {
            return this.units.TryGetValue(s, out q);
        }

        public bool TryGetDisplayUnit(Dimensions d, out string symbol, out DynamicQuantity q)
        {
            if (this.displayUnits.TryGetValue(d, out symbol))
            {
                if (this.units.TryGetValue(symbol, out q))
                {
                    return true;
                }
            }

            symbol = null;
            q = default(DynamicQuantity);
            return false;
        }

        public object GetFormat(Type formatType)
        {
            var p = this.provider ?? CultureInfo.CurrentCulture;
            return p.GetFormat(formatType);
        }

        public void Register(Type type)
        {
            var props = type.GetProperties(BindingFlags.Static | BindingFlags.Public);
            foreach (var p in props)
            {
                var q = (DynamicQuantity)p.GetValue(null, null);
                foreach (UnitAttribute ua in p.GetCustomAttributes(typeof(UnitAttribute), false))
                {
                    this.Register(ua.Symbol, q);
                    if (ua.IsDefaultDisplayUnit)
                    {
                        this.SetDisplayUnit(ua.Symbol, q);
                    }
                }
            }
        }

        public void SetDisplayUnit(string symbol, DynamicQuantity dynamicQuantity)
        {
            this.displayUnits[dynamicQuantity.Dimensions] = symbol;
        }
    }
}