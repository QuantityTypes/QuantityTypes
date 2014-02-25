// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultUnitProvider.cs" company="Units.NET">
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
//   Represents a temporary unit provider. When the object is disposed, the previous unit provider will be restored.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Units.Tests
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