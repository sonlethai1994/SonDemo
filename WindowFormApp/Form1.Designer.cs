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
            this.menuStrip1.SuspendLayout();
            this.mainInterfaceTable.SuspendLayout();
            this.MenuTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagePuzzleLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(919, 28);
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
            this.mainInterfaceTable.Location = new System.Drawing.Point(0, 28);
            this.mainInterfaceTable.Name = "mainInterfaceTable";
            this.mainInterfaceTable.RowCount = 1;
            this.mainInterfaceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainInterfaceTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.mainInterfaceTable.Size = new System.Drawing.Size(919, 422);
            this.mainInterfaceTable.TabIndex = 1;
            // 
            // MenuTable
            // 
            this.MenuTable.ColumnCount = 1;
            this.MenuTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MenuTable.Controls.Add(this.MenuLabel, 0, 0);
            this.MenuTable.Controls.Add(this.SplitButton, 0, 1);
            this.MenuTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuTable.Location = new System.Drawing.Point(743, 4);
            this.MenuTable.Name = "MenuTable";
            this.MenuTable.RowCount = 4;
            this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.MenuTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MenuTable.Size = new System.Drawing.Size(172, 414);
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
            this.SplitButton.Location = new System.Drawing.Point(37, 31);
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
            this.imagePuzzleLocation.Size = new System.Drawing.Size(732, 414);
            this.imagePuzzleLocation.TabIndex = 1;
            this.imagePuzzleLocation.TabStop = false;
            this.imagePuzzleLocation.DragDrop += new System.Windows.Forms.DragEventHandler(this.imagePuzzleLocation_DragDrop);
            this.imagePuzzleLocation.DragEnter += new System.Windows.Forms.DragEventHandler(this.imagePuzzleLocation_DragEnter);
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
    }
}

