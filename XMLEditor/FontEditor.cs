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
    public partial class FontEditor : Form
    {
        Font CUSTOMFONT;
        public FontEditor()
        {
            InitializeComponent();
        }

        public FontEditor(Font CUSTOMFONT)
        {
            this.CUSTOMFONT = CUSTOMFONT;
        }

        public Font getCustomFont()
        {
            return CUSTOMFONT;
        }

        private void FontEditor_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                comboBoxFontStyle.Items.Add(font.Name);
            }
        }

        private void ComboBoxFontStyle_SelectedIndexChanged(object sender, EventArgs e)
        {

            labelPreview.Font = new Font(comboBoxFontStyle.Text, labelPreview.Font.Size);
            CUSTOMFONT = labelPreview.Font;
        }

        private void ComboBoxFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelPreview.Font = new Font(labelPreview.Font.FontFamily, float.Parse(comboBoxFontSize.SelectedItem.ToString()));
            CUSTOMFONT = labelPreview.Font;
        }

        private void BtnDefaultFont_Click(object sender, EventArgs e)
        {
            labelPreview.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
            CUSTOMFONT = labelPreview.Font;
        }

        private void BtnSaveFont_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You sure?", "asd", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                xmleditor xmleditor = new xmleditor();
                xmleditor.SetFont(labelPreview.Font.FontFamily, labelPreview.Font.Size);
            }

            Close();
        }
    }
}
