using System;
using BusinessHoursLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HoroscopeTests
{
    [TestClass]
    public class BusinessHoursTests
    {
        private BusinessHours _businessHours;
        private const string _closed = "Closed";
        private const string _open10Close6 = "10:00 AM-6:00 PM";
        private const string _open10Close7 = "10:00 AM-7:00 PM";

        [TestInitialize]
        public void Initialize()
        {
            var tenOpen = DateTime.Parse("10:00 AM");
            var sixClose = DateTime.Parse("6:00 PM");
            var sevenClose = DateTime.Parse("7:00 PM");

            _businessHours = new BusinessHours
            {
                Monday = new Hours(tenOpen, sixClose),
                Tuesday = new Hours(tenOpen, sixClose),
                Wednesday = new Hours(tenOpen, sixClose),
                Thursday = new Hours(tenOpen, sevenClose),
                Friday = new Hours(tenOpen, sixClose),
                Saturday = new Hours(tenOpen, sixClose)
            };
        }

        [TestMethod]
        public void MondayOpen10Close6()
        {
            Assert.AreEqual(_open10Close6, _businessHours.Monday.ToString());
        }

        [TestMethod]
        public void TuesdayOpen10Close6()
        {
            Assert.AreEqual(_open10Close6, _businessHours.Tuesday.ToString());
        }

        [TestMethod]
        public void WednesdayOpen10Close6()
        {
            Assert.AreEqual(_open10Close6, _businessHours.Wednesday.ToString());
        }

        [TestMethod]
        public void ThursdayOpen10Close7()
        {
            Assert.AreEqual(_open10Close7, _businessHours.Thursday.ToString());
        }

        [TestMethod]
        public void FridayOpen10Close6()
        {
            Assert.AreEqual(_open10Close6, _businessHours.Friday.ToString());
        }

        [TestMethod]
        public void SaturdayOpen10Close6()
        {
            Assert.AreEqual(_open10Close6, _businessHours.Saturday.ToString());
        }

        [TestMethod]
        public void SundayIsClosed()
        {
            Assert.AreEqual(_closed, _businessHours.Sunday.ToString());
        }
    }
}
