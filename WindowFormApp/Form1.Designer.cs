namespace WindowFormApp
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputGrayImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainInterfaceTable = new System.Windows.Forms.TableLayoutPanel();
            this.MenuTable = new System.Windows.Forms.TableLayoutPanel();
            this.MenuLabel = new System.Windows.Forms.Label();
            this.SplitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NsuperPixeVal = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.weightRatioVal = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nbLoopVal = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.vignettePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imagePuzzleLocation = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.thresh1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.thresh2 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.minScale1 = new System.Windows.Forms.NumericUpDown();
            this.minScale2 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.maxAmbi = new System.Windows.Forms.NumericUpDown();
            this.lblMinScal = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.threshRansac = new System.Windows.Forms.NumericUpDown();
            this.minScore = new System.Windows.Forms.NumericUpDown();
            this.lblMinScoreMatch = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.mainInterfaceTable.SuspendLayout();
            this.MenuTable.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NsuperPixeVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightRatioVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbLoopVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePuzzleLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresh1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresh2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minScale1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minScale2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxAmbi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshRansac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minScore)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1019, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 26);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputGrayImagesToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // inputGrayImagesToolStripMenuItem
            // 
            this.inputGrayImagesToolStripMenuItem.Name = "inputGrayImagesToolStripMenuItem";
            this.inputGrayImagesToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.inputGrayImagesToolStripMenuItem.Text = "Dataset Image Folder";
            // 
            // mainInterfaceTable
            // 
            this.mainInterfaceTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.mainInterfaceTable.ColumnCount = 2;
            this.mainInterfaceTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.63112F));
            this.mainInterfaceTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.36888F));
            this.mainInterfaceTable.Controls.Add(this.MenuTable, 1, 0);
            this.mainInterfaceTable.Controls.Add(this.vignettePanel, 0, 1);
            this.mainInterfaceTable.Controls.Add(this.pictureBox1, 1, 1);
            this.mainInterfaceTable.Controls.Add(this.splitContainer1, 0, 0);
            this.mainInterfaceTable.Controls.Add(this.panel1, 0, 2);
            this.mainInterfaceTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainInterfaceTable.Location = new System.Drawing.Point(0, 30);
            this.mainInterfaceTable.Name = "mainInterfaceTable";
            this.mainInterfaceTable.RowCount = 3;
            this.mainInterfaceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainInterfaceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.mainInterfaceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.mainInterfaceTable.Size = new System.Drawing.Size(1019, 485);
            this.mainInterfaceTable.TabIndex = 1;
            // 
            // MenuTable
            // 
            this.MenuTable.ColumnCount = 1;
            this.MenuTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MenuTable.Controls.Add(this.MenuLabel, 0, 0);
            this.MenuTable.Controls.Add(this.SplitButton, 0, 2);
            this.MenuTable.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.MenuTable.Controls.Add(this.button1, 0, 3);
            this.MenuTable.Controls.Add(this.button2, 0, 4);
            this.MenuTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuTable.Location = new System.Drawing.Point(824, 4);
            this.MenuTable.Name = "MenuTable";
            this.MenuTable.RowCount = 5;
            this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MenuTable.Size = new System.Drawing.Size(191, 228);
            this.MenuTable.TabIndex = 0;
            // 
            // MenuLabel
            // 
            this.MenuLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MenuLabel.AutoSize = true;
            this.MenuLabel.Location = new System.Drawing.Point(74, 4);
            this.MenuLabel.Name = "MenuLabel";
            this.MenuLabel.Size = new System.Drawing.Size(43, 17);
            this.MenuLabel.TabIndex = 0;
            this.MenuLabel.Text = "Menu";
            // 
            // SplitButton
            // 
            this.SplitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SplitButton.Location = new System.Drawing.Point(46, 163);
            this.SplitButton.Name = "SplitButton";
            this.SplitButton.Size = new System.Drawing.Size(98, 27);
            this.SplitButton.TabIndex = 1;
            this.SplitButton.Text = "Split Puzzle";
            this.SplitButton.UseVisualStyleBackColor = true;
            this.SplitButton.Click += new System.EventHandler(this.SplitButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.6506F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.3494F));
            this.tableLayoutPanel1.Controls.Add(this.NsuperPixeVal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.weightRatioVal, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.nbLoopVal, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(185, 126);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // NsuperPixeVal
            // 
            this.NsuperPixeVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NsuperPixeVal.Location = new System.Drawing.Point(121, 10);
            this.NsuperPixeVal.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NsuperPixeVal.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NsuperPixeVal.Name = "NsuperPixeVal";
            this.NsuperPixeVal.Size = new System.Drawing.Size(57, 22);
            this.NsuperPixeVal.TabIndex = 0;
            this.NsuperPixeVal.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "N SuperPixels";
            // 
            // weightRatioVal
            // 
            this.weightRatioVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.weightRatioVal.DecimalPlaces = 1;
            this.weightRatioVal.Location = new System.Drawing.Point(121, 52);
            this.weightRatioVal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.weightRatioVal.Name = "weightRatioVal";
            this.weightRatioVal.Size = new System.Drawing.Size(57, 22);
            this.weightRatioVal.TabIndex = 2;
            this.weightRatioVal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 42);
            this.label2.TabIndex = 3;
            this.label2.Text = "weight spatial\\color dist";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nb Loop";
            // 
            // nbLoopVal
            // 
            this.nbLoopVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nbLoopVal.Location = new System.Drawing.Point(121, 94);
            this.nbLoopVal.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nbLoopVal.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nbLoopVal.Name = "nbLoopVal";
            this.nbLoopVal.Size = new System.Drawing.Size(57, 22);
            this.nbLoopVal.TabIndex = 5;
            this.nbLoopVal.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Location = new System.Drawing.Point(58, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Match ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.Location = new System.Drawing.Point(58, 240);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 1);
            this.button2.TabIndex = 4;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // vignettePanel
            // 
            this.vignettePanel.AutoScroll = true;
            this.vignettePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.vignettePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vignettePanel.Location = new System.Drawing.Point(4, 239);
            this.vignettePanel.Name = "vignettePanel";
            this.vignettePanel.Size = new System.Drawing.Size(813, 161);
            this.vignettePanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(824, 239);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 161);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.imagePuzzleLocation);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox3);
            this.splitContainer1.Size = new System.Drawing.Size(813, 228);
            this.splitContainer1.SplitterDistance = 431;
            this.splitContainer1.TabIndex = 4;
            // 
            // imagePuzzleLocation
            // 
            this.imagePuzzleLocation.AllowDrop = true;
            this.imagePuzzleLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePuzzleLocation.Location = new System.Drawing.Point(0, 0);
            this.imagePuzzleLocation.Name = "imagePuzzleLocation";
            this.imagePuzzleLocation.Size = new System.Drawing.Size(431, 228);
            this.imagePuzzleLocation.TabIndex = 0;
            this.imagePuzzleLocation.TabStop = false;
            this.imagePuzzleLocation.DragDrop += new System.Windows.Forms.DragEventHandler(this.imagePuzzleLocation_DragDrop);
            this.imagePuzzleLocation.DragEnter += new System.Windows.Forms.DragEventHandler(this.imagePuzzleLocation_DragEnter);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(378, 228);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMinScoreMatch);
            this.panel1.Controls.Add(this.minScore);
            this.panel1.Controls.Add(this.threshRansac);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lblMinScal);
            this.panel1.Controls.Add(this.maxAmbi);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.minScale2);
            this.panel1.Controls.Add(this.minScale1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.thresh2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.thresh1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 407);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 74);
            this.panel1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "thresh1";
            // 
            // thresh1
            // 
            this.thresh1.DecimalPlaces = 1;
            this.thresh1.Location = new System.Drawing.Point(83, 13);
            this.thresh1.Name = "thresh1";
            this.thresh1.Size = new System.Drawing.Size(42, 22);
            this.thresh1.TabIndex = 1;
            this.thresh1.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "thresh2";
            // 
            // thresh2
            // 
            this.thresh2.DecimalPlaces = 1;
            this.thresh2.Location = new System.Drawing.Point(82, 44);
            this.thresh2.Name = "thresh2";
            this.thresh2.Size = new System.Drawing.Size(43, 22);
            this.thresh2.TabIndex = 3;
            this.thresh2.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(340, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "maxAmbi";
            // 
            // minScale1
            // 
            this.minScale1.DecimalPlaces = 1;
            this.minScale1.Location = new System.Drawing.Point(253, 16);
            this.minScale1.Name = "minScale1";
            this.minScale1.Size = new System.Drawing.Size(43, 22);
            this.minScale1.TabIndex = 6;
            this.minScale1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // minScale2
            // 
            this.minScale2.DecimalPlaces = 1;
            this.minScale2.Location = new System.Drawing.Point(253, 44);
            this.minScale2.Name = "minScale2";
            this.minScale2.Size = new System.Drawing.Size(43, 22);
            this.minScale2.TabIndex = 7;
            this.minScale2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(479, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "thresh ransac";
            // 
            // maxAmbi
            // 
            this.maxAmbi.DecimalPlaces = 2;
            this.maxAmbi.Location = new System.Drawing.Point(410, 30);
            this.maxAmbi.Name = "maxAmbi";
            this.maxAmbi.Size = new System.Drawing.Size(48, 22);
            this.maxAmbi.TabIndex = 10;
            this.maxAmbi.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            // 
            // lblMinScal
            // 
            this.lblMinScal.AutoSize = true;
            this.lblMinScal.Location = new System.Drawing.Point(174, 17);
            this.lblMinScal.Name = "lblMinScal";
            this.lblMinScal.Size = new System.Drawing.Size(73, 17);
            this.lblMinScal.TabIndex = 11;
            this.lblMinScal.Text = "minScale1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(174, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "minScale2";
            // 
            // threshRansac
            // 
            this.threshRansac.DecimalPlaces = 1;
            this.threshRansac.Location = new System.Drawing.Point(581, 30);
            this.threshRansac.Name = "threshRansac";
            this.threshRansac.Size = new System.Drawing.Size(47, 22);
            this.threshRansac.TabIndex = 13;
            this.threshRansac.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // minScore
            // 
            this.minScore.DecimalPlaces = 2;
            this.minScore.Location = new System.Drawing.Point(733, 31);
            this.minScore.Name = "minScore";
            this.minScore.Size = new System.Drawing.Size(51, 22);
            this.minScore.TabIndex = 14;
            this.minScore.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            // 
            // lblMinScoreMatch
            // 
            this.lblMinScoreMatch.AutoSize = true;
            this.lblMinScoreMatch.Location = new System.Drawing.Point(650, 31);
            this.lblMinScoreMatch.Name = "lblMinScoreMatch";
            this.lblMinScoreMatch.Size = new System.Drawing.Size(67, 17);
            this.lblMinScoreMatch.TabIndex = 15;
            this.lblMinScoreMatch.Text = "minScore";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 515);
            this.Controls.Add(this.mainInterfaceTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainInterfaceTable.ResumeLayout(false);
            this.MenuTable.ResumeLayout(false);
            this.MenuTable.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NsuperPixeVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightRatioVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbLoopVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagePuzzleLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thresh1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresh2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minScale1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minScale2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxAmbi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshRansac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minScore)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inputGrayImagesToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainInterfaceTable;
        private System.Windows.Forms.TableLayoutPanel MenuTable;
        private System.Windows.Forms.Label MenuLabel;
        private System.Windows.Forms.Button SplitButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown NsuperPixeVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown weightRatioVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nbLoopVal;
        private System.Windows.Forms.FlowLayoutPanel vignettePanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox imagePuzzleLocation;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown maxAmbi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown minScale2;
        private System.Windows.Forms.NumericUpDown minScale1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown thresh2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown thresh1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblMinScal;
        private System.Windows.Forms.Label lblMinScoreMatch;
        private System.Windows.Forms.NumericUpDown minScore;
        private System.Windows.Forms.NumericUpDown threshRansac;
    }
}

