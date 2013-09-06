﻿namespace Units.Tests
{
    using System;
    using System.Globalization;

    using Newtonsoft.Json;

    using Units;

    public class QuantityJsonConverter : JsonConverter
    {
        private readonly IUnitProvider unitProvider;

        public QuantityJsonConverter(IUnitProvider unitProvider)
        {
            this.unitProvider = unitProvider;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                serializer.Serialize(writer, null);
            }

            var q = value as IQuantity;
            serializer.Serialize(writer, q.ToString(null, CultureInfo.InvariantCulture));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = serializer.Deserialize<string>(reader);
            if (value == null)
            {
                return null;
            }

            IQuantity q;
            if (unitProvider.TryParse(objectType, value, CultureInfo.InvariantCulture, out q))
            {
                return q;
            }

            throw new FormatException("Cannot parse " + value + " to " + objectType);
        }

        public override bool CanConvert(Type objectType)
        {
            var realType = Nullable.GetUnderlyingType(objectType) ?? objectType;
            return typeof(IQuantity).IsAssignableFrom(realType);
        }
    }
}
