using System;
using System.Collections.Generic;
using System.Text;

namespace datesParser
{
    public class Data
    {
        public Data(string part, DateTime date, bool spacesOccur, char separator)
        {
            Part = part;
            Date = date;
            SpacesOccur = spacesOccur;
            Separator = separator;
        }

        public string Part { get; set; }
        public DateTime Date { get; set; }
        public bool SpacesOccur { get; set; }
        public char Separator { get; set; }


    }
}
