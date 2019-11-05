using System;
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
    public partial class FontSaver : Form
    {
        FontEditor fontEditor = new FontEditor();
        public Font FONT;
        public String TYPE;
        public bool clicked = false;
        public FontSaver()
        {
            InitializeComponent();
            SetFont();
            fontEditor.Close();
        }

        public void SetFont()
        {
            FONT = fontEditor.getCustomFont();
        }

        public Font GetFont()
        {
            return FONT;
        } 

        public String GetType()
        {
            return TYPE;
        }

        public bool GetClicked()
        {
            return clicked;
        }

        private void FontSaver_Load(object sender, EventArgs e)
        {
            SetFont();
            fontEditor.Close();
        }

        private void BtnSaveEditorFont_Click(object sender, EventArgs e)
        {
            TYPE = "EDITOR";
            clicked = true;
        }

        private void BtnSaveInfoFont_Click(object sender, EventArgs e)
        {
            TYPE = "INFO";
            clicked = true;
        }

        private void BtnSaveBothFont_Click(object sender, EventArgs e)
        {
            TYPE = "BOTH";
            clicked = true;
        }
    }
}
