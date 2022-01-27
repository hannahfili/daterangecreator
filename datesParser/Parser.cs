using System;
using System.Collections.Generic;
using System.Text;

namespace datesParser
{
    public class Parser
    {
        public static string DefaultParse(string dateAsString1, string dateAsString2, bool monthFirst = false)
        {

            DateTime date1, date2;

            if (DateTime.TryParse(dateAsString1, out date1) && DateTime.TryParse(dateAsString2, out date2))
            {
                string dateFormat1 = DateFormat.CheckDateFormat(date1, dateAsString1, monthFirst);
                string dateFormat2 = DateFormat.CheckDateFormat(date2, dateAsString2, monthFirst);
                if (dateFormat1 == null || dateFormat2 == null) return null;
                string chosenFormat = dateFormat1;
                if (dateFormat1 != dateFormat2)
                {
                    if (dateFormat1.Contains("dd") || dateFormat1.Contains("MM")) chosenFormat = dateFormat1;
                    else chosenFormat = dateFormat2;
                }
                
                return DateRange.CreateFinalDateRange(date1, date2, chosenFormat, monthFirst);
            }
            return null;

        }
        public static string UnconventionalParse(string dateAsString1, string dateAsString2, bool monthFirst = false)
        {
            WeirdFormatValidator v = new WeirdFormatValidator(monthFirst);
            Weird freak1 = v.ValidateWeirdFormat(dateAsString1);
            Weird freak2 = v.ValidateWeirdFormat(dateAsString2);

            string format1, format2;
            try
            {
                format1 = freak1.Format;
                format2 = freak2.Format;
            }
            catch
            {
                return null;
            }

            if (format1 == null || format2 == null) return null;
            string chosenFormat = format2;
            if (format1 != format2)
            {
                if (format2.Contains("dd") || format2.Contains("MM")) chosenFormat = format2;
                else chosenFormat = format1;
            }
            

            return DateRange.CreateFinalDateRange(freak1.Date, freak2.Date, chosenFormat, monthFirst);
        }
    }
}
