using System;
using System.Collections.Generic;
using System.Text;

namespace datesParser
{
    public class PartialFormat
    {
        public string formatName { get; set; }
        public string formatStyle { get; set; }

        public PartialFormat(string formatName, string formatStyle)
        {
            this.formatName = formatName;
            this.formatStyle = formatStyle;
        }
        public static PartialFormat CheckDay(Data dataset)
        {
            string format = "";
            if (Convert.ToInt32(dataset.Part) == dataset.Date.Day)
            {
                if (dataset.Part[0] == '0') format += ("dd");
                else format += ("d");

                format += dataset.Separator;
                if (dataset.SpacesOccur) format += " ";
                return new PartialFormat("day", format);
            }
            return new PartialFormat("none", "none");

        }
        public static PartialFormat CheckMonth(Data dataset)
        {

            string format = "";
            if (Convert.ToInt32(dataset.Part) == dataset.Date.Month)
            {

                if (dataset.Part[0] == '0') format += ("MM");
                else format += ("M");

                format += dataset.Separator;
                if (dataset.SpacesOccur) format += " ";
                return new PartialFormat("month", format);
            }
            return new PartialFormat("none", "none");
        }
        public static PartialFormat CheckYear(Data dataset)
        {
            string format = "";
            if (dataset.Part.Length == 4 && Convert.ToInt32(dataset.Part) == dataset.Date.Year)
            {
                format += "yyyy";
                format += dataset.Separator;
                if (dataset.SpacesOccur) format += " ";
                return new PartialFormat("year", format);
            }
            else if ((Convert.ToInt32(dataset.Part) + 1900 == dataset.Date.Year) || (Convert.ToInt32(dataset.Part) + 2000 == dataset.Date.Year))
            {
                format += "yy";
                format += dataset.Separator;
                if (dataset.SpacesOccur) format += " ";
                return new PartialFormat("year", format);
            }

            return new PartialFormat("none", "none");
        }
    }
}
