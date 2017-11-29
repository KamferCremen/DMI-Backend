using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMIPrivateServices.Model
{
    public class LiveTemperature
    {
        private static LiveTemperature instance;

        public double LiveTemp;

        private LiveTemperature() { }

        public static LiveTemperature Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LiveTemperature();
                }
                return instance;
            }
        }
    }
}