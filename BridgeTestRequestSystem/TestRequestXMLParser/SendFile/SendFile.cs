using System;
using System.IO;
using System.Xml.Serialization;

namespace TestRequestXMLParser.SendFile
{
    public class SendFile
    {
        public static Afc TestRequestParseFile(String file)
        {
            Afc result;

            using (FileStream stream = new FileStream(file, FileMode.Open))
            {

                var xsz = new XmlSerializer(typeof(Afc));
                result = (Afc)xsz.Deserialize(stream);
            }

            return result;
        }


        public static Afc TestRequestParseXML(String xml)
        {
            Afc testResult;

            XmlSerializer serializer = new XmlSerializer(typeof(Afc));
            StringReader rdr = new StringReader(xml);
            testResult = (Afc)serializer.Deserialize(rdr);

            return testResult;
        }


    }
}
