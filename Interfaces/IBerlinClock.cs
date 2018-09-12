using Clock;
using System.Collections.ObjectModel;

namespace BerlinClock
{
    /// <summary>
    /// Represents a Berlin clock. The clock is read from the top row to the bottom. 
    /// The top row of four red fields denote five full hours each, alongside the second row, 
    /// also of four red fields, which denote one full hour each, displaying the hour value in 24-hour format. 
    /// The third row consists of eleven yellow-and-red fields, which denote five full minutes each (the red ones also denoting 15, 30 and 45 minutes past), 
    /// and the bottom row has another four yellow fields, which mark one full minute each. 
    /// The round yellow light on top blinks to denote even- (when lit) or odd-numbered (when unlit) seconds.
    /// <see href="https://en.wikipedia.org/wiki/Mengenlehreuhr">Wikipedia article.</see>
    /// </summary>
    public interface IBerlinClock : IClock<Time>
    {
        #region Properties

        /// <summary>
        /// The round yellow light on top blinks to denote even- (when lit) or odd-numbered (when unlit) seconds.
        /// </summary>
        LampType Second { get; }

        /// <summary>
        /// The top row of four red fields denote five full hours each.
        /// </summary>
        ReadOnlyCollection<LampType> Hour1 { get; }

        /// <summary>
        /// The second row of four red fields denote the full hour each.
        /// </summary>
        ReadOnlyCollection<LampType> Hour2 { get; }

        /// <summary>
        ///  The third row consists of eleven yellow-and-red fields, which denote five full minutes each.
        ///  (the red ones also denoting 15, 30 and 45 minutes past)
        /// </summary>
        ReadOnlyCollection<LampType> Minute1 { get; }

        /// <summary>
        /// Thw last row consists of four yellow fields, which mark one full minute each.
        /// </summary>
        ReadOnlyCollection<LampType> Minute2 { get; }

        #endregion
    }
}
