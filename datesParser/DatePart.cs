using System;
using System.Collections.Generic;
using System.Text;

namespace datesParser
{
    public class DatePart
    {
        public static PartialFormat CheckFirstPart(Data dataset, bool monthFirst = false)
        {
            PartialFormat day, month, year;
            if (dataset.Part.Length == 4)
            {
                year = PartialFormat.CheckYear(dataset);
                if (year.formatName == "year") return year;
            }

            if (monthFirst)
            {
                month = PartialFormat.CheckMonth(dataset);
                if (month.formatName == "month") return month;
                day = PartialFormat.CheckDay(dataset);
                if (day.formatName == "day") return day;
            }
            else
            {
                day = PartialFormat.CheckDay(dataset);
                if (day.formatName == "day") return day;

                month = PartialFormat.CheckMonth(dataset);
                if (month.formatName == "month") return month;
            }


            return null;
        }
        public static PartialFormat CheckSecondPart(Data dataset, PartialFormat formatAlreadyFound)
        {
            if (formatAlreadyFound == null) return null;
            PartialFormat day, month;

            if (formatAlreadyFound.formatName == "year" || formatAlreadyFound.formatName == "day")
            {
                month = PartialFormat.CheckMonth(dataset);
                if (month.formatName == "month") return month;
            }
            else if (formatAlreadyFound.formatName == "month")
            {
                day = PartialFormat.CheckDay(dataset);
                if (day.formatName == "day") return day;
            }
            return null;
        }

        public static PartialFormat CheckLastPart(Data dataset, PartialFormat formatAlreadyFound1, PartialFormat formatAlreadyFound2)
        {
            if (formatAlreadyFound1 == null || formatAlreadyFound2 == null) return null;
            if (formatAlreadyFound1.formatName != "day" && formatAlreadyFound2.formatName != "day")
            {
                PartialFormat day = PartialFormat.CheckDay(dataset);
                if (day.formatName == "day") return day;
            }
            if (formatAlreadyFound1.formatName != "year" && formatAlreadyFound2.formatName != "year")
            {
                PartialFormat year = PartialFormat.CheckYear(dataset);
                if (year.formatName == "year") return year;
            }

            return null;
        }
    }
}
