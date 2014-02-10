namespace Units.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Represents a temporary current culture. When the object is disposed, the previous culture will be restored.
    /// </summary>
    public class CurrentCulture : IDisposable
    {
        /// <summary>
        /// The previous culture
        /// </summary>
        private CultureInfo previousCulture;

        /// <summary>
        /// Changes the current culture to the specified culture.
        /// </summary>
        /// <param name="cultureName">Name of the culture.</param>
        /// <returns>The disposable current culture object.</returns>
        public static IDisposable TemporaryChangeTo(string cultureName)
        {
            return TemporaryChangeTo(new CultureInfo(cultureName));
        }

        /// <summary>
        /// Changes to the specified culture.
        /// </summary>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns>The disposable current culture object.</returns>
        public static IDisposable TemporaryChangeTo(CultureInfo cultureInfo)
        {
            var cc = new CurrentCulture { previousCulture = Thread.CurrentThread.CurrentCulture };
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            System.Diagnostics.Debug.WriteLine("Set CurrentCulture to " + cultureInfo.Name);
            return cc;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            System.Diagnostics.Debug.WriteLine("Revert CurrentCulture to " + this.previousCulture.Name);
            Thread.CurrentThread.CurrentCulture = this.previousCulture;
        }
    }
}