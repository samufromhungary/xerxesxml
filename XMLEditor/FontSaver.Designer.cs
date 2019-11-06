namespace XMLEditor
{
    partial class FontSaver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FontSaver));
            this.btnSaveEditorFont = new System.Windows.Forms.Button();
            this.btnSaveBothFont = new System.Windows.Forms.Button();
            this.btnSaveInfoFont = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaveEditorFont
            // 
            this.btnSaveEditorFont.Location = new System.Drawing.Point(12, 12);
            this.btnSaveEditorFont.Name = "btnSaveEditorFont";
            this.btnSaveEditorFont.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEditorFont.TabIndex = 0;
            this.btnSaveEditorFont.Text = "Editor";
            this.btnSaveEditorFont.UseVisualStyleBackColor = true;
            this.btnSaveEditorFont.Click += new System.EventHandler(this.BtnSaveEditorFont_Click);
            // 
            // btnSaveBothFont
            // 
            this.btnSaveBothFont.Location = new System.Drawing.Point(55, 41);
            this.btnSaveBothFont.Name = "btnSaveBothFont";
            this.btnSaveBothFont.Size = new System.Drawing.Size(75, 23);
            this.btnSaveBothFont.TabIndex = 1;
            this.btnSaveBothFont.Text = "Both";
            this.btnSaveBothFont.UseVisualStyleBackColor = true;
            this.btnSaveBothFont.Click += new System.EventHandler(this.BtnSaveBothFont_Click);
            // 
            // btnSaveInfoFont
            // 
            this.btnSaveInfoFont.Location = new System.Drawing.Point(93, 12);
            this.btnSaveInfoFont.Name = "btnSaveInfoFont";
            this.btnSaveInfoFont.Size = new System.Drawing.Size(75, 23);
            this.btnSaveInfoFont.TabIndex = 2;
            this.btnSaveInfoFont.Text = "Infobox";
            this.btnSaveInfoFont.UseVisualStyleBackColor = true;
            this.btnSaveInfoFont.Click += new System.EventHandler(this.BtnSaveInfoFont_Click);
            // 
            // FontSaver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 76);
            this.ControlBox = false;
            this.Controls.Add(this.btnSaveInfoFont);
            this.Controls.Add(this.btnSaveBothFont);
            this.Controls.Add(this.btnSaveEditorFont);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FontSaver";
            this.Text = "FontSaver";
            this.Load += new System.EventHandler(this.FontSaver_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveEditorFont;
        private System.Windows.Forms.Button btnSaveBothFont;
        private System.Windows.Forms.Button btnSaveInfoFont;
    }
}