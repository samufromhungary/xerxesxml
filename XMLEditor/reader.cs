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
