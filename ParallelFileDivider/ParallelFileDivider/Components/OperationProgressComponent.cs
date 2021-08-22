using ParallelFileDivider.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Components
{
    public partial class OperationProgressComponent : Component
    {
        private OperationProgressForm _operationProgressForm = new OperationProgressForm();

        public string OperationTitle { get; set; }

        public OperationProgressComponent()
        {
            InitializeComponent();
            RegisterEventHandlers();
        }

        public OperationProgressComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            RegisterEventHandlers();
        }

        public void StartProgress(int workersCount, int maxProgress)
        {
            UpdateFormProps();

            _operationProgressForm.Show();
            _operationProgressForm.IsWorkersProgressDisplayed = workersCount > 1;
            _operationProgressForm.MaxWorkerProgress = maxProgress;
            _operationProgressForm.StartOperation(workersCount);
        }

        public void UpdateProgress(int worker, int progress)
        {
            _operationProgressForm.UpdateOperationStatus(worker, progress);
        }

        public void FinishProgress(string[] messages, bool isComplete)
        {
            _operationProgressForm.FinishOperation(messages, isComplete);
        }

        private void UpdateFormProps()
        {
            _operationProgressForm.Title = OperationTitle;
        }

        private void RegisterEventHandlers()
        {
            _operationProgressForm.OkClicked += _operationProgressForm_OkClicked;
        }

        private void _operationProgressForm_OkClicked(object sender, EventArgs e)
        {
            _operationProgressForm.Hide();
        }
    }
}
