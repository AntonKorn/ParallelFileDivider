
namespace ParallelFileDivider.Forms
{
    partial class OperationProgressForm
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
            this.components = new System.ComponentModel.Container();
            this.lblOperationTitle = new System.Windows.Forms.Label();
            this.prbOverallProgress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPercentage = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.tmrUpdateProgress = new System.Windows.Forms.Timer(this.components);
            this.multiWorkersProgressControl = new ParallelFileDivider.Components.MultiWorkersProgressControl();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlMultipleThreads = new System.Windows.Forms.Panel();
            this.pnlMultipleThreads.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOperationTitle
            // 
            this.lblOperationTitle.AutoSize = true;
            this.lblOperationTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOperationTitle.Location = new System.Drawing.Point(12, 30);
            this.lblOperationTitle.Name = "lblOperationTitle";
            this.lblOperationTitle.Size = new System.Drawing.Size(256, 38);
            this.lblOperationTitle.TabIndex = 0;
            this.lblOperationTitle.Text = "Operation Progress";
            // 
            // prbOverallProgress
            // 
            this.prbOverallProgress.Location = new System.Drawing.Point(12, 190);
            this.prbOverallProgress.Name = "prbOverallProgress";
            this.prbOverallProgress.Size = new System.Drawing.Size(759, 34);
            this.prbOverallProgress.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Overall Progress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Percentage:";
            // 
            // lblPercentage
            // 
            this.lblPercentage.AutoSize = true;
            this.lblPercentage.Location = new System.Drawing.Point(133, 227);
            this.lblPercentage.Name = "lblPercentage";
            this.lblPercentage.Size = new System.Drawing.Size(22, 25);
            this.lblPercentage.TabIndex = 4;
            this.lblPercentage.Text = "0";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(659, 459);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(112, 34);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tmrUpdateProgress
            // 
            this.tmrUpdateProgress.Interval = 500;
            this.tmrUpdateProgress.Tick += new System.EventHandler(this.tmrUpdateProgress_Tick);
            // 
            // multiWorkersProgressControl
            // 
            this.multiWorkersProgressControl.AreDividersVisible = false;
            this.multiWorkersProgressControl.DivisionBorderColor = System.Drawing.Color.Blue;
            this.multiWorkersProgressControl.IsMeshVisible = false;
            this.multiWorkersProgressControl.Location = new System.Drawing.Point(3, 34);
            this.multiWorkersProgressControl.MainBorderColor = System.Drawing.Color.Black;
            this.multiWorkersProgressControl.Name = "multiWorkersProgressControl";
            this.multiWorkersProgressControl.Size = new System.Drawing.Size(753, 116);
            this.multiWorkersProgressControl.TabIndex = 7;
            this.multiWorkersProgressControl.VerticalPadding = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Threads progress";
            // 
            // pnlMultipleThreads
            // 
            this.pnlMultipleThreads.Controls.Add(this.label3);
            this.pnlMultipleThreads.Controls.Add(this.multiWorkersProgressControl);
            this.pnlMultipleThreads.Location = new System.Drawing.Point(12, 287);
            this.pnlMultipleThreads.Name = "pnlMultipleThreads";
            this.pnlMultipleThreads.Size = new System.Drawing.Size(759, 150);
            this.pnlMultipleThreads.TabIndex = 9;
            // 
            // OperationProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 505);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMultipleThreads);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblPercentage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prbOverallProgress);
            this.Controls.Add(this.lblOperationTitle);
            this.Name = "OperationProgressForm";
            this.Text = "Operation Progress";
            this.pnlMultipleThreads.ResumeLayout(false);
            this.pnlMultipleThreads.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOperationTitle;
        private System.Windows.Forms.ProgressBar prbOverallProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPercentage;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Timer tmrUpdateProgress;
        private Components.MultiWorkersProgressControl multiWorkersProgressControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlMultipleThreads;
    }
}