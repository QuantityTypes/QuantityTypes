namespace QuantityTypes
{
    using System;

    /// <summary>
    ///     Provides extension methods related to time.
    /// </summary>
    public static class TimeExtensions
    {
        /// <summary>
        /// Generates a <see cref="Time" /> instance from a <see cref="TimeSpan" /> object.
        /// </summary>
        /// <param name="timeSpan">The time span to convert.</param>
        /// <returns>A <see cref="Time" />.</returns>
        public static Time ToQuantity(this TimeSpan timeSpan)
        {
            return new Time(timeSpan.TotalSeconds);
        }

        /// <summary>
        /// Generates an <see cref="TimeSpan" /> instance of a <see cref="Time" /> quantity.
        /// </summary>
        /// <param name="time">The time to convert.</param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(this Time time)
        {
            return TimeSpan.FromSeconds(time.Value);
        }
    }
}