using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;

namespace datesParser
{
    public class WeirdFormatValidator
    {
        public List<string> formats { get; set; }
        public bool monthFirst { get; set; }

        public WeirdFormatValidator(bool monthFirst)
        {
            this.monthFirst = monthFirst;

            formats = new List<string>();
            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (var i in cultures)
            {
                string f = i.DateTimeFormat.ShortDatePattern;
                if (!formats.Contains(f)) formats.Add(f);
            }
            int j = 1;
            formats.Sort();

            if (!monthFirst)
            {
                List<string> ddFormats = new List<string>();
                foreach(var i in formats)
                {
                    if (i[0] == 'd') ddFormats.Add(i);
                }
                formats.RemoveAll(word => word[0] == 'd');

                formats.AddRange(ddFormats);
                
            }
            
        }

        public Weird ValidateWeirdFormat(string dateAsString)
        {
            DateTime date = new DateTime();
            string formatFound = "";
            foreach (var f in formats)
            {
                if (DateTime.TryParseExact(dateAsString, f, CultureInfo.CurrentCulture, DateTimeStyles.None, out date))
                {
                    formatFound = f;
                    break;
                }
            }
            char separator = Helper.CheckSeparator(dateAsString);
            string dateWithoutSpaces = String.Concat(dateAsString.Where(c => !Char.IsWhiteSpace(c)));
            string[] pieces = Helper.DivideDateIntoParts(dateWithoutSpaces, separator);
            if (pieces == null) return null;
            string firstPart = pieces[0];
            string secondPart = pieces[1];
            string lastPart = pieces[2];

            if (monthFirst)
            {
                
                if (secondPart[0] == '0') formatFound=formatFound.Replace("M", "MM");
                if (firstPart[0] != 'y')
                {
                    if (firstPart[0] == '0') formatFound = formatFound.Replace("d", "dd");
                }
            }
            else
            {
                if (firstPart[0] != 'y')
                {
                    if (firstPart[0] == '0') formatFound = formatFound.Replace("M", "MM");
                }
                if (secondPart[0] == '0') formatFound = formatFound.Replace("d", "dd");
            }
            
            if (formatFound.Contains("d") && formatFound.Contains("M") && formatFound.Contains("y")) return new Weird(formatFound, date);
            
            return null;
        }

    }
}
