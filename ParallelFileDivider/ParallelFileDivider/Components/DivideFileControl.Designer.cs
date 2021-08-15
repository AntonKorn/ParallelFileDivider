
namespace ParallelFileDivider.Components
{
    partial class DivideFileControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSelectDestinationFolder = new System.Windows.Forms.Button();
            this.btnSelectSourceFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudParallelThreads = new System.Windows.Forms.NumericUpDown();
            this.nudFilesCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDestinationFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDivideFiles = new System.Windows.Forms.Button();
            this.pnlFileInfo = new System.Windows.Forms.Panel();
            this.lblApproximatePartSize = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblApproximateFileSize = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDirectoryWarning = new System.Windows.Forms.Label();
            this.lblInvalidFileWarning = new System.Windows.Forms.Label();
            this.tmrUpdateSummaryAndValidate = new System.Windows.Forms.Timer(this.components);
            this.ofdSourceFile = new System.Windows.Forms.OpenFileDialog();
            this.fbdDestinationFolder = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nudParallelThreads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFilesCount)).BeginInit();
            this.pnlFileInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectDestinationFolder
            // 
            this.btnSelectDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectDestinationFolder.Location = new System.Drawing.Point(588, 53);
            this.btnSelectDestinationFolder.Name = "btnSelectDestinationFolder";
            this.btnSelectDestinationFolder.Size = new System.Drawing.Size(112, 34);
            this.btnSelectDestinationFolder.TabIndex = 24;
            this.btnSelectDestinationFolder.Text = "Select";
            this.btnSelectDestinationFolder.UseVisualStyleBackColor = true;
            this.btnSelectDestinationFolder.Click += new System.EventHandler(this.btnSelectDestinationFolder_Click);
            // 
            // btnSelectSourceFile
            // 
            this.btnSelectSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectSourceFile.Location = new System.Drawing.Point(588, 16);
            this.btnSelectSourceFile.Name = "btnSelectSourceFile";
            this.btnSelectSourceFile.Size = new System.Drawing.Size(112, 34);
            this.btnSelectSourceFile.TabIndex = 23;
            this.btnSelectSourceFile.Text = "Select";
            this.btnSelectSourceFile.UseVisualStyleBackColor = true;
            this.btnSelectSourceFile.Click += new System.EventHandler(this.btnSelectSourceFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(394, 25);
            this.label6.TabIndex = 22;
            this.label6.Text = "Parallel threads number is limited by Files Count.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(482, 25);
            this.label5.TabIndex = 21;
            this.label5.Text = "Select parallel threads based on your processor capabilities.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "Parallel Threads Count";
            // 
            // nudParallelThreads
            // 
            this.nudParallelThreads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudParallelThreads.Location = new System.Drawing.Point(222, 129);
            this.nudParallelThreads.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudParallelThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudParallelThreads.Name = "nudParallelThreads";
            this.nudParallelThreads.Size = new System.Drawing.Size(342, 31);
            this.nudParallelThreads.TabIndex = 19;
            this.nudParallelThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudFilesCount
            // 
            this.nudFilesCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudFilesCount.Location = new System.Drawing.Point(222, 92);
            this.nudFilesCount.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nudFilesCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFilesCount.Name = "nudFilesCount";
            this.nudFilesCount.Size = new System.Drawing.Size(342, 31);
            this.nudFilesCount.TabIndex = 18;
            this.nudFilesCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFilesCount.ValueChanged += new System.EventHandler(this.nudFilesCount_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "Files Count";
            // 
            // tbDestinationFolder
            // 
            this.tbDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDestinationFolder.Location = new System.Drawing.Point(222, 55);
            this.tbDestinationFolder.Name = "tbDestinationFolder";
            this.tbDestinationFolder.Size = new System.Drawing.Size(342, 31);
            this.tbDestinationFolder.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Destination Folder";
            // 
            // tbFileName
            // 
            this.tbFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFileName.Location = new System.Drawing.Point(222, 18);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(342, 31);
            this.tbFileName.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Source FIle";
            // 
            // btnDivideFiles
            // 
            this.btnDivideFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDivideFiles.Location = new System.Drawing.Point(19, 518);
            this.btnDivideFiles.Name = "btnDivideFiles";
            this.btnDivideFiles.Size = new System.Drawing.Size(157, 34);
            this.btnDivideFiles.TabIndex = 25;
            this.btnDivideFiles.Text = "Divide";
            this.btnDivideFiles.UseVisualStyleBackColor = true;
            this.btnDivideFiles.Click += new System.EventHandler(this.btnDivideFiles_Click);
            // 
            // pnlFileInfo
            // 
            this.pnlFileInfo.Controls.Add(this.lblApproximatePartSize);
            this.pnlFileInfo.Controls.Add(this.label9);
            this.pnlFileInfo.Controls.Add(this.lblApproximateFileSize);
            this.pnlFileInfo.Controls.Add(this.label7);
            this.pnlFileInfo.Location = new System.Drawing.Point(19, 262);
            this.pnlFileInfo.Name = "pnlFileInfo";
            this.pnlFileInfo.Size = new System.Drawing.Size(681, 159);
            this.pnlFileInfo.TabIndex = 26;
            // 
            // lblApproximatePartSize
            // 
            this.lblApproximatePartSize.AutoSize = true;
            this.lblApproximatePartSize.Location = new System.Drawing.Point(3, 123);
            this.lblApproximatePartSize.Name = "lblApproximatePartSize";
            this.lblApproximatePartSize.Size = new System.Drawing.Size(26, 25);
            this.lblApproximatePartSize.TabIndex = 3;
            this.lblApproximatePartSize.Text = "__";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(3, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(225, 25);
            this.label9.TabIndex = 2;
            this.label9.Text = "Approximate part size (KB):";
            // 
            // lblApproximateFileSize
            // 
            this.lblApproximateFileSize.AutoSize = true;
            this.lblApproximateFileSize.Location = new System.Drawing.Point(3, 47);
            this.lblApproximateFileSize.Name = "lblApproximateFileSize";
            this.lblApproximateFileSize.Size = new System.Drawing.Size(26, 25);
            this.lblApproximateFileSize.TabIndex = 1;
            this.lblApproximateFileSize.Text = "__";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(3, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(222, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Approximate file size (MB):";
            // 
            // lblDirectoryWarning
            // 
            this.lblDirectoryWarning.AutoSize = true;
            this.lblDirectoryWarning.ForeColor = System.Drawing.Color.Red;
            this.lblDirectoryWarning.Location = new System.Drawing.Point(19, 474);
            this.lblDirectoryWarning.Name = "lblDirectoryWarning";
            this.lblDirectoryWarning.Size = new System.Drawing.Size(253, 25);
            this.lblDirectoryWarning.TabIndex = 27;
            this.lblDirectoryWarning.Text = "This directory already has files!";
            // 
            // lblInvalidFileWarning
            // 
            this.lblInvalidFileWarning.AutoSize = true;
            this.lblInvalidFileWarning.ForeColor = System.Drawing.Color.Red;
            this.lblInvalidFileWarning.Location = new System.Drawing.Point(22, 434);
            this.lblInvalidFileWarning.Name = "lblInvalidFileWarning";
            this.lblInvalidFileWarning.Size = new System.Drawing.Size(149, 25);
            this.lblInvalidFileWarning.TabIndex = 28;
            this.lblInvalidFileWarning.Text = "This file is invalid!";
            // 
            // tmrUpdateSummaryAndValidate
            // 
            this.tmrUpdateSummaryAndValidate.Enabled = true;
            this.tmrUpdateSummaryAndValidate.Interval = 1000;
            this.tmrUpdateSummaryAndValidate.Tick += new System.EventHandler(this.tmrUpdateSummaryAndValidate_Tick);
            // 
            // ofdSourceFile
            // 
            this.ofdSourceFile.FileName = "openFileDialog1";
            // 
            // DivideFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInvalidFileWarning);
            this.Controls.Add(this.lblDirectoryWarning);
            this.Controls.Add(this.pnlFileInfo);
            this.Controls.Add(this.btnDivideFiles);
            this.Controls.Add(this.btnSelectDestinationFolder);
            this.Controls.Add(this.btnSelectSourceFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudParallelThreads);
            this.Controls.Add(this.nudFilesCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDestinationFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.label1);
            this.Name = "DivideFileControl";
            this.Size = new System.Drawing.Size(719, 555);
            ((System.ComponentModel.ISupportInitialize)(this.nudParallelThreads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFilesCount)).EndInit();
            this.pnlFileInfo.ResumeLayout(false);
            this.pnlFileInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectDestinationFolder;
        private System.Windows.Forms.Button btnSelectSourceFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudParallelThreads;
        private System.Windows.Forms.NumericUpDown nudFilesCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDestinationFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDivideFiles;
        private System.Windows.Forms.Panel pnlFileInfo;
        private System.Windows.Forms.Label lblApproximatePartSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblApproximateFileSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDirectoryWarning;
        private System.Windows.Forms.Label lblInvalidFileWarning;
        private System.Windows.Forms.Timer tmrUpdateSummaryAndValidate;
        private System.Windows.Forms.OpenFileDialog ofdSourceFile;
        private System.Windows.Forms.FolderBrowserDialog fbdDestinationFolder;
    }
}
