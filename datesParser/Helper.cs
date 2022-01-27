using System;
using System.Collections.Generic;
using System.Text;

namespace datesParser
{
    public class Helper
    {
        public static bool LastCharIsSeparator(string date, char separator)
        {
            if (date[date.Length - 1] == separator) return true;
            return false;
        }
        public static string[] DivideDateIntoParts(string dateWithoutSpaces, char separator)
        {
            string[] pieces;
            try
            {
                int firstSeparatorIndex = dateWithoutSpaces.IndexOf(separator);
                string firstPart = dateWithoutSpaces.Substring(0, firstSeparatorIndex);
                string dateAsStringFromFirstSeparator = dateWithoutSpaces.Substring(firstSeparatorIndex + 1);

                int secondSeparatorIndex = dateAsStringFromFirstSeparator.IndexOf(separator);
                string secondPart = dateAsStringFromFirstSeparator.Substring(0, secondSeparatorIndex);
                string dateAsStringFromSecondSeparator = dateAsStringFromFirstSeparator.Substring(secondSeparatorIndex + 1);

                int thirdSeparatorIndex;
                string lastPart = "";
                if (LastCharIsSeparator(dateWithoutSpaces, separator))
                {
                    thirdSeparatorIndex = dateAsStringFromSecondSeparator.IndexOf(separator);
                    lastPart = dateAsStringFromSecondSeparator.Substring(0, thirdSeparatorIndex);
                }
                else lastPart = dateAsStringFromSecondSeparator;
                pieces = new string[3] { firstPart, secondPart, lastPart };

                
                return pieces;

            }
            catch (Exception)
            {
                
            }
            return null;
        }
        public static char CheckSeparator(string date)
        {
            if (date.Contains('.')) return '.';
            else if (date.Contains('-')) return '-';
            else if (date.Contains('/')) return '/';
            return '*';
        }
        public static int FindThirdSpaceIndex(string dates)
        {
            int numberOfSpaces = 0;
            for (int i = 0; i < dates.Length; i++)
            {
                if (dates[i] == ' ') numberOfSpaces++;
                if (numberOfSpaces == 3)
                {
                    return i;
                }
            }
            return 0;
        }
        public static string[] ValidateInput(string dates)
        {
            if (string.IsNullOrEmpty(dates)) return null;
            if (!dates.Contains(' ')) return null;

            dates = dates.Trim();
            int numberOfSpaces = 0;
            for (int i = 0; i < dates.Length; i++)
            {
                if (dates[i] == ' ') numberOfSpaces++;
            }

            int indexOfSpace = 0;
            if (numberOfSpaces == 1) indexOfSpace = dates.IndexOf(" ");
            else indexOfSpace = FindThirdSpaceIndex(dates);

            string date1 = "";
            string date2 = "";
            try
            {
                date1 = dates.Substring(0, indexOfSpace);
                date2 = dates.Substring(indexOfSpace + 1);
            }
            catch (Exception)
            {
                return null;
            }

            return new string[] { date1, date2 };
        }
        
        
    }
}
