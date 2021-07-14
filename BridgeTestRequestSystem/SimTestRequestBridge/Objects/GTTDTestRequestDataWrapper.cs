using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimTestRequestBridge.Objects
{
    public class GTTDTestRequestDataWrapper
    {
        public string Test_Number { get; set; }
        public string Test_Code { get; set; }
        public string PREFER_DRIVER { get; set; }
        public string MACHINE_NAME { get; set; }
        public string SPEED { get; set; }
        public string VEHICLE_MODEL { get; set; }
        public List<GTTDTestRequestStepDataWrapper> Steps { get; set; }
    }


    public class GTTDTestRequestStepDataWrapper
    {
        public string Test_Step_Number { get; set; }
        public string MANEUVER { get; set; }
     
        public string LF_CONST { get; set; }
        public string LF_SERIAL { get; set; }
        public string LF_INFLATION { get; set; }

        public string RF_CONST { get; set; }
        public string RF_SERIAL { get; set; }
        public string RF_INFLATION { get; set; }

        public string LR_CONST { get; set; }
        public string LR_SERIAL { get; set; }
        public string LR_INFLATION { get; set; }

        public string RR_CONST { get; set; }
        public string RR_SERIAL { get; set; }
        public string RR_INFLATION { get; set; }

        public string TRACK { get; set; }
        public string TIRE_MODEL { get; set; }
    }
}
