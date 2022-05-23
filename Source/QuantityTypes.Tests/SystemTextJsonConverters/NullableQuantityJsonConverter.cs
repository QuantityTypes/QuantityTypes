// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewtonSoftJsonTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System;
    using System.Globalization;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class NullableQuantityJsonConverter<T> : JsonConverter<T?> where T : struct
    {
        private readonly IUnitProvider unitProvider;

        public NullableQuantityJsonConverter(IUnitProvider unitProvider)
        {
            this.unitProvider = unitProvider;
        }

        public override void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options)
        {
            var q = value as IQuantity;
            if (q == null)
            {
                writer.WriteNullValue();
                return;
            }

            writer.WriteStringValue(q.ToString(null, CultureInfo.InvariantCulture));
        }

        public override T? Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value == null)
            {
                return null;
            }

            IQuantity q;
            if (this.unitProvider.TryParse(type, value, CultureInfo.InvariantCulture, out q))
            {
                return (T)q;
            }

            throw new FormatException("Cannot parse " + value + " to " + type + "?");
        }
    }
}
