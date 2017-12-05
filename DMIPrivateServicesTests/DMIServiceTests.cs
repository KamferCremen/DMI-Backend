using Microsoft.VisualStudio.TestTools.UnitTesting;
using DMIPrivateServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMIPrivateServices.Model;

namespace DMIPrivateServices.Tests
{
    [TestClass()]
    public class DMIServiceTests
    {
        [TestMethod()]
        public void AllTemperaturesTest()
        {
            IDMIService service = new DMIService();

            List<TemperatureData> temperatures = service.AllTemperatures();

            Assert.IsTrue(temperatures.Count > 0);
        }
    }
}