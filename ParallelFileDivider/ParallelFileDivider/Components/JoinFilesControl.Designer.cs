
namespace ParallelFileDivider.Components
{
    partial class JoinFilesControl
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
            this.lblInvalidDirectory = new System.Windows.Forms.Label();
            this.lblFileInUse = new System.Windows.Forms.Label();
            this.btnSelectSourceFolder = new System.Windows.Forms.Button();
            this.tbDestinationFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSourceFolderPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fbdSourceFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlDirectorySummary = new System.Windows.Forms.Panel();
            this.lblPartsApproximateSize = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblbFilePartsCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnJoin = new System.Windows.Forms.Button();
            this.tmrValidityRefresh = new System.Windows.Forms.Timer(this.components);
            this.operationProgressComponent = new ParallelFileDivider.Components.OperationProgressComponent(this.components);
            this.pnlDirectorySummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInvalidDirectory
            // 
            this.lblInvalidDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInvalidDirectory.AutoSize = true;
            this.lblInvalidDirectory.ForeColor = System.Drawing.Color.Red;
            this.lblInvalidDirectory.Location = new System.Drawing.Point(15, 438);
            this.lblInvalidDirectory.Name = "lblInvalidDirectory";
            this.lblInvalidDirectory.Size = new System.Drawing.Size(196, 25);
            this.lblInvalidDirectory.TabIndex = 4;
            this.lblInvalidDirectory.Text = "This directory is invalid!";
            // 
            // lblFileInUse
            // 
            this.lblFileInUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFileInUse.AutoSize = true;
            this.lblFileInUse.ForeColor = System.Drawing.Color.Red;
            this.lblFileInUse.Location = new System.Drawing.Point(15, 404);
            this.lblFileInUse.Name = "lblFileInUse";
            this.lblFileInUse.Size = new System.Drawing.Size(144, 25);
            this.lblFileInUse.TabIndex = 32;
            this.lblFileInUse.Text = "This file is in use!";
            // 
            // btnSelectSourceFolder
            // 
            this.btnSelectSourceFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectSourceFolder.Location = new System.Drawing.Point(584, 12);
            this.btnSelectSourceFolder.Name = "btnSelectSourceFolder";
            this.btnSelectSourceFolder.Size = new System.Drawing.Size(112, 34);
            this.btnSelectSourceFolder.TabIndex = 29;
            this.btnSelectSourceFolder.Text = "Select";
            this.btnSelectSourceFolder.UseVisualStyleBackColor = true;
            this.btnSelectSourceFolder.Click += new System.EventHandler(this.btnSelectSourceFolder_Click);
            // 
            // tbDestinationFileName
            // 
            this.tbDestinationFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDestinationFileName.Location = new System.Drawing.Point(218, 51);
            this.tbDestinationFileName.Name = "tbDestinationFileName";
            this.tbDestinationFileName.Size = new System.Drawing.Size(342, 31);
            this.tbDestinationFileName.TabIndex = 28;
            this.tbDestinationFileName.TextChanged += new System.EventHandler(this.tbDestinationFileName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 25);
            this.label2.TabIndex = 27;
            this.label2.Text = "Destination File";
            // 
            // tbSourceFolderPath
            // 
            this.tbSourceFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSourceFolderPath.Location = new System.Drawing.Point(218, 14);
            this.tbSourceFolderPath.Name = "tbSourceFolderPath";
            this.tbSourceFolderPath.Size = new System.Drawing.Size(342, 31);
            this.tbSourceFolderPath.TabIndex = 26;
            this.tbSourceFolderPath.TextChanged += new System.EventHandler(this.tbSourceFolderPath_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "Source Folder";
            // 
            // pnlDirectorySummary
            // 
            this.pnlDirectorySummary.Controls.Add(this.lblPartsApproximateSize);
            this.pnlDirectorySummary.Controls.Add(this.label4);
            this.pnlDirectorySummary.Controls.Add(this.lblbFilePartsCount);
            this.pnlDirectorySummary.Controls.Add(this.label3);
            this.pnlDirectorySummary.Location = new System.Drawing.Point(3, 134);
            this.pnlDirectorySummary.Name = "pnlDirectorySummary";
            this.pnlDirectorySummary.Size = new System.Drawing.Size(693, 223);
            this.pnlDirectorySummary.TabIndex = 30;
            // 
            // lblPartsApproximateSize
            // 
            this.lblPartsApproximateSize.AutoSize = true;
            this.lblPartsApproximateSize.Location = new System.Drawing.Point(12, 161);
            this.lblPartsApproximateSize.Name = "lblPartsApproximateSize";
            this.lblPartsApproximateSize.Size = new System.Drawing.Size(26, 25);
            this.lblPartsApproximateSize.TabIndex = 3;
            this.lblPartsApproximateSize.Text = "__";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(12, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(239, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Parts Approximate Size (MB):";
            // 
            // lblbFilePartsCount
            // 
            this.lblbFilePartsCount.AutoSize = true;
            this.lblbFilePartsCount.Location = new System.Drawing.Point(12, 58);
            this.lblbFilePartsCount.Name = "lblbFilePartsCount";
            this.lblbFilePartsCount.Size = new System.Drawing.Size(26, 25);
            this.lblbFilePartsCount.TabIndex = 1;
            this.lblbFilePartsCount.Text = "__";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "File Parts Count:";
            // 
            // btnJoin
            // 
            this.btnJoin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnJoin.Location = new System.Drawing.Point(15, 479);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(165, 34);
            this.btnJoin.TabIndex = 31;
            this.btnJoin.Text = "Join";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // tmrValidityRefresh
            // 
            this.tmrValidityRefresh.Interval = 1500;
            this.tmrValidityRefresh.Tick += new System.EventHandler(this.tmrValidityRefresh_Tick);
            // 
            // operationProgressComponent
            // 
            this.operationProgressComponent.OperationTitle = "Joining Progress";
            // 
            // JoinFilesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFileInUse);
            this.Controls.Add(this.lblInvalidDirectory);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.pnlDirectorySummary);
            this.Controls.Add(this.btnSelectSourceFolder);
            this.Controls.Add(this.tbDestinationFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSourceFolderPath);
            this.Controls.Add(this.label1);
            this.Name = "JoinFilesControl";
            this.Size = new System.Drawing.Size(707, 516);
            this.pnlDirectorySummary.ResumeLayout(false);
            this.pnlDirectorySummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectSourceFolder;
        private System.Windows.Forms.TextBox tbDestinationFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSourceFolderPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog fbdSourceFolder;
        private System.Windows.Forms.Panel pnlDirectorySummary;
        private System.Windows.Forms.Label lblPartsApproximateSize;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblbFilePartsCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.Label lblInvalidDirectory;
        private System.Windows.Forms.Label lblFileInUse;
        private System.Windows.Forms.Timer tmrValidityRefresh;
        private OperationProgressComponent operationProgressComponent;
    }
}
