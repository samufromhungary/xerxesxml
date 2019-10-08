﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLEditor
{
    public partial class xmleditor : Form
    {
        Reader Reader = new Reader();
        Validator Validator = new Validator();
        String xmlname = "testfile.xml";
        String xsdname = "testfile.xsd";
        public xmleditor()
        {
            InitializeComponent();

        }

        private void Xmleditor_Load(object sender, EventArgs e)
        {
            
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
            tabControl.Text = xmlname;
            textBoxReader.Text = Reader.Read(xmlname);
            validateToolStripMenuItem.Enabled = true;
        }

        private void ValidateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(textBoxReader.Text.Length != 0)
            {

                bool isValid = Validator.Validate(xsdname, xmlname);
                if (isValid)
                {
                    infoTextBox.Text = "Validation was successful";
                    pictureBoxValid.BackColor = System.Drawing.Color.Lime;
                    pictureBoxValid.Visible = true;
                }
                else
                {
                    infoTextBox.Text = "Validation was unsuccessful";
                    pictureBoxValid.BackColor = System.Drawing.Color.Red;
                    pictureBoxValid.Visible = true;
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
            statusLabel.Text = "Line " + line.ToString();
        }
    }
}
