// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultUnitProvider.cs" company="QuantityTypes">
//   Copyright (c) 2014 QuantityTypes contributors
// </copyright>
// <summary>
//   Represents a temporary unit provider. When the object is disposed, the previous unit provider will be restored.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace QuantityTypes.Tests
{
    using System;

    /// <summary>
    /// Represents a temporary unit provider. When the object is disposed, the previous unit provider will be restored.
    /// </summary>
    public class DefaultUnitProvider : IDisposable
    {
        /// <summary>
        /// The previous unit provider.
        /// </summary>
        private IUnitProvider previousProvider;

        /// <summary>
        /// Changes to the specified culture.
        /// </summary>
        /// <param name="provider">The unit provider.</param>
        /// <returns>The disposable default unit provider object.</returns>
        public static IDisposable TemporaryChangeTo(IUnitProvider provider)
        {
            var cc = new DefaultUnitProvider { previousProvider = UnitProvider.Default };
            UnitProvider.Default = provider;
            System.Diagnostics.Debug.WriteLine("Set UnitProvider to " + provider);
            return cc;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            System.Diagnostics.Debug.WriteLine("Revert UnitProvider to " + this.previousProvider);
            UnitProvider.Default = this.previousProvider;
        }
    }
}