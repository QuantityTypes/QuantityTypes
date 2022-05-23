// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewtonSoftJsonTests.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System;
    using System.Reflection;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class QuantityJsonConverterFactory : JsonConverterFactory
    {
        private readonly IUnitProvider unitProvider;

        public QuantityJsonConverterFactory(IUnitProvider unitProvider)
        {
            this.unitProvider = unitProvider;
        }

        public override bool CanConvert(Type typeToConvert)
        {
            var realType = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;
            return typeof(IQuantity).GetTypeInfo().IsAssignableFrom(realType);
        }

        public override JsonConverter CreateConverter(
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var realType = Nullable.GetUnderlyingType(typeToConvert) ?? typeToConvert;
            if (realType == typeToConvert)
            {
                JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                    typeof(QuantityJsonConverter<>).MakeGenericType(
                        new Type[] { realType }),
                    BindingFlags.Instance | BindingFlags.Public,
                    binder: null,
                    args: new object[] { this.unitProvider },
                    culture: null)!;

                return converter;
            }
            else
            {
                JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                  typeof(NullableQuantityJsonConverter<>).MakeGenericType(
                      new Type[] { realType }),
                  BindingFlags.Instance | BindingFlags.Public,
                  binder: null,
                  args: new object[] { this.unitProvider },
                  culture: null)!;

                return converter;
            }
        }
    }
}
