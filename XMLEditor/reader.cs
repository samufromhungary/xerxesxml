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
using System.Drawing;

namespace XMLEditor
{
    public class Reader
    {
        string asd;
        public static Color HC_NODE = Color.Firebrick;
        public static Color HC_STRING = Color.Blue;
        public static Color HC_ATTRIBUTE = Color.Red;
        public static Color HC_COMMENT = Color.GreenYellow;
        public static Color HC_INNERTEXT = Color.Black;


        DateFormat DateFormat = new DateFormat();
        public Reader()
        {

        }
        public String Read(String xml, RichTextBox richTextBox)
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

            } catch (Exception e)
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
                }
            }
            else
            {
                return null;
            }
            return tags;
        }

        public void Save(String content, String xml, RichTextBox richTextBox,TabControl tabControl)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(content);
                doc.Save(xml);
                var selectedTab = tabControl.SelectedTab;

                if (selectedTab.Text.Contains("*"))
                {
                    selectedTab.Text = selectedTab.Text.Remove(selectedTab.Text.Length - 1);
                }
            }
            catch (XmlException e)
            {
                richTextBox.Text += DateFormat.AppendMessage(e.Message, Path.GetFileName(xml));
            }
        }


        public void Highlight(RichTextBox rtb)
        {
            int k = 0;

            string str = rtb.Text;

            int st, en;
            int lasten = -1;
            while(k < str.Length)
            {
                st = str.IndexOf('<', k);

                if (st < 0)
                {
                    break;
                }
                if (lasten > 0)
                {
                    rtb.Select(lasten + 1, st - lasten - 1);
                    rtb.SelectionColor = HC_INNERTEXT;
                }

                en = str.IndexOf('>', st + 1);
                if (en < 0)
                {
                    break;
                }
                k = en + 1;
                lasten = en;

                if (str[st + 1] == '!')
                {
                    rtb.Select(st + 1, en - st - 1);
                    rtb.SelectionColor = HC_COMMENT;
                    continue;
                }
                string nodeText = str.Substring(st + 1, en - st - 1);
                bool inString = false;

                int lastSt = -1;
                int state = 0;
                int startNodeName = 0, startAtt = 0;
                for(int i=0; i < nodeText.Length; ++i)
                {
                    if (nodeText[i] == '"')
                    {
                        inString = !inString;
                    }
                    if (inString && nodeText[i] == '"')
                    {
                        lastSt = i;
                    }
                    else
                    {
                        if (nodeText[i] == '"')
                        {
                            rtb.Select(lastSt + st + 2, i - lastSt - 1);
                            rtb.SelectionColor = HC_STRING;
                        }
                    }
                    switch (state)
                    {
                        case 0:
                            if (!Char.IsWhiteSpace(nodeText, i))
                            {
                                startNodeName = i;
                                state = 1;
                            }
                            break;
                        case 1:
                            if (Char.IsWhiteSpace(nodeText, i))
                            {
                                rtb.Select(startNodeName + st, i - startNodeName + 1);
                                rtb.SelectionColor = HC_NODE;
                                state = 2;
                            }
                            break;
                        case 2:
                            if (!Char.IsWhiteSpace(nodeText, i))
                            {
                                startAtt = i;
                                state = 3;
                            }
                            break;

                        case 3:
                            if (Char.IsWhiteSpace(nodeText, i) || nodeText[i] == '=')
                            {
                                rtb.Select(startAtt + st, i - startAtt + 1);
                                rtb.SelectionColor = HC_ATTRIBUTE;
                                state = 4;
                            }
                            break;
                        case 4:
                            if (nodeText[i] == '"' && !inString)
                            {
                                state = 2;
                            }
                            break;
                    }
                }
                if (state == 1)
                {
                    rtb.Select(st + 1, nodeText.Length);
                    rtb.SelectionColor = HC_NODE;
                }
            }
        }


    }
}
