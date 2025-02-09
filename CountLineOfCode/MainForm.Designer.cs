namespace CountLineOfCode
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem("Code");
            ListViewItem listViewItem2 = new ListViewItem("Comment");
            ListViewItem listViewItem3 = new ListViewItem("Empty");
            ListViewItem listViewItem4 = new ListViewItem("TOTAL");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelTop = new Panel();
            groupBoxIndividual = new GroupBox();
            panelCover = new Panel();
            tabControl1 = new TabControl();
            panelBottom = new Panel();
            groupBoxFileInfo = new GroupBox();
            labelFiles = new Label();
            textBoxFiles = new TextBox();
            labelExtension = new Label();
            textBoxExtension = new TextBox();
            groupBoxControl = new GroupBox();
            buttonExit = new Button();
            buttonSave = new Button();
            buttonFile = new Button();
            buttonPrint = new Button();
            buttonClear = new Button();
            buttonFolder = new Button();
            groupBoxOverall = new GroupBox();
            listViewOverall = new ListView();
            columnHeaderCategory = new ColumnHeader();
            columnHeaderLines = new ColumnHeader();
            columnHeaderRate = new ColumnHeader();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openFileToolStripMenuItem = new ToolStripMenuItem();
            openFolderToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            printToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            informationToolStripMenuItem = new ToolStripMenuItem();
            panelTop.SuspendLayout();
            groupBoxIndividual.SuspendLayout();
            panelBottom.SuspendLayout();
            groupBoxFileInfo.SuspendLayout();
            groupBoxControl.SuspendLayout();
            groupBoxOverall.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(groupBoxIndividual);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 35);
            panelTop.Margin = new Padding(4, 5, 4, 5);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(914, 538);
            panelTop.TabIndex = 0;
            // 
            // groupBoxIndividual
            // 
            groupBoxIndividual.Controls.Add(panelCover);
            groupBoxIndividual.Controls.Add(tabControl1);
            groupBoxIndividual.ForeColor = Color.FromArgb(219, 219, 219);
            groupBoxIndividual.Location = new Point(17, 5);
            groupBoxIndividual.Margin = new Padding(4, 5, 4, 5);
            groupBoxIndividual.Name = "groupBoxIndividual";
            groupBoxIndividual.Padding = new Padding(4, 5, 4, 5);
            groupBoxIndividual.Size = new Size(880, 528);
            groupBoxIndividual.TabIndex = 0;
            groupBoxIndividual.TabStop = false;
            groupBoxIndividual.Text = "Individual Status";
            // 
            // panelCover
            // 
            panelCover.BackColor = Color.FromArgb(56, 56, 56);
            panelCover.Dock = DockStyle.Fill;
            panelCover.Location = new Point(4, 29);
            panelCover.Margin = new Padding(4, 5, 4, 5);
            panelCover.Name = "panelCover";
            panelCover.Size = new Size(872, 494);
            panelCover.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Alignment = TabAlignment.Bottom;
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.Location = new Point(4, 29);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(872, 494);
            tabControl1.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(groupBoxFileInfo);
            panelBottom.Controls.Add(groupBoxControl);
            panelBottom.Controls.Add(groupBoxOverall);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 580);
            panelBottom.Margin = new Padding(4, 5, 4, 5);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(914, 220);
            panelBottom.TabIndex = 1;
            // 
            // groupBoxFileInfo
            // 
            groupBoxFileInfo.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBoxFileInfo.Controls.Add(labelFiles);
            groupBoxFileInfo.Controls.Add(textBoxFiles);
            groupBoxFileInfo.Controls.Add(labelExtension);
            groupBoxFileInfo.Controls.Add(textBoxExtension);
            groupBoxFileInfo.ForeColor = Color.FromArgb(219, 219, 219);
            groupBoxFileInfo.Location = new Point(349, 3);
            groupBoxFileInfo.Margin = new Padding(4, 5, 4, 5);
            groupBoxFileInfo.Name = "groupBoxFileInfo";
            groupBoxFileInfo.Padding = new Padding(4, 5, 4, 5);
            groupBoxFileInfo.Size = new Size(297, 197);
            groupBoxFileInfo.TabIndex = 7;
            groupBoxFileInfo.TabStop = false;
            groupBoxFileInfo.Text = "File Info.";
            // 
            // labelFiles
            // 
            labelFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelFiles.AutoSize = true;
            labelFiles.Location = new Point(9, 118);
            labelFiles.Margin = new Padding(4, 0, 4, 0);
            labelFiles.Name = "labelFiles";
            labelFiles.Size = new Size(232, 25);
            labelFiles.TabIndex = 10;
            labelFiles.Text = "Number of Files Processed";
            // 
            // textBoxFiles
            // 
            textBoxFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxFiles.BackColor = Color.FromArgb(56, 56, 56);
            textBoxFiles.BorderStyle = BorderStyle.FixedSingle;
            textBoxFiles.ForeColor = Color.FromArgb(219, 219, 219);
            textBoxFiles.Location = new Point(10, 148);
            textBoxFiles.Margin = new Padding(4, 5, 4, 5);
            textBoxFiles.Name = "textBoxFiles";
            textBoxFiles.Size = new Size(279, 31);
            textBoxFiles.TabIndex = 9;
            // 
            // labelExtension
            // 
            labelExtension.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            labelExtension.AutoSize = true;
            labelExtension.Location = new Point(8, 29);
            labelExtension.Margin = new Padding(4, 0, 4, 0);
            labelExtension.Name = "labelExtension";
            labelExtension.Size = new Size(197, 25);
            labelExtension.TabIndex = 8;
            labelExtension.Text = "Target File Extension(s)";
            // 
            // textBoxExtension
            // 
            textBoxExtension.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxExtension.BackColor = Color.FromArgb(56, 56, 56);
            textBoxExtension.BorderStyle = BorderStyle.FixedSingle;
            textBoxExtension.Enabled = false;
            textBoxExtension.ForeColor = Color.FromArgb(219, 219, 219);
            textBoxExtension.Location = new Point(10, 59);
            textBoxExtension.Margin = new Padding(4, 5, 4, 5);
            textBoxExtension.Name = "textBoxExtension";
            textBoxExtension.Size = new Size(279, 31);
            textBoxExtension.TabIndex = 8;
            textBoxExtension.Text = "*.c;*.h;*.cpp;*.hpp;*.cs;*.s;";
            // 
            // groupBoxControl
            // 
            groupBoxControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBoxControl.Controls.Add(buttonExit);
            groupBoxControl.Controls.Add(buttonSave);
            groupBoxControl.Controls.Add(buttonFile);
            groupBoxControl.Controls.Add(buttonPrint);
            groupBoxControl.Controls.Add(buttonClear);
            groupBoxControl.Controls.Add(buttonFolder);
            groupBoxControl.ForeColor = Color.FromArgb(219, 219, 219);
            groupBoxControl.Location = new Point(654, 3);
            groupBoxControl.Margin = new Padding(4, 5, 4, 5);
            groupBoxControl.Name = "groupBoxControl";
            groupBoxControl.Padding = new Padding(4, 5, 4, 5);
            groupBoxControl.Size = new Size(243, 197);
            groupBoxControl.TabIndex = 8;
            groupBoxControl.TabStop = false;
            groupBoxControl.Text = "Ctrl Buttons";
            // 
            // buttonExit
            // 
            buttonExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonExit.BackColor = Color.FromArgb(56, 56, 56);
            buttonExit.FlatAppearance.BorderSize = 0;
            buttonExit.FlatStyle = FlatStyle.Flat;
            buttonExit.Location = new Point(127, 143);
            buttonExit.Margin = new Padding(4, 5, 4, 5);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(107, 38);
            buttonExit.TabIndex = 5;
            buttonExit.Text = "&Exit";
            buttonExit.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonSave.BackColor = Color.FromArgb(56, 56, 56);
            buttonSave.FlatAppearance.BorderSize = 0;
            buttonSave.FlatStyle = FlatStyle.Flat;
            buttonSave.Location = new Point(11, 143);
            buttonSave.Margin = new Padding(4, 5, 4, 5);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(107, 38);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "&Save";
            buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonFile
            // 
            buttonFile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonFile.BackColor = Color.FromArgb(56, 56, 56);
            buttonFile.FlatAppearance.BorderSize = 0;
            buttonFile.FlatStyle = FlatStyle.Flat;
            buttonFile.Location = new Point(11, 47);
            buttonFile.Margin = new Padding(4, 5, 4, 5);
            buttonFile.Name = "buttonFile";
            buttonFile.Size = new Size(107, 38);
            buttonFile.TabIndex = 3;
            buttonFile.Text = "File";
            buttonFile.UseVisualStyleBackColor = false;
            // 
            // buttonPrint
            // 
            buttonPrint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonPrint.BackColor = Color.FromArgb(56, 56, 56);
            buttonPrint.FlatAppearance.BorderSize = 0;
            buttonPrint.FlatStyle = FlatStyle.Flat;
            buttonPrint.Location = new Point(127, 47);
            buttonPrint.Margin = new Padding(4, 5, 4, 5);
            buttonPrint.Name = "buttonPrint";
            buttonPrint.Size = new Size(107, 38);
            buttonPrint.TabIndex = 2;
            buttonPrint.Text = "&Print";
            buttonPrint.UseVisualStyleBackColor = false;
            // 
            // buttonClear
            // 
            buttonClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonClear.BackColor = Color.FromArgb(56, 56, 56);
            buttonClear.FlatAppearance.BorderSize = 0;
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.Location = new Point(127, 95);
            buttonClear.Margin = new Padding(4, 5, 4, 5);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(107, 38);
            buttonClear.TabIndex = 1;
            buttonClear.Text = "&Clear";
            buttonClear.UseVisualStyleBackColor = false;
            // 
            // buttonFolder
            // 
            buttonFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonFolder.BackColor = Color.FromArgb(56, 56, 56);
            buttonFolder.FlatAppearance.BorderSize = 0;
            buttonFolder.FlatStyle = FlatStyle.Flat;
            buttonFolder.Font = new Font("맑은 고딕", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonFolder.Location = new Point(11, 95);
            buttonFolder.Margin = new Padding(4, 5, 4, 5);
            buttonFolder.Name = "buttonFolder";
            buttonFolder.Size = new Size(107, 38);
            buttonFolder.TabIndex = 0;
            buttonFolder.Text = "Folder";
            buttonFolder.UseVisualStyleBackColor = false;
            // 
            // groupBoxOverall
            // 
            groupBoxOverall.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            groupBoxOverall.Controls.Add(listViewOverall);
            groupBoxOverall.ForeColor = Color.FromArgb(219, 219, 219);
            groupBoxOverall.Location = new Point(17, 3);
            groupBoxOverall.Margin = new Padding(4, 5, 4, 5);
            groupBoxOverall.Name = "groupBoxOverall";
            groupBoxOverall.Padding = new Padding(4, 5, 4, 5);
            groupBoxOverall.Size = new Size(323, 197);
            groupBoxOverall.TabIndex = 0;
            groupBoxOverall.TabStop = false;
            groupBoxOverall.Text = "Overall Status";
            // 
            // listViewOverall
            // 
            listViewOverall.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            listViewOverall.BackColor = Color.FromArgb(56, 56, 56);
            listViewOverall.BorderStyle = BorderStyle.FixedSingle;
            listViewOverall.Columns.AddRange(new ColumnHeader[] { columnHeaderCategory, columnHeaderLines, columnHeaderRate });
            listViewOverall.ForeColor = Color.FromArgb(219, 219, 219);
            listViewOverall.GridLines = true;
            listViewOverall.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4 });
            listViewOverall.Location = new Point(9, 30);
            listViewOverall.Margin = new Padding(4, 5, 4, 5);
            listViewOverall.Name = "listViewOverall";
            listViewOverall.OwnerDraw = true;
            listViewOverall.Size = new Size(305, 150);
            listViewOverall.TabIndex = 6;
            listViewOverall.UseCompatibleStateImageBehavior = false;
            listViewOverall.View = View.Details;
            // 
            // columnHeaderCategory
            // 
            columnHeaderCategory.Text = "Category";
            columnHeaderCategory.Width = 123;
            // 
            // columnHeaderLines
            // 
            columnHeaderLines.Text = "Lines";
            columnHeaderLines.Width = 90;
            // 
            // columnHeaderRate
            // 
            columnHeaderRate.Text = "Rate (%)";
            columnHeaderRate.Width = 90;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(46, 46, 46);
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(914, 35);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openFileToolStripMenuItem, openFolderToolStripMenuItem, saveAsToolStripMenuItem, printToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem });
            fileToolStripMenuItem.ForeColor = Color.FromArgb(219, 219, 219);
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(55, 29);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openFileToolStripMenuItem
            // 
            openFileToolStripMenuItem.ForeColor = Color.FromArgb(219, 219, 219);
            openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            openFileToolStripMenuItem.Size = new Size(270, 34);
            openFileToolStripMenuItem.Text = "&Open File ...";
            // 
            // openFolderToolStripMenuItem
            // 
            openFolderToolStripMenuItem.ForeColor = Color.FromArgb(219, 219, 219);
            openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            openFolderToolStripMenuItem.Size = new Size(270, 34);
            openFolderToolStripMenuItem.Text = "Open Folder ...";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.ForeColor = Color.FromArgb(219, 219, 219);
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(270, 34);
            saveAsToolStripMenuItem.Text = "&Save as ...";
            // 
            // printToolStripMenuItem
            // 
            printToolStripMenuItem.ForeColor = Color.FromArgb(219, 219, 219);
            printToolStripMenuItem.Name = "printToolStripMenuItem";
            printToolStripMenuItem.Size = new Size(270, 34);
            printToolStripMenuItem.Text = "&Print ...";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.ForeColor = Color.FromArgb(219, 219, 219);
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(267, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.ForeColor = Color.FromArgb(219, 219, 219);
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(270, 34);
            exitToolStripMenuItem.Text = "E&xit";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { informationToolStripMenuItem });
            helpToolStripMenuItem.ForeColor = Color.FromArgb(219, 219, 219);
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(66, 29);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // informationToolStripMenuItem
            // 
            informationToolStripMenuItem.ForeColor = Color.FromArgb(219, 219, 219);
            informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            informationToolStripMenuItem.Size = new Size(208, 34);
            informationToolStripMenuItem.Text = "&Information";
            // 
            // MainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(31, 31, 31);
            ClientSize = new Size(914, 800);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Source Code Line Counter";
            panelTop.ResumeLayout(false);
            groupBoxIndividual.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            groupBoxFileInfo.ResumeLayout(false);
            groupBoxFileInfo.PerformLayout();
            groupBoxControl.ResumeLayout(false);
            groupBoxOverall.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelTop;
        private Panel panelBottom;
        private Label labelFiles;
        private Label labelExtension;
        private TextBox textBoxFiles;
        private TextBox textBoxExtension;
        private GroupBox groupBoxOverall;
        private GroupBox groupBoxControl;
        private GroupBox groupBoxIndividual;
        private GroupBox groupBoxFileInfo;
        private Button buttonFile;
        private Button buttonPrint;
        private Button buttonClear;
        private Button buttonFolder;
        private Button buttonExit;
        private Button buttonSave;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripMenuItem openFolderToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem informationToolStripMenuItem;
        private ColumnHeader columnHeaderCategory;
        private ColumnHeader columnHeaderLines;
        private ColumnHeader columnHeaderRate;
        public ListView listViewOverall;
        public TabControl tabControl1;
        public Panel panelCover;
    }
}
