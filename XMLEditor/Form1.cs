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

namespace XMLEditor
{
    public partial class xmleditor : Form
    {
        Reader Reader = new Reader();
        Validator Validator = new Validator();
        Explorer Explorer = new Explorer();
        DateFormat DateFormat = new DateFormat();
        String xmlname;
        String xsdname;
        String msg;
        bool isTrue = true;
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
            textBoxReader.Text = Reader.Read(xmlname);
            tabControl.Text = xmlname;
            validateToolStripMenuItem.Enabled = true;

        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void ValidateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBoxReader.Text.Length != 0)
            {
                xsdname = Explorer.SelectedFilePathXsd();
                bool? isValid = Validator.Validate(xsdname, xmlname);
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
                    msg = "File extension error";
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
        }

        private void TextBoxReader_SelectionChanged(object sender, EventArgs e)
        {
            int index = textBoxReader.SelectionStart;
            int line = textBoxReader.GetLineFromCharIndex(index);
            statusLabel.Visible = true;
            int nums = textBoxReader.Lines.Length;
            statusLabel.Text = String.Format("Lines: {0} (Current: {1}) ", nums.ToString(), line.ToString());

        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void TextBoxReader_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.O)
            {
                OpenFile();
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reader.Save(textBoxReader.Text, xmlname);
        }
    }
}
