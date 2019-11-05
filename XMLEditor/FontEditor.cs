using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XMLEditor
{
    [Serializable]
    public partial class FontEditor : Form
    {
        public FontEditor()
        {
            InitializeComponent();
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

            labelPreview.Font = new System.Drawing.Font(comboBoxFontStyle.Text, labelPreview.Font.Size);
        }

        private void ComboBoxFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelPreview.Font = new System.Drawing.Font(labelPreview.Font.FontFamily, float.Parse(comboBoxFontSize.SelectedItem.ToString()));
        }

        private void BtnDefaultFont_Click(object sender, EventArgs e)
        {
            labelPreview.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
        }

        private void BtnSaveFont_Click(object sender, EventArgs e)
        {
            /*            DialogResult dialogResult = MessageBox.Show("You sure?", "asd", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.Yes)
                        {
                            xmleditor xmleditor = new xmleditor();
                            xmleditor.SetFont(labelPreview.Font.FontFamily, labelPreview.Font.Size);
                        }

                        Close();*/

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("settings.txt", FileMode.Create, FileAccess.Write);
            CustomFont customfont = new CustomFont(labelPreview.Font.FontFamily, labelPreview.Font.Size);
            formatter.Serialize(stream, customfont);
            stream.Close();
        }
    }
}
