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
    public class AddEditClientTests
    {
        [TestMethod()]
        public void CheckClientTest()
        {
            Clients clients = new Clients { NumbChet = 231234, FullName = "Иван", Address = "г.Иркутск" };
            bool expected = true;
            bool actual = AddEditClient.CheckClient(clients);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckNullClientTest()
        {
            Clients clients = new Clients { NumbChet = 231234, FullName = "", Address = "" };
            bool expected = false;
            bool actual = AddEditClient.CheckClient(clients);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckDigitalClientTest()
        {
            Clients clients = new Clients { NumbChet = 231234, FullName = "Иван123", Address = "г.Иркутск дом 123" };
            bool expected = false;
            bool actual = AddEditClient.CheckClient(clients);
            Assert.AreEqual(expected, actual);
        }
    }
}