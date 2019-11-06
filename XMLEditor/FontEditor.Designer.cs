namespace XMLEditor
{
    partial class FontEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontEditor));
            this.btnSaveFont = new System.Windows.Forms.Button();
            this.btnDefaultFont = new System.Windows.Forms.Button();
            this.labelPreview = new System.Windows.Forms.Label();
            this.comboBoxFontStyle = new System.Windows.Forms.ComboBox();
            this.comboBoxFontSize = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSaveFont
            // 
            this.btnSaveFont.Location = new System.Drawing.Point(139, 12);
            this.btnSaveFont.Name = "btnSaveFont";
            this.btnSaveFont.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFont.TabIndex = 0;
            this.btnSaveFont.Text = "Save";
            this.btnSaveFont.UseVisualStyleBackColor = true;
            this.btnSaveFont.Click += new System.EventHandler(this.BtnSaveFont_Click);
            // 
            // btnDefaultFont
            // 
            this.btnDefaultFont.Location = new System.Drawing.Point(139, 43);
            this.btnDefaultFont.Name = "btnDefaultFont";
            this.btnDefaultFont.Size = new System.Drawing.Size(75, 23);
            this.btnDefaultFont.TabIndex = 1;
            this.btnDefaultFont.Text = "Default";
            this.btnDefaultFont.UseVisualStyleBackColor = true;
            this.btnDefaultFont.Click += new System.EventHandler(this.BtnDefaultFont_Click);
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.Location = new System.Drawing.Point(136, 150);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(129, 16);
            this.labelPreview.TabIndex = 2;
            this.labelPreview.Text = "Árvíztűrő tükörfúrógép";
            // 
            // comboBoxFontStyle
            // 
            this.comboBoxFontStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFontStyle.FormattingEnabled = true;
            this.comboBoxFontStyle.Location = new System.Drawing.Point(12, 12);
            this.comboBoxFontStyle.Name = "comboBoxFontStyle";
            this.comboBoxFontStyle.Size = new System.Drawing.Size(121, 24);
            this.comboBoxFontStyle.TabIndex = 3;
            this.comboBoxFontStyle.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFontStyle_SelectedIndexChanged);
            // 
            // comboBoxFontSize
            // 
            this.comboBoxFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFontSize.FormattingEnabled = true;
            this.comboBoxFontSize.Items.AddRange(new object[] {
            "6",
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "18",
            "24",
            "30",
            "36",
            "48",
            "60",
            "72",
            "84"});
            this.comboBoxFontSize.Location = new System.Drawing.Point(12, 42);
            this.comboBoxFontSize.Name = "comboBoxFontSize";
            this.comboBoxFontSize.Size = new System.Drawing.Size(121, 24);
            this.comboBoxFontSize.TabIndex = 4;
            this.comboBoxFontSize.SelectedIndexChanged += new System.EventHandler(this.ComboBoxFontSize_SelectedIndexChanged);
            // 
            // FontEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 304);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxFontSize);
            this.Controls.Add(this.comboBoxFontStyle);
            this.Controls.Add(this.labelPreview);
            this.Controls.Add(this.btnDefaultFont);
            this.Controls.Add(this.btnSaveFont);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FontEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor";
            this.Load += new System.EventHandler(this.FontEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveFont;
        private System.Windows.Forms.Button btnDefaultFont;
        private System.Windows.Forms.Label labelPreview;
        private System.Windows.Forms.ComboBox comboBoxFontStyle;
        private System.Windows.Forms.ComboBox comboBoxFontSize;
    }
}