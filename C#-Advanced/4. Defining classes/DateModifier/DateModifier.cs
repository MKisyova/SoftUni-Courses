using System;

namespace DayDifference
{
    public static class DateModifier
    {
        public static int CalculateDateDifference(string firstDate, string secondDate)
        {

            DateTime dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);

            int days = Math.Abs((dateOne - dateTwo).Days);

            return days;
        }
    }
}
