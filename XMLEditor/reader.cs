using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace XMLEditor
{
    public class Reader
    {
        public Reader()
        {

        }
        public String Read(String xml)
        {
            try
            {
                if (xml.EndsWith(".xml"))
                {
                    List<String> content = new List<String>();
                    XmlDocument doc = new XmlDocument();
                    doc.PreserveWhitespace = true;
                    doc.Load(xml);
                    string xmlcontents = doc.InnerXml;
                    content.Add(xmlcontents);
                    return xmlcontents;
                }
                else
                {
                    return null;
                }

            }catch(Exception e)
            {
                return null;
            }

        }
    }
}
