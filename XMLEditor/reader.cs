using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLEditor
{
    public class Reader
    {
        public Reader()
        {

        }
        public String Read(String xml)
        {
            List<String> content = new List<String>();
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(xml);
            string xmlcontents = doc.InnerXml;
            content.Add(xmlcontents);

            return xmlcontents;
        }
    }
}
