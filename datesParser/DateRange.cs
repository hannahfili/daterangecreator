using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace datesParser
{
    public class DateRange
    {
        public static string CreateFinalDateRange(DateTime date1, DateTime date2, string dateFormat, bool monthFirst)
        {
            char separator = Helper.CheckSeparator(dateFormat);
            int firstSeparatorIndex = dateFormat.IndexOf(separator);
            string formatStringAfterFirstSeparator = dateFormat.Substring(firstSeparatorIndex + 1);
            int secondSeparatorIndex = formatStringAfterFirstSeparator.IndexOf(separator);

            if (DateTime.Compare(date1, date2) >= 0) return null;
           
            if (dateFormat[0] == 'd') return PLRange(date1, date2, dateFormat, separator);
            else return string.Concat(date1.ToString(dateFormat, CultureInfo.InvariantCulture), " - ", date2.ToString(dateFormat, CultureInfo.InvariantCulture));

        }
        public static string PLRange(DateTime date1, DateTime date2, string dateFormat, char separator)
        {
            int firstSeparatorIndex = dateFormat.IndexOf(separator);
            string formatStringAfterFirstSeparator = dateFormat.Substring(firstSeparatorIndex + 1);
            int secondSeparatorIndex = formatStringAfterFirstSeparator.IndexOf(separator);
            int valueToAdd = 0;
            if (date1.Year == date2.Year && date1.Month == date2.Month)
            {
                string format = dateFormat.Substring(0, firstSeparatorIndex);
                return string.Concat(date1.ToString(format, CultureInfo.InvariantCulture),
                    " - ", date2.ToString(dateFormat, CultureInfo.InvariantCulture));
            }
            else if (date1.Year == date2.Year)
            {
                if (separator == '/') valueToAdd = 1; else valueToAdd = 2;
                    return string.Concat(date1.ToString(dateFormat.Substring(0, firstSeparatorIndex + secondSeparatorIndex + valueToAdd), CultureInfo.InvariantCulture),
                    " - ", date2.ToString(dateFormat, CultureInfo.InvariantCulture));
            }
            else
            {
                return string.Concat(date1.ToString(dateFormat, CultureInfo.InvariantCulture), " - ", date2.ToString(dateFormat, CultureInfo.InvariantCulture));
            }
        }
        public static string GenerateDateRange(string dates)
        {
            string[] datesSplitted = Helper.ValidateInput(dates);
            if (datesSplitted == null) return null;

            string date1 = datesSplitted[0];
            string date2 = datesSplitted[1];


            bool monthFirst = false;
            if (CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern[0] == 'M') monthFirst = true;
            string defaultOutput = Parser.DefaultParse(date1, date2, monthFirst);
            if (defaultOutput != null) return defaultOutput;
            else
            {
                string unconventionalOutput = Parser.UnconventionalParse(date1, date2, monthFirst);
                if (unconventionalOutput != null) return unconventionalOutput;
            }
            return null;
        }
    }
}
