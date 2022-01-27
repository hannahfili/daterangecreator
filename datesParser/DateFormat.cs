using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace datesParser
{
    public class DateFormat
    {
        
        public static string CheckDateFormat(DateTime date, string dateAsString, bool monthFirst=false)
        {
            char separator = Helper.CheckSeparator(dateAsString);
            if (separator == '*') return null;
            bool spacesOccur = false;
            if (dateAsString.Contains(" ")) spacesOccur = true;
            string dateWithoutSpaces = String.Concat(dateAsString.Where(c => !Char.IsWhiteSpace(c)));
            string[] pieces = Helper.DivideDateIntoParts(dateWithoutSpaces, separator);
            string format = "";

            if (pieces == null) return null;

            string firstPart = pieces[0];
            string secondPart = pieces[1];
            string lastPart = pieces[2];

            Data dataset = new Data(firstPart, date, spacesOccur, separator);

            PartialFormat firstPartFormat = DatePart.CheckFirstPart(dataset, monthFirst);
            dataset.Part = secondPart;
            PartialFormat secondPartFormat = DatePart.CheckSecondPart(dataset, firstPartFormat);
            dataset.Part = lastPart;
            PartialFormat lastPartFormat = DatePart.CheckLastPart(dataset, firstPartFormat, secondPartFormat);
            if (lastPartFormat == null) return null;

            format = string.Concat(firstPartFormat.formatStyle, secondPartFormat.formatStyle, lastPartFormat.formatStyle);
            
            if (spacesOccur)
            {
                if (dateAsString[dateAsString.Length - 1] != separator) format = format.Substring(0, format.Length - 2);
                else format = format.Substring(0, format.Length - 1);
            }
            else
            {
                if (dateAsString[dateAsString.Length - 1] != separator) format = format.Substring(0, format.Length - 1);
            }

            
            return format;

        }
        
        
    }
}
