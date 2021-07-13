using SimBridge.Database;
using SimTestRequestBridge.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SimBridge.Helpers
{
    public static class GttdTestRequestHelper
    {
        public static GTTDTestRequestDataWrapper ConvertFromXMLToEntity(String xmlData)
        {
            XDocument document = XDocument.Parse(xmlData);
            var stepListRaw = document.Descendants().Where(p => p.Name.LocalName == "step");
            //< test_step_number > A </ test_step_number >

            var step0A = stepListRaw.FirstOrDefault(p => p.Attribute("step_sequence").Value == "0");

            var conds = step0A.Elements().Descendants("cond");
            var preferDriverRaw = conds.FirstOrDefault(i => i.Attribute("name").Value == "PREFER DRIVER");
            var machineNameRaw = conds.FirstOrDefault(i => i.Attribute("name").Value == "MACHINE NAME");
            var vehicleModelRaw = conds.FirstOrDefault(i => i.Attribute("name").Value == "VEHICLE MODEL");
           
            var stepsRaw = conds.FirstOrDefault(i => i.Attribute("name").Value == "VEHICLE MODEL");

            GTTDTestRequestDataWrapper testRequestWrapper = new GTTDTestRequestDataWrapper();
            testRequestWrapper.PREFER_DRIVER = preferDriverRaw.Value;
            testRequestWrapper.MACHINE_NAME = machineNameRaw.Value;
            testRequestWrapper.VEHICLE_MODEL = vehicleModelRaw.Value;
            testRequestWrapper.MACHINE_NAME = machineNameRaw.Value;
            testRequestWrapper.Steps = new List<GTTDTestRequestStepDataWrapper>();
            var validSteps = stepListRaw.Where(p => int.Parse(p.Attribute("step_sequence").Value) > 0);

            foreach (var item in validSteps)
            {
                GTTDTestRequestStepDataWrapper stepWrapper = new GTTDTestRequestStepDataWrapper();

                var stepConditions = item.Elements().Descendants("cond");
                var MANEUVER = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "MANEUVER");
                var LF_CONST = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "LF-CONST");
                var LF_SERIAL = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "LF-SERIAL");
                var LF_INFLATION = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "LF-INFLATION");
                var RF_CONST = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "RF-CONST");
                var RF_SERIAL = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "RF-SERIAL");
                var RF_INFLATION = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "RF-INFLATION");
                var LR_CONST = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "LR-CONST");
                var LR_SERIAL = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "LR-SERIAL");
                var LR_INFLATION = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "LR-INFLATION");
                var RR_CONST = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "RR-CONST");
                var RR_SERIAL = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "RR-SERIAL");
                var RR_INFLATION = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "RR-INFLATION");
                var TRACK = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "TRACK");
                var TIRE_MODEL = stepConditions.FirstOrDefault(i => i.Attribute("name").Value == "TIRE_MODEL");

                stepWrapper.MANEUVER = MANEUVER.Value;
                stepWrapper.LF_CONST = LF_CONST.Value;
                stepWrapper.LF_SERIAL = LF_SERIAL.Value;
                stepWrapper.LF_INFLATION = LF_INFLATION.Value;
                stepWrapper.RF_CONST = RF_CONST.Value;
                stepWrapper.RF_SERIAL = RF_SERIAL.Value;
                stepWrapper.RF_INFLATION = RF_INFLATION.Value;
                stepWrapper.LR_CONST = RF_CONST.Value;
                stepWrapper.LR_SERIAL = RF_SERIAL.Value;
                stepWrapper.LR_INFLATION = RF_INFLATION.Value;
                stepWrapper.RR_CONST = RF_CONST.Value;
                stepWrapper.RR_SERIAL = RF_SERIAL.Value;
                stepWrapper.RR_INFLATION = RF_INFLATION.Value;
                stepWrapper.TIRE_MODEL = TIRE_MODEL.Value;
                stepWrapper.TRACK = TRACK.Value;

                testRequestWrapper.Steps.Add(stepWrapper);
            }
            
            return testRequestWrapper;
        }

   
    }
}
