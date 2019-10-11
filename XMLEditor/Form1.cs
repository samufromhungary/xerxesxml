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

namespace XMLEditor
{
    public partial class xmleditor : Form
    {
        Reader Reader = new Reader();
        Validator Validator = new Validator();
        Explorer Explorer = new Explorer();
        DateFormat DateFormat = new DateFormat();
        RichTextBox richTextBox = new RichTextBox();
        TabPage tabPage = new TabPage("Page");
        String xmlname;
        String xsdname;
        String msg;
        String savedxsd = "";
        float normal = 8.25F;
        float actual = 8.25F;
        bool autosave = false;
        bool wassaved = false;
        public xmleditor()
        {
            InitializeComponent();

        }

        private void Xmleditor_Load(object sender, EventArgs e)
        {
        }

        public void OpenFile()
        {
            xmlname = Explorer.SelectedFilePathXml();
            Reset();
            //var selectedTab = tabControlEditor.SelectedTab;
            //selectedTab.Controls.Add(richTextBox);
            textBoxReader.Text = Reader.Read(xmlname, infoTextBox);
            tabControl.Text = xmlname;
            validateToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;

        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void ValidateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ValidateFile();
        }
        void ValidateFile()
        {
            if (textBoxReader.Text.Length != 0)
            {
                bool? isValid = false;
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
                    msg = "Validation was successful";
                    infoTextBox.Text += DateFormat.AppendMessage(msg);
                    pictureBoxValid.BackColor = System.Drawing.Color.Lime;
                    pictureBoxValid.Visible = true;
                }
                else if (isValid == false)
                {
                    msg = "Validation was unsuccessful";
                    infoTextBox.Text += DateFormat.AppendMessage(msg);
                    pictureBoxValid.BackColor = System.Drawing.Color.Red;
                    pictureBoxValid.Visible = true;
                }
                else
                {
                    msg = "No XSD found";
                    infoTextBox.Text += DateFormat.AppendMessage(msg);
                }
            }
        }

        void Reset()
        {
            tabControl.Text = "";
            textBoxReader.Text = "";
            pictureBoxValid.Visible = false;
            validateToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
        }

        private void TextBoxReader_SelectionChanged(object sender, EventArgs e)
        {
            int index = textBoxReader.SelectionStart;
            int line = textBoxReader.GetLineFromCharIndex(index);
            statusLabel.Visible = true;
            int nums = textBoxReader.Lines.Length;
            statusLabel.Text = String.Format("Lines: {0} (Current: {1}) ", nums.ToString(), (line + 1).ToString());

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void TextBoxReader_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.O)
            {
                OpenFile();
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                Reader.Save(textBoxReader.Text,xmlname,infoTextBox);
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                ValidateFile();
            }
            if (e.Control && e.KeyCode == Keys.B)
            {
                savedxsd = "";
                pictureBoxValid.Visible = false;
                ValidateFile();
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reader.Save(textBoxReader.Text, xmlname,infoTextBox);
            wassaved = true;
        }

        private void TabControlEditor_DoubleClick(object sender, EventArgs e)
        {
            tabControlEditor.TabPages.Add(tabPage);
            richTextBox.Dock = DockStyle.Fill;
            tabPage.Controls.Add(new RichTextBox());
        }

        private void TextBoxReader_TextChanged(object sender, EventArgs e)
        {
        }
 

        private void PanelBox_Paint(object sender, PaintEventArgs e)
        {

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
                    Reader.Save(textBoxReader.Text, xmlname, infoTextBox);
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
                    Reader.Save(textBoxReader.Text, xmlname, infoTextBox);
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
    }
}
