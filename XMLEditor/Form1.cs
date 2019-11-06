using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Threading;
using System.IO;
using System.Xml;
using System.Windows.Media;
using AngleSharp.Text;
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
            //tabControlEditor.Text = "";
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

            wassaved = true;
        }


        private void PictureBoxNormalize_Click(object sender, EventArgs e)
        {
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", normal);
            actual = normal;
        }

        private void PictureBoxZoom_Click(object sender, EventArgs e)
        {
            actual += 0.25F;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", actual);
        }

        private void PictureBoxDezoom_Click(object sender, EventArgs e)
        {
            actual -= 0.25F;
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", actual);
        }

        private void AutoSaveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (autosave)
            {
                autosave = false;
                autoSaveToolStripMenuItem.Text = "Auto Save (Currently: OFF)";
                MessageBox.Show("Autosave turned off.");
            }
            else
            {
                autosave = true;
                autoSaveToolStripMenuItem.Text = "Auto Save (Currently: ON)";
                MessageBox.Show("Autosave turned on.");
                while (true)
                {
                    Thread.Sleep(1000);
                    Reader.Save(PageIterator(), xmlname, infoTextBox, tabControlEditor);
                }
            }
        }

        private void AutoSave()
        {
            int timer = 0;
            while (true)
            {
                if (timer % 10 == 0)
                {
                    Reader.Save(PageIterator(), xmlname, infoTextBox, tabControlEditor);
                    MessageBox.Show("Automatically Saved");
                }
                if (wassaved)
                {
                    timer = 0;
                    wassaved = false;
                    MessageBox.Show("Saved while autosave was turned on. Timer reseted.");
                }
                timer += 1;
                Thread.Sleep(1000);

            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
        void NewTab()
        {
            CustomTab ct = new CustomTab();
            ct.textbox.Font = LoadSettings();
            ct.textbox.SelectionChanged += RichTextBox_SelectionChanged;
            ct.textbox.TextChanged += RichTextBox_TextChanged;
            ct.Text = "Untitled";
            tabControlEditor.TabPages.Add(ct);
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
                MessageBox.Show("anyád");
            }
            else
            {
                xmlname = Path.GetFullPath(selectedTab.Text);
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

        private void PanelBox_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
