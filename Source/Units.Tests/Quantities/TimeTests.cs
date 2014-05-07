namespace Units.Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Provides unit test for the <see cref="Time" /> class.
    /// </summary>
    public class TimeTests
    {
        /// <summary>
        /// Tests the product of <see cref="Time" /> and <see cref="Time" />.
        /// </summary>
        [Test]
        public void TimeTimeProduct()
        {
            var a = 9.81 * Length.Metre / (Time.Second * Time.Second);
            Assert.AreEqual(9.81 * Acceleration.MetrePerSecondSquared, a);
        }

        /// <summary>
        /// Tests the second power of <see cref="Time" />.
        /// </summary>
        [Test]
        public void SecondPowerOfTime()
        {
            var a = 9.81 * Length.Metre / (Time.Second ^ 2);
            Assert.AreEqual(9.81 * Acceleration.MetrePerSecondSquared, a);
        }
    }
}