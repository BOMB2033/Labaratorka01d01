using Microsoft.VisualStudio.TestTools.UnitTesting;
using Labaratorka01d01.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labaratorka01d01.AppData;

namespace Labaratorka01d01.Pages.Tests
{
    [TestClass()]
    public class AddEditUchetTests
    {
        [TestMethod()]
        public void CheckTest()
        {
            Uchet uchet = new Uchet { ID = 10, NumbChet = 231234, MothPay = 2, Rate = (decimal)4.58 , Kw = 220 };
            bool expected = true;
            bool actual = AddEditUchet.CheckTest(uchet);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CheckMonthOutsideTest()
        {
            Uchet uchet = new Uchet { ID = 10, NumbChet = 231234, MothPay = 32, Rate = (decimal)4.58, Kw = 220 };
            bool expected = false;
            bool actual = AddEditUchet.CheckTest(uchet);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CheckNumbChetOutsideTest()
        {
            Uchet uchet = new Uchet { ID = 10, NumbChet = -123213, MothPay = 2, Rate = (decimal)4.58, Kw = 220 };
            bool expected = false;
            bool actual = AddEditUchet.CheckTest(uchet);
            Assert.AreEqual(expected, actual);
        }

    }
}