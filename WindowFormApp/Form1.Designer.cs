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
            this.imagePuzzleLocation = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NsuperPixeVal = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.weightRatioVal = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nbLoopVal = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            this.mainInterfaceTable.SuspendLayout();
            this.MenuTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePuzzleLocation)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NsuperPixeVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightRatioVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbLoopVal)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(919, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
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
            this.mainInterfaceTable.Controls.Add(this.imagePuzzleLocation, 0, 0);
            this.mainInterfaceTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainInterfaceTable.Location = new System.Drawing.Point(0, 30);
            this.mainInterfaceTable.Name = "mainInterfaceTable";
            this.mainInterfaceTable.RowCount = 1;
            this.mainInterfaceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainInterfaceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainInterfaceTable.Size = new System.Drawing.Size(919, 420);
            this.mainInterfaceTable.TabIndex = 1;
            // 
            // MenuTable
            // 
            this.MenuTable.ColumnCount = 1;
            this.MenuTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MenuTable.Controls.Add(this.MenuLabel, 0, 0);
            this.MenuTable.Controls.Add(this.SplitButton, 0, 2);
            this.MenuTable.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.MenuTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuTable.Location = new System.Drawing.Point(743, 4);
            this.MenuTable.Name = "MenuTable";
            this.MenuTable.RowCount = 4;
            this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MenuTable.Size = new System.Drawing.Size(172, 412);
            this.MenuTable.TabIndex = 0;
            // 
            // MenuLabel
            // 
            this.MenuLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MenuLabel.AutoSize = true;
            this.MenuLabel.Location = new System.Drawing.Point(64, 4);
            this.MenuLabel.Name = "MenuLabel";
            this.MenuLabel.Size = new System.Drawing.Size(43, 17);
            this.MenuLabel.TabIndex = 0;
            this.MenuLabel.Text = "Menu";
            // 
            // SplitButton
            // 
            this.SplitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SplitButton.Location = new System.Drawing.Point(37, 163);
            this.SplitButton.Name = "SplitButton";
            this.SplitButton.Size = new System.Drawing.Size(98, 27);
            this.SplitButton.TabIndex = 1;
            this.SplitButton.Text = "Split Puzzle";
            this.SplitButton.UseVisualStyleBackColor = true;
            this.SplitButton.Click += new System.EventHandler(this.SplitButton_Click);
            // 
            // imagePuzzleLocation
            // 
            this.imagePuzzleLocation.AllowDrop = true;
            this.imagePuzzleLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagePuzzleLocation.Location = new System.Drawing.Point(4, 4);
            this.imagePuzzleLocation.Name = "imagePuzzleLocation";
            this.imagePuzzleLocation.Size = new System.Drawing.Size(732, 412);
            this.imagePuzzleLocation.TabIndex = 1;
            this.imagePuzzleLocation.TabStop = false;
            this.imagePuzzleLocation.DragDrop += new System.Windows.Forms.DragEventHandler(this.imagePuzzleLocation_DragDrop);
            this.imagePuzzleLocation.DragEnter += new System.Windows.Forms.DragEventHandler(this.imagePuzzleLocation_DragEnter);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(166, 126);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // NsuperPixeVal
            // 
            this.NsuperPixeVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NsuperPixeVal.Location = new System.Drawing.Point(106, 9);
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
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "N SuperPixels";
            // 
            // weightRatioVal
            // 
            this.weightRatioVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.weightRatioVal.DecimalPlaces = 1;
            this.weightRatioVal.Location = new System.Drawing.Point(106, 50);
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
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "weight spatial\\color dist";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nb Loop";
            // 
            // nbLoopVal
            // 
            this.nbLoopVal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nbLoopVal.Location = new System.Drawing.Point(106, 93);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 450);
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
            ((System.ComponentModel.ISupportInitialize)(this.imagePuzzleLocation)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NsuperPixeVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightRatioVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbLoopVal)).EndInit();
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
        private System.Windows.Forms.PictureBox imagePuzzleLocation;
        private System.Windows.Forms.Label MenuLabel;
        private System.Windows.Forms.Button SplitButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown NsuperPixeVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown weightRatioVal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nbLoopVal;
    }
}

