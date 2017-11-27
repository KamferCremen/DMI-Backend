using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMIPrivateServices.Model
{
    public class TemperatureData
    {
        #region Props

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private double _temperature;
        public double Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }

        private DateTime _captureTime;
        public DateTime CaptureTime
        {
            get { return _captureTime; }
            set { _captureTime = value; }
        }

        #endregion

        public TemperatureData()
        {
            
        }
        public TemperatureData(int id, double temperature, DateTime captureTime)
        {
            _id = id;
            _temperature = temperature;
            _captureTime = captureTime;
        }

    }
}