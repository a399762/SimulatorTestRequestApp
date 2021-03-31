using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TestRequestXMLParser
{
    public class TestRequest
    {
      
        public static L2l1testreq TestRequestParse(String file)
        {
            L2l1testreq testResult;

            using (FileStream stream = new FileStream(file, FileMode.Open))
            {
                var xsz = new XmlSerializer(typeof(L2l1testreq));
                testResult = (L2l1testreq)xsz.Deserialize(stream);
            }

            return testResult;
        }

    }


   

}
