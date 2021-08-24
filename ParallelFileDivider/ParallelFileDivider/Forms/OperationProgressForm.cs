using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelFileDivider.Forms
{
    public partial class OperationProgressForm : Form
    {
        public string Title { get; set; }
        public bool IsWorkersProgressDisplayed { get; set; }
        public int MaxWorkerProgress { get; set; }
        public bool CanCancel { get; set; }

        private int[] _workersProgress { get; set; }

        public event EventHandler OkClicked;
        public event EventHandler CancelClicked;

        public OperationProgressForm()
        {
            InitializeComponent();
        }

        public void StartOperation(int workersCount)
        {
            _workersProgress = new int[workersCount];
            UpdateStaticComponents(true);

            tmrUpdateProgress.Start();
        }

        public void FinishOperation(string[] messages, bool isSuccess)
        {
            UpdateProgressComponents();
            if (isSuccess)
            {
                MessageBox.Show("Operation successfully complete");
            }
            else
            {
                if (messages != null)
                {
                    MessageBox.Show(string.Join(Environment.NewLine, messages));
                }
            }

            UpdateStaticComponents(false);
            tmrUpdateProgress.Stop();
        }

        public void UpdateOperationStatus(int worker, int progress)
        {
            _workersProgress[worker] = progress;
        }

        private void UpdateStaticComponents(bool inProgress)
        {
            Text = Title;
            lblOperationTitle.Text = Title;
            btnOk.Enabled = !inProgress;
            pnlMultipleThreads.Visible = IsWorkersProgressDisplayed;
            btnCancel.Visible = CanCancel;
            btnCancel.Enabled = inProgress;

            if (inProgress)
            {
                var maxProgress = _workersProgress.Length * MaxWorkerProgress;
                prbOverallProgress.Maximum = maxProgress;
            }
        }

        private void tmrUpdateProgress_Tick(object sender, EventArgs e)
        {
            UpdateProgressComponents();
        }

        private void UpdateProgressComponents()
        {
            Task.Run(() =>
            {
                var overallProgress = _workersProgress.Sum();
                var maxProgress = _workersProgress.Length * MaxWorkerProgress;
                var percents = overallProgress / (maxProgress + .0) * 100;
                Invoke((MethodInvoker)(() =>
                {
                    prbOverallProgress.Value = overallProgress;
                    lblPercentage.Text = string.Format("{0:0.00}%", percents);
                    multiWorkersProgressControl.UpdateProgress(_workersProgress, MaxWorkerProgress);
                }));
            });
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            OkClicked?.Invoke(this, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, e);
        }
    }
}
