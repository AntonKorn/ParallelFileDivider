
namespace ParallelFileDivider.Forms
{
    partial class MainForm
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
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpDivide = new System.Windows.Forms.TabPage();
            this.divideFileControl = new ParallelFileDivider.Components.DivideFileControl();
            this.tbpJoin = new System.Windows.Forms.TabPage();
            this.tbcMain.SuspendLayout();
            this.tbpDivide.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcMain.Controls.Add(this.tbpDivide);
            this.tbcMain.Controls.Add(this.tbpJoin);
            this.tbcMain.Location = new System.Drawing.Point(12, 12);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(748, 613);
            this.tbcMain.TabIndex = 0;
            // 
            // tbpDivide
            // 
            this.tbpDivide.Controls.Add(this.divideFileControl);
            this.tbpDivide.Location = new System.Drawing.Point(4, 34);
            this.tbpDivide.Name = "tbpDivide";
            this.tbpDivide.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDivide.Size = new System.Drawing.Size(740, 575);
            this.tbpDivide.TabIndex = 0;
            this.tbpDivide.Text = "Divide";
            this.tbpDivide.UseVisualStyleBackColor = true;
            // 
            // divideFileControl
            // 
            this.divideFileControl.Location = new System.Drawing.Point(6, 6);
            this.divideFileControl.Name = "divideFileControl";
            this.divideFileControl.Size = new System.Drawing.Size(728, 563);
            this.divideFileControl.TabIndex = 11;
            // 
            // tbpJoin
            // 
            this.tbpJoin.Location = new System.Drawing.Point(4, 34);
            this.tbpJoin.Name = "tbpJoin";
            this.tbpJoin.Padding = new System.Windows.Forms.Padding(3);
            this.tbpJoin.Size = new System.Drawing.Size(740, 575);
            this.tbpJoin.TabIndex = 1;
            this.tbpJoin.Text = "Join";
            this.tbpJoin.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 637);
            this.Controls.Add(this.tbcMain);
            this.Name = "MainForm";
            this.Text = "Divide files";
            this.tbcMain.ResumeLayout(false);
            this.tbpDivide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpDivide;
        private System.Windows.Forms.TabPage tbpJoin;
        private Components.DivideFileControl divideFileControl;
    }
}