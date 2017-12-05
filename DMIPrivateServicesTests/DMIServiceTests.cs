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
            //Arrange

            IDMIService service = new DMIService();

            //Act

            List<TemperatureData> temperatures = service.AllTemperatures();

            //Assert

            Assert.IsTrue(temperatures.Count > 0);
        }


        [TestMethod()]
        public void AddTemperatureTest()
        {
            //Arrange

            IDMIService service = new DMIService();

            //Act

            List<TemperatureData> temperatureList = service.AllTemperatures();

            int count = temperatureList.Count;

            service.AddTemperature(new TemperatureData {Temperature = 40});

            temperatureList = service.AllTemperatures();

            int newCount = temperatureList.Count;

            //Assert

            Assert.AreEqual(count + 1, newCount);
        }

        [TestMethod()]
        public void EditTemperatureTest()
        {
            //Arange

            IDMIService service = new DMIService();

            //Act

            //TemperatureData 

            //Assert
        }

    }
}