namespace Units.Dynamic
{
    using System;

    public interface IDynamicUnitProvider : IFormatProvider
    {
        bool TryGetUnit(string s, out DynamicQuantity q);

        bool TryGetDisplayUnit(Dimensions d, out string symbol, out DynamicQuantity q);
    }
}