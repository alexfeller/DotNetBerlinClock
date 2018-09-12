using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    /// <inheritdoc/>
    public class BerlinClock : IBerlinClock
    {
        #region Constructor

        /// <summary>
        ///  Initializes a new instance of the BerlinClock class.
        /// </summary>
        public BerlinClock()
        {
            Second = LampType.White;

            _hour1 = new LampType[4];
            _hour2 = new LampType[4];

            _minute1 = new LampType[11];
            _minute2 = new LampType[4];

            Reset();

            _colorIdentifiers = new Dictionary<LampType, string>()
            {
                { LampType.Red, "R" },
                { LampType.Yellow, "Y" },
                { LampType.White, "O" }
            };
        }

        #endregion

        #region Public members

        /// <inheritdoc/>
        public void Set(Time time)
        {
            Reset();

            SetSecond(time.Second);

            SetHour1(time.Hour);
            SetHour2(time.Hour);

            SetMinute1(time.Minute);
            SetMinute2(time.Minute);
        }

        /// <summary>
        /// Convert clock time to its string representation.
        /// </summary>
        /// <returns>String representation of the clock time.</returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            string newLine = Environment.NewLine;

            stringBuilder.Append(GetColorIdentifier(Second));
            stringBuilder.Append(newLine);

            var hour1 = _hour1.Select(lamp => GetColorIdentifier(lamp));

            stringBuilder.Append(String.Join("", hour1));
            stringBuilder.Append(newLine);

            var hour2 = _hour2.Select(lamp => GetColorIdentifier(lamp));

            stringBuilder.Append(String.Join("", hour2));
            stringBuilder.Append(newLine);

            var minute1 = _minute1.Select(lamp => GetColorIdentifier(lamp));

            stringBuilder.Append(String.Join("", minute1));
            stringBuilder.Append(newLine);

            var minute2 = _minute2.Select(lamp => GetColorIdentifier(lamp));

            stringBuilder.Append(String.Join("", minute2));

            return stringBuilder.ToString();
        }

        #endregion

        #region Private members

        private void Reset()
        {
            Second = LampType.White;

            Reset(_hour1);
            Reset(_hour2);

            Reset(_minute1);
            Reset(_minute2);
        }

        private void Reset(LampType[] lamps)
        {
            for (int lamp = 0; lamp < lamps.Length; lamp++)
            {
                lamps[lamp] = LampType.White;
            }
        }

        private void SetSecond(int second)
        {
            Second = (second % 2 == 0) ? LampType.Yellow : LampType.White;
        }

        private void SetHour1(int hour)
        {
            int lamps = hour / 5;

            for (int lamp = 0; lamp < lamps; lamp++)
            {
                _hour1[lamp] = LampType.Red;
            }
        }

        private void SetHour2(int hour)
        {
            int lamps = hour % 5;

            for (int lamp = 0; lamp < lamps; lamp++)
            {
                _hour2[lamp] = LampType.Red;
            }
        }

        private void SetMinute1(int minute)
        {
            int lamps = minute / 5;

            for (int lamp = 0; lamp < lamps; lamp++)
            {
                _minute1[lamp] = LampType.Yellow;

                if ((lamp + 1) % 3 == 0)
                {
                    _minute1[lamp] = LampType.Red;
                }
            }
        }

        private void SetMinute2(int minute)
        {
            int lamps = minute % 5;

            for (int lamp = 0; lamp < lamps; lamp++)
            {
                _minute2[lamp] = LampType.Yellow;
            }
        }

        private string GetColorIdentifier(LampType lamp)
        {
            return _colorIdentifiers[lamp];
        }

        #endregion

        #region Public properties

        /// <inheritdoc/>
        public LampType Second { get; private set; }

        /// <inheritdoc />
        public ReadOnlyCollection<LampType> Hour1
        {
            get
            {
                return Array.AsReadOnly(_hour1);
            }
        }

        /// <inheritdoc/>
        public ReadOnlyCollection<LampType> Hour2
        {
            get
            {
                return Array.AsReadOnly(_hour2);
            }
        }

        /// <inheritdoc/>
        public ReadOnlyCollection<LampType> Minute1
        {
            get
            {
                return Array.AsReadOnly(_minute1);
            }
        }

        /// <inheritdoc/>
        public ReadOnlyCollection<LampType> Minute2
        {
            get
            {
                return Array.AsReadOnly(_minute2);
            }
        }

        #endregion

        #region Fields

        private readonly Dictionary<LampType, string> _colorIdentifiers;

        private readonly LampType[] _hour1;
        private readonly LampType[] _hour2;

        private readonly LampType[] _minute1;
        private readonly LampType[] _minute2;

        #endregion
    }
}
