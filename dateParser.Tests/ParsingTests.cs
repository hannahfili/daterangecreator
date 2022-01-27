using datesParser;
using NUnit.Framework;
using System;

namespace dateParser.Tests
{
    [TestFixture]
    public class ParsingTests
    {
        static void Main(string[] args)
        {

        }
        [Test]
        public void ShouldReturn_ddMMyyyy_dotted_without_month_repeated()
        {
            string result = DateRange.GenerateDateRange("01.01.2017 05.01.2017");
            Assert.That(result, Is.EqualTo("01 - 05.01.2017"));
        }
        [Test]
        public void ShouldReturn_ddMMyyyy_slashed_without_year_repeated()
        {
            string result = DateRange.GenerateDateRange("01/01/2017 05/02/2017");
            Assert.That(result, Is.EqualTo("01/01 - 05/02/2017"));
        }

        [Test]
        public void ShouldReturn_yyyyMMdd_dashed()
        {
            string result = DateRange.GenerateDateRange("2016-01-01 2017-01-05");
            Assert.That(result, Is.EqualTo("2016-01-01 - 2017-01-05"));
        }
        [Test]
        public void ShouldReturn_MMddyyyy_dashed()
        {
            string result = DateRange.GenerateDateRange("05/28/2019 06/30/2021");
            Assert.That(result, Is.EqualTo("05/28/2019 - 06/30/2021"));
        }
        [Test]
        public void ShouldReturn_MMddyyyy_dashed_january()
        {
            string result = DateRange.GenerateDateRange("1/1/2019 1/31/2019");
            Assert.That(result, Is.EqualTo("1/1/2019 - 1/31/2019"));
        }
        [Test]
        public void ShouldReturn_ddMMyyyy_dashed()
        {
            string result = DateRange.GenerateDateRange("01-05-1997 02-05-1997");
            Assert.That(result, Is.EqualTo("01 - 02-05-1997"));
        }



    }
}