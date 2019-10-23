using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XMLEditor
{
    public class Reader
    {
        string asd;


        DateFormat DateFormat = new DateFormat();
        public Reader()
        {

        }
        public String Read(String xml,RichTextBox richTextBox)
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
                return richTextBox.Text += DateFormat.AppendMessage(e.Message, Path.GetFileName(xml));
            }

        }
        public List<string> ReadXSD(String xsd)
        {
            List<String> tags = new List<string>();
            if (xsd.EndsWith(".xsd"))
            {

                var xs = XNamespace.Get("http://www.w3.org/2001/XMLSchema");
                var doc = XDocument.Load(xsd);

                foreach (var element in doc.Descendants(xs + "element"))
                {
                    tags.Add(element.Attribute("name").Value);
                    //for(int i = 0; i < tags.Count; i++)
                    //{
                    //}
                    //return asd.Trim();
                }
            }
            else
            {
                return null;
            }
            return tags;
        }

        public void Save(String content, String xml,RichTextBox richTextBox)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(content);
                doc.Save(xml);
            }
            catch (XmlException e)
            {
                richTextBox.Text += DateFormat.AppendMessage(e.Message, Path.GetFileName(xml));
            }
        }

    }
}
