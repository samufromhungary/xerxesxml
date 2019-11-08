using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace XMLEditor
{
    public partial class xmleditor : Form
    {
        Reader Reader = new Reader();
        Validator Validator = new Validator();
        Explorer Explorer = new Explorer();
        DateFormat DateFormat = new DateFormat();

        bool listShow = false;
        string keyword = "<";
        int count = 0;

        String text;
        String xmlname;
        String xsdname;
        String msg;
        String savedxsd = "";
        float normal = 8.25F;
        float actual = 8.25F;



        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        bool autosave = false;
        bool wassaved = false;
        bool autovalidate = false;

        public Color HC_NODE = Color.Firebrick;
        public Color HC_STRING = Color.Blue;
        public Color HC_ATTRIBUTE = Color.Red;
        public Color HC_COMMENT = Color.GreenYellow;
        public Color HC_INNERTEXT = Color.Black;
        public xmleditor()
        {
            InitializeComponent();
            NewTab();
        }

        private void RichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            var selectedTab = tabControlEditor.SelectedTab;

            foreach (RichTextBox richText in selectedTab.Controls)
            {
                int index = richText.SelectionStart;
                int line = richText.GetLineFromCharIndex(index);
                statusLabel.Visible = true;
                int nums = richText.Lines.Length;

                statusLabel.Text = String.Format("Lines: {0} (Current: {1})  ", nums.ToString(), (line + 1).ToString());
            }
        }

        public String OpenFile()
        {
            xmlname = Explorer.SelectedFilePathXml();
            Reset();

            var selectedTab = tabControlEditor.SelectedTab;
            foreach (RichTextBox richText in selectedTab.Controls)
            {
                richText.Font = LoadSettings();
                richText.Text = Reader.Read(xmlname, infoTextBox);
                selectedTab.Text = Path.GetFullPath(xmlname);
                Reader.Highlight(richText);

            }
            validateToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = true;
            return xmlname;
        }

        public void OpenWithoutExplorer(String xml)
        {
            Reset();
            var selectedTab = tabControlEditor.SelectedTab;
            foreach (RichTextBox richText in selectedTab.Controls)
            {
                richText.Text = Reader.Read(xml, infoTextBox);
                selectedTab.Text = Path.GetFileName(xml);
                Reader.Highlight(richText);
            }
            validateToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveColors();
            OpenFile();
            validateToolStripMenuItem.Enabled = false;
        }

        private void ValidateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ValidateFile();
        }
        void ValidateFile()
        {
            if (PageIterator().Length != 0)
            {
                bool ? isValid = false;
                if (savedxsd.Equals(""))
                {

                    xsdname = Explorer.SelectedFilePathXsd();
                    savedxsd = xsdname;
                    isValid = Validator.Validate(xsdname, xmlname);
                }
                else if(!savedxsd.Equals(""))
                {
                    isValid = Validator.Validate(savedxsd, xmlname);
                }
                
                if (isValid == true)
                {
                    List<string> asd = Reader.ReadXSD(xsdname);
                    msg = "Validation was successful";
                    infoTextBox.Text += DateFormat.AppendMessage(msg, Path.GetFileName(xmlname));
                    pictureBoxValid.BackColor = System.Drawing.Color.Lime;
                    pictureBoxValid.Visible = true;
                    for(int i = 0; i < asd.Count; i++)
                    {
                       listBox1.Items.Add(asd[i]);
                    }
                }
                else if (isValid == false)
                {
                    msg = "Validation was unsuccessful";
                    infoTextBox.Text += DateFormat.AppendMessage(msg, Path.GetFileName(xmlname));
                    pictureBoxValid.BackColor = System.Drawing.Color.Red;
                    pictureBoxValid.Visible = true;

                }
                else
                {
                    msg = "No XSD found";
                    infoTextBox.Text += DateFormat.AppendMessage(msg, Path.GetFileName(xmlname));
                }
            }
        }

        void Reset()
        {
            pictureBoxValid.Visible = false;
            validateToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
        }
        public String PageIterator()
        {
            var selectedTab = tabControlEditor.SelectedTab;
            foreach (RichTextBox richText in selectedTab.Controls)
            {
                text = richText.Text;
            }
            return text;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if(xmlname == null)
            {
                OpenWithoutExplorer(NewFile());
                validateToolStripMenuItem.Enabled = true;

            }
            else
            {
                Reader.Save(PageIterator(), xmlname, infoTextBox,tabControlEditor);
                validateToolStripMenuItem.Enabled = true;
                if(!savedxsd.Equals("") && autovalidate)
                {
                    ValidateFile();
                }
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveColors();
            NewTab();
            saveToolStripMenuItem.Enabled = true;

        }

        private String NewFile()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var selectedTab = tabControlEditor.SelectedTab;
                foreach (RichTextBox richText in selectedTab.Controls)
                {
                    Reader.Save(PageIterator(), saveFileDialog.FileName, richText, tabControlEditor);
                    return Path.GetFullPath(saveFileDialog.FileName);
                }
            }return null;
        }
        RichTextBox NewTab()
        {
            CustomTab ct = new CustomTab();
            ct.textbox.Font = LoadSettings();
            ct.textbox.SelectionChanged += RichTextBox_SelectionChanged;
            ct.textbox.TextChanged += RichTextBox_TextChanged;
            ct.Text = "Untitled";
            tabControlEditor.TabPages.Add(ct);
            return ct.textbox;
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            var selectedTab = tabControlEditor.SelectedTab;
            if (!selectedTab.Text.Contains("*"))
            {
                selectedTab.Text = selectedTab.Text + "*";
            }
            else
            {
            }

        }

        private void tabControlEditor_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            var selectedTab = tabControlEditor.SelectedTab;
            foreach (RichTextBox richText in selectedTab.Controls)
            {
                if (e.Control && e.KeyCode == Keys.O)
                {
                    OpenFile();
                    validateToolStripMenuItem.Enabled = false;
                }
                if (e.Control && e.KeyCode == Keys.S)
                {
                    Reader.Save(PageIterator(), xmlname, infoTextBox, tabControlEditor);
                    validateToolStripMenuItem.Enabled = true;
                }
                if (e.Control && e.KeyCode == Keys.V)
                {
                    if(!validateToolStripMenuItem.Enabled == false)
                    {
                        ValidateFile();
                    }
                    else
                    {
                        MessageBox.Show("First,you should save your file!");
                    }
                }
                if (e.Control && e.KeyCode == Keys.B)
                {
                    savedxsd = "";
                    ValidateFile();
                }
                if (e.KeyCode == Keys.Enter)
                {
                    count = 0;
                    keyword = "<";
                    listShow = false;
                    listBox1.Hide();

                }
                if (e.KeyCode == Keys.Space)
                {
                    count = 0;
                    keyword = "<";
                    listShow = false;
                    listBox1.Hide();
                }

                if (listShow == true)
                {
                    if (e.KeyCode == Keys.Up)
                    {
                        listBox1.Focus();
                        if (listBox1.SelectedIndex != 0)
                        {
                            listBox1.SelectedIndex -= 1;
                        }
                        else
                        {
                            listBox1.SelectedIndex = 0;
                        }
                        richText.Focus();

                    }
                    else if (e.KeyCode == Keys.Down)
                    {
                        listBox1.Focus();
                        try
                        {
                            listBox1.SelectedIndex += 1;
                        }
                        catch
                        {
                        }
                        richText.Focus();
                    }

                    if (e.KeyCode == Keys.Tab)
                    {

                        string autoText = listBox1.SelectedItem.ToString();
                        int beginPlace = richText.SelectionStart;
                        richText.SelectedText = "";
                        richText.Text = richText.Text.Insert(beginPlace, autoText);
                        richText.Focus();
                        listShow = false;
                        listBox1.Hide();

                    }
                }
            }
        }


        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            var selectedTab = tabControlEditor.SelectedTab;
            foreach (RichTextBox richText in selectedTab.Controls)
            {
                string autoText = listBox1.SelectedItem.ToString();
                int beginPlace = richText.SelectionStart;
                richText.SelectedText = "";
                richText.Text = richText.Text.Insert(beginPlace, autoText + ">");
                richText.Focus();
                listShow = false;
                listBox1.Hide();
            }
        }

        private void tabControlEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                var selectedTab = tabControlEditor.SelectedTab;

                foreach (RichTextBox richText in selectedTab.Controls)
                {
                    if (listShow == true)
                    {
                        keyword += e.KeyChar;
                        count++;
                        Point point = richText.GetPositionFromCharIndex(richText.SelectionStart);
                        point.Y += (int)Math.Ceiling(richText.Font.GetHeight()) + 13; //13 is the .y postion of the richtectbox
                        point.X += 105; //105 is the .x postion of the richtectbox
                        listBox1.Location = point;
                        listBox1.Show();
                        listBox1.SelectedIndex = 0;
                        listBox1.SelectedIndex = listBox1.FindString(keyword);
                        richText.Focus();
                    }

                    if (e.KeyChar == '<' && listBox1.Items.Count > 0)
                    {

                        listShow = true;
                        Point point = richText.GetPositionFromCharIndex(richText.SelectionStart);
                        point.Y += (int)Math.Ceiling(richText.Font.GetHeight()) + 13; //13 is the .y postion of the richtectbox
                        point.X += 105; //105 is the .x postion of the richtectbox
                        listBox1.Location = point;
                        count++;
                        listBox1.Show();
                        listBox1.SelectedIndex = 0;
                        listBox1.SelectedIndex = listBox1.FindString(keyword);
                        richText.Focus();
                    }
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void TabControlEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTab = tabControlEditor.SelectedTab;
            if (PageIterator() is null)
            {
                MessageBox.Show("Not working");
            }
            else
            {
                string name = selectedTab.Text;
                if (name.Contains("*"))
                {
                    string starName = name.Substring(0, (name.Length - 1));
                    xmlname = Path.GetFullPath(starName);
                }
            }
            statusLabel.Text = String.Empty;
        }

        private void tabControlEditor_DoubleClick(object sender, EventArgs e)
        {
            var selectedTab = tabControlEditor.SelectedTab;
            tabControlEditor.TabPages.Remove(selectedTab);
        }
        private void FontEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontEditor fontEditor = new FontEditor();
            fontEditor.ShowDialog();
        }

        public void SetFont(System.Drawing.FontFamily fontFamily, float size)
        {
            this.Font = new System.Drawing.Font(fontFamily, size);
        }

        public Font LoadSettings()
        {
            if (!File.Exists("settings.txt"))
            {
                return new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
            }
            else
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("settings.txt", FileMode.Open, FileAccess.Read);
                CustomFont customfont = (CustomFont)formatter.Deserialize(stream);
                return new Font(customfont.TYPE, customfont.SIZE);
            }

        }

        private void AutoValidateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autovalidate)
            {
                autovalidate = false;
                MessageBox.Show("Validate by save turned off");
            }
            else
            {
                autovalidate = true;
                MessageBox.Show("Validate by save turned on");
            }
        }

        private void xmleditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Xerxes", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           try
            {
                var selectedTab = tabControlEditor.SelectedTab;
                CustomTab valami = (CustomTab)selectedTab;
                valami.textbox.SelectionStart = valami.textbox.Find(valami.textbox.Lines[Reader.line - 1]);
                valami.textbox.ScrollToCaret();
                valami.textbox.Focus();

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        private void NodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult colors = colorDialog.ShowDialog();

            if(colors == DialogResult.OK)
            {
                HC_NODE = colorDialog.Color;
                nodeToolStripMenuItem.ForeColor = HC_NODE;
                SaveColors();
            }
        }

        private void StringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult colors = colorDialog.ShowDialog();

            if (colors == DialogResult.OK)
            {
                HC_STRING = colorDialog.Color;
                stringToolStripMenuItem.ForeColor = HC_STRING;
                SaveColors();
            }
        }

        private void AttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult colors = colorDialog.ShowDialog();

            if (colors == DialogResult.OK)
            {
                HC_ATTRIBUTE = colorDialog.Color;
                attributeToolStripMenuItem.ForeColor = HC_ATTRIBUTE;
                SaveColors();
            }
        }

        private void CommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult colors = colorDialog.ShowDialog();

            if (colors == DialogResult.OK)
            {
                HC_COMMENT = colorDialog.Color;
                commentToolStripMenuItem.ForeColor = HC_COMMENT;
                SaveColors();
            }
        }

        private void InnertextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult colors = colorDialog.ShowDialog();

            if (colors == DialogResult.OK)
            {
                HC_INNERTEXT = colorDialog.Color;
                innertextToolStripMenuItem.ForeColor = HC_INNERTEXT;
                SaveColors();

            }
        }

        private void ColorPaletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveColors();
        }

        private void SaveColors()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("colors.txt", FileMode.Create, FileAccess.Write);
            CustomColor customcolor = new CustomColor(HC_NODE, HC_STRING, HC_ATTRIBUTE, HC_COMMENT, HC_INNERTEXT);
            formatter.Serialize(stream, customcolor);
            stream.Close();
        }

        private void NodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HC_NODE = nodeToolStripMenuItem1.ForeColor;
            SaveColors();
        }

        private void StringToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HC_STRING = stringToolStripMenuItem1.ForeColor;
            SaveColors();
        }

        private void AttributeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HC_ATTRIBUTE = attributeToolStripMenuItem1.ForeColor;
            SaveColors();
        }

        private void CommentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HC_COMMENT = commentToolStripMenuItem1.ForeColor;
            SaveColors();
        }

        private void InnertextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HC_INNERTEXT = innertextToolStripMenuItem1.ForeColor;
            SaveColors();
        }
    }
}
