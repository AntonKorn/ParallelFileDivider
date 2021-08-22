using Microsoft.Extensions.DependencyInjection;
using ParallelFileDivider.Core.Commands;
using ParallelFileDivider.Core.Contracts;
using ParallelFileDivider.Core.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelFileDivider.Components
{
    public partial class DivideFileControl : UserControl
    {
        private IFileManager _fileManager;

        public DivideFileControl()
        {
            InitializeComponent();
            UpdateSummaryAndValidityComponents();
        }

        public void ConfigureDependencies(IServiceProvider serviceProvider)
        {
            _fileManager = (IFileManager)serviceProvider.GetRequiredService(typeof(IFileManager));
        }

        private void nudFilesCount_ValueChanged(object sender, EventArgs e)
        {
            nudParallelThreads.Maximum = nudFilesCount.Value;
            UpdateSummaryAndValidityComponents();
        }

        private void btnSelectSourceFile_Click(object sender, EventArgs e)
        {
            if (ofdSourceFile.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = ofdSourceFile.FileName;
                UpdateSummaryAndValidityComponents();
            }
        }

        private void btnSelectDestinationFolder_Click(object sender, EventArgs e)
        {
            if (fbdDestinationFolder.ShowDialog() == DialogResult.OK)
            {
                tbDestinationFolder.Text = fbdDestinationFolder.SelectedPath;
                UpdateSummaryAndValidityComponents();
            }
        }

        private void tmrUpdateSummaryAndValidate_Tick(object sender, EventArgs e)
        {
            UpdateSummaryAndValidityComponents();
        }

        private async void btnDivideFiles_Click(object sender, EventArgs e)
        {
            if (UpdateSummaryAndValidityComponents())
            {
                OperationStarted();

                var maxProgress = 10000;

                var divideCommand = new DivideFileCommand()
                {
                    BufferSize = 50000,
                    DestinationPath = tbDestinationFolder.Text,
                    ParallelStreamsCount = (int)nudParallelThreads.Value,
                    PartsCount = (int)nudFilesCount.Value,
                    SourcePath = tbFileName.Text,
                    DivisionProgressObserver = new Core.Dto.DivisionProgressObserverDto()
                    {
                        ExpectedProgressPrecision = maxProgress,
                        ProgressChangedCallback =
                            progress => operationProgressComponent.UpdateProgress(progress.WorkerNumber, progress.Progress)
                    }
                };

                operationProgressComponent.StartProgress((int)nudParallelThreads.Value, maxProgress);

                var result = await _fileManager.DivideFile(divideCommand);

                operationProgressComponent.FinishProgress(result.Messages, result.IsComplete);

                OperationFinished();
            }
        }

        private void OperationStarted()
        {
            btnDivideFiles.Enabled = false;
        }

        private void OperationFinished()
        {
            btnDivideFiles.Enabled = true;
        }

        private bool UpdateSummaryAndValidityComponents()
        {
            var isFileValid = true;

            var isFileNameSet = !string.IsNullOrEmpty(tbFileName.Text);
            if (!isFileNameSet)
            {
                pnlFileInfo.Hide();
                lblInvalidFileWarning.Hide();
                isFileValid = false;
            }

            var isDestinationFolderSet = !string.IsNullOrEmpty(tbDestinationFolder.Text);
            if (!isDestinationFolderSet)
            {
                lblDirectoryWarning.Hide();
            }

            if (isFileValid || isDestinationFolderSet)
            {
                var query = new DivisionOptionsSummaryQuery()
                {
                    DestinationFolder = tbDestinationFolder.Text,
                    PartsCount = (int)nudFilesCount.Value,
                    SourceFile = tbFileName.Text
                };

                var fileSummary = _fileManager.GetDivisionOptionsSummary(query);

                lblDirectoryWarning.Visible = fileSummary.IsDirectoryInUse && isDestinationFolderSet;
                lblInvalidFileWarning.Visible = !fileSummary.IsFileValid && isFileNameSet;
                pnlFileInfo.Visible = fileSummary.IsFileValid;

                isFileValid = fileSummary.IsFileValid;

                if (isFileValid)
                {
                    lblApproximateFileSize.Text = (fileSummary.TargetFileSizeInBytes / 1024 / 1024).ToString();
                    lblApproximatePartSize.Text = (fileSummary.ApproximatePartSizeInBytes / 1024).ToString();
                }
            }

            var isValid = isFileValid && isDestinationFolderSet;
            btnDivideFiles.Enabled = isDestinationFolderSet;
            return isValid;
        }
    }
}
