namespace QuantityTypes.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Test base class.
    /// </summary>
    public class Tests
    {
        protected static void AssertAreEqual<T>(T expected, T actual, double relativeTolerance = 1e-6, string message = null) where T : IQuantity
        {
            var tolerance = (T)expected.MultiplyBy(relativeTolerance);
            AssertAreEqual(expected, actual, tolerance, message);
        }

        protected static void AssertAreEqual<T>(T expected, T actual, T tolerance, string message = null) where T : IQuantity
        {
            Assert.That(actual, QuantityIs.EqualTo(expected).Within(tolerance), message);
        }
    }
}