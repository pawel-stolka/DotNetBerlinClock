using BerlinClock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private StringBuilder builder;
        private ParseTime givenTime;

        public TimeConverter()
        {
            builder = new StringBuilder();
        }

        public string convertTime(string aTime)
        {
            givenTime = new ParseTime(aTime);

            var firstRow = givenTime.Hours / 5;
            var secondRow = givenTime.Hours % 5;

            MakeSeconds();

            MakeHours(firstRow);

            MakeHours(secondRow);

            MakeFiveMinutes();

            MakeOneMinutes();

            return Build();
        }

        private void MakeSeconds()
        {
            var condition = givenTime.Seconds % 2 == 0;
            var result = YellowOrOff(condition);

            builder.AppendLine(result);
        }

        private void MakeHours(int expression)
        {
            string result = default;
            var columns = 4;

            for (int i = 0; i < columns; i++)
            {
                var yesOrNo = i < expression;
                var colorON = RedOrOff(yesOrNo);

                result += PickColor(yesOrNo, colorON);
            }

            builder.AppendLine(result);
        }

        private void MakeFiveMinutes()
        {
            var condition = givenTime.Minutes / 5;
            var columns = 11;

            string result = default;

            for (int i = 1; i <= columns; i++)
            {
                var yesOrNo = i - 1 < condition;
                var additional = i % 3 == 0;
                var toAdd = PickColor(yesOrNo, YellowOrRed(additional));

                result += toAdd;
            }

            builder.AppendLine(result);

        }

        private void MakeOneMinutes()
        {
            var condition = givenTime.Minutes % 5;
            string result = default;
            var columns = 4;


            for (int i = 0; i < columns; i++)
            {
                var yesOrNo = i < condition;
                var toAdd = YellowOrOff(yesOrNo);

                result += toAdd;
            }

            builder.Append(result);
        }



        private string PickColor(bool condition, string whenON)
            => condition
            ? whenON
            : Light.Off;

        private string RedOrOff(bool condition)
            => condition
            ? Light.Red
            : Light.Off;

        private string YellowOrOff(bool condition)
            => condition
            ? Light.Yellow
            : Light.Off;

        private string YellowOrRed(bool condition)
            => condition
            ? Light.Red
            : Light.Yellow;


        private string Build()
            => builder.ToString();
    }
}
