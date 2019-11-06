namespace XMLEditor
{
    partial class xmleditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(xmleditor));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlEditor = new System.Windows.Forms.TabControl();
            this.infoTextBox = new System.Windows.Forms.RichTextBox();
            this.panelBox = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.pictureBoxValid = new System.Windows.Forms.PictureBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.pictureBoxDezoom = new System.Windows.Forms.PictureBox();
            this.pictureBoxNormalize = new System.Windows.Forms.PictureBox();
            this.pictureBoxZoom = new System.Windows.Forms.PictureBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.panelBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxValid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDezoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNormalize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(11, 11);
            this.menuStrip.MinimumSize = new System.Drawing.Size(299, 27);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(299, 27);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.validateToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(41, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.saveAsToolStripMenuItem.Text = "Save As..";
            // 
            // validateToolStripMenuItem
            // 
            this.validateToolStripMenuItem.Enabled = false;
            this.validateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("validateToolStripMenuItem.Image")));
            this.validateToolStripMenuItem.Name = "validateToolStripMenuItem";
            this.validateToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.validateToolStripMenuItem.Text = "Validate";
            this.validateToolStripMenuItem.Click += new System.EventHandler(this.ValidateToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoSaveToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(71, 23);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // autoSaveToolStripMenuItem
            // 
            this.autoSaveToolStripMenuItem.Enabled = false;
            this.autoSaveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("autoSaveToolStripMenuItem.Image")));
            this.autoSaveToolStripMenuItem.Name = "autoSaveToolStripMenuItem";
            this.autoSaveToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.autoSaveToolStripMenuItem.Text = "Auto Save";
            this.autoSaveToolStripMenuItem.Click += new System.EventHandler(this.AutoSaveToolStripMenuItem_Click_1);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(59, 23);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // tabControlEditor
            // 
            this.tabControlEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlEditor.Location = new System.Drawing.Point(21, 41);
            this.tabControlEditor.MinimumSize = new System.Drawing.Size(400, 200);
            this.tabControlEditor.Name = "tabControlEditor";
            this.tabControlEditor.SelectedIndex = 0;
            this.tabControlEditor.Size = new System.Drawing.Size(1205, 286);
            this.tabControlEditor.TabIndex = 1;
            this.tabControlEditor.SelectedIndexChanged += new System.EventHandler(this.TabControlEditor_SelectedIndexChanged);
            this.tabControlEditor.DoubleClick += new System.EventHandler(this.tabControlEditor_DoubleClick);
            this.tabControlEditor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControlEditor_KeyDown);
            this.tabControlEditor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tabControlEditor_KeyPress);
            // 
            // infoTextBox
            // 
            this.infoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.infoTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.infoTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.infoTextBox.Location = new System.Drawing.Point(25, 369);
            this.infoTextBox.MaximumSize = new System.Drawing.Size(1307, 167);
            this.infoTextBox.MinimumSize = new System.Drawing.Size(300, 100);
            this.infoTextBox.Name = "infoTextBox";
            this.infoTextBox.ReadOnly = true;
            this.infoTextBox.Size = new System.Drawing.Size(1207, 167);
            this.infoTextBox.TabIndex = 0;
            this.infoTextBox.Text = "";
            // 
            // panelBox
            // 
            this.panelBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBox.Controls.Add(this.listBox1);
            this.panelBox.Controls.Add(this.pictureBoxValid);
            this.panelBox.Controls.Add(this.statusLabel);
            this.panelBox.Controls.Add(this.pictureBoxDezoom);
            this.panelBox.Controls.Add(this.pictureBoxNormalize);
            this.panelBox.Controls.Add(this.pictureBoxZoom);
            this.panelBox.Controls.Add(this.menuStrip);
            this.panelBox.Controls.Add(this.tabControlEditor);
            this.panelBox.Controls.Add(this.infoTextBox);
            this.panelBox.Location = new System.Drawing.Point(3, -2);
            this.panelBox.MinimumSize = new System.Drawing.Size(600, 500);
            this.panelBox.Name = "panelBox";
            this.panelBox.Size = new System.Drawing.Size(1281, 564);
            this.panelBox.TabIndex = 4;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(569, 211);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(121, 116);
            this.listBox1.TabIndex = 7;
            this.listBox1.Visible = false;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // pictureBoxValid
            // 
            this.pictureBoxValid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxValid.BackColor = System.Drawing.Color.Lime;
            this.pictureBoxValid.Location = new System.Drawing.Point(1222, 41);
            this.pictureBoxValid.MaximumSize = new System.Drawing.Size(10, 13);
            this.pictureBoxValid.MinimumSize = new System.Drawing.Size(10, 13);
            this.pictureBoxValid.Name = "pictureBoxValid";
            this.pictureBoxValid.Size = new System.Drawing.Size(10, 13);
            this.pictureBoxValid.TabIndex = 0;
            this.pictureBoxValid.TabStop = false;
            this.pictureBoxValid.Visible = false;
            // 
            // statusLabel
            // 
            this.statusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(1044, 330);
            this.statusLabel.MinimumSize = new System.Drawing.Size(30, 16);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(30, 16);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Visible = false;
            // 
            // pictureBoxDezoom
            // 
            this.pictureBoxDezoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDezoom.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxDezoom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxDezoom.BackgroundImage")));
            this.pictureBoxDezoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxDezoom.Location = new System.Drawing.Point(1191, 20);
            this.pictureBoxDezoom.MinimumSize = new System.Drawing.Size(18, 18);
            this.pictureBoxDezoom.Name = "pictureBoxDezoom";
            this.pictureBoxDezoom.Size = new System.Drawing.Size(18, 18);
            this.pictureBoxDezoom.TabIndex = 5;
            this.pictureBoxDezoom.TabStop = false;
            this.pictureBoxDezoom.Click += new System.EventHandler(this.PictureBoxDezoom_Click);
            // 
            // pictureBoxNormalize
            // 
            this.pictureBoxNormalize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxNormalize.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxNormalize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxNormalize.BackgroundImage")));
            this.pictureBoxNormalize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxNormalize.Location = new System.Drawing.Point(1167, 20);
            this.pictureBoxNormalize.MinimumSize = new System.Drawing.Size(18, 18);
            this.pictureBoxNormalize.Name = "pictureBoxNormalize";
            this.pictureBoxNormalize.Size = new System.Drawing.Size(18, 18);
            this.pictureBoxNormalize.TabIndex = 6;
            this.pictureBoxNormalize.TabStop = false;
            this.pictureBoxNormalize.Click += new System.EventHandler(this.PictureBoxNormalize_Click);
            // 
            // pictureBoxZoom
            // 
            this.pictureBoxZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxZoom.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxZoom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxZoom.BackgroundImage")));
            this.pictureBoxZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxZoom.Location = new System.Drawing.Point(1143, 20);
            this.pictureBoxZoom.MinimumSize = new System.Drawing.Size(18, 18);
            this.pictureBoxZoom.Name = "pictureBoxZoom";
            this.pictureBoxZoom.Size = new System.Drawing.Size(18, 18);
            this.pictureBoxZoom.TabIndex = 4;
            this.pictureBoxZoom.TabStop = false;
            this.pictureBoxZoom.Click += new System.EventHandler(this.PictureBoxZoom_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "XML Format (*.xml)|*.xml";
            // 
            // xmleditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1270, 561);
            this.Controls.Add(this.panelBox);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "xmleditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xerxes";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelBox.ResumeLayout(false);
            this.panelBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxValid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDezoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNormalize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControlEditor;
        private System.Windows.Forms.ToolStripMenuItem validateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.RichTextBox infoTextBox;
        private System.Windows.Forms.Panel panelBox;
        private System.Windows.Forms.PictureBox pictureBoxDezoom;
        private System.Windows.Forms.PictureBox pictureBoxZoom;
        private System.Windows.Forms.PictureBox pictureBoxNormalize;
        private System.Windows.Forms.ToolStripMenuItem autoSaveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.PictureBox pictureBoxValid;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ListBox listBox1;
    }
}

