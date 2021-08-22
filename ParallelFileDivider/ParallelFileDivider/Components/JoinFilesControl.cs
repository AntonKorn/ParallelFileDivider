using Microsoft.Extensions.DependencyInjection;
using ParallelFileDivider.Core;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelFileDivider.Components
{
    public partial class JoinFilesControl : UserControl
    {
        private IFileManager _fileManager;

        public void ConfigureDependencies(IServiceProvider serviceProvider)
        {
            _fileManager = (IFileManager)serviceProvider.GetRequiredService(typeof(IFileManager));
        }

        public JoinFilesControl()
        {
            InitializeComponent();
            FireAndForgetFolderSummaryUpdate();
        }

        private void btnSelectSourceFolder_Click(object sender, EventArgs e)
        {
            if (fbdSourceFolder.ShowDialog() == DialogResult.OK)
            {
                tbSourceFolderPath.Text = fbdSourceFolder.SelectedPath;
                FireAndForgetFolderSummaryUpdate();
            }
        }

        private void tbSourceFolderPath_TextChanged(object sender, EventArgs e)
        {
            RestarTimer();
        }

        private void tbDestinationFileName_TextChanged(object sender, EventArgs e)
        {
            RestarTimer();
        }

        private void tmrValidityRefresh_Tick(object sender, EventArgs e)
        {
            FireAndForgetFolderSummaryUpdate();
        }

        private async void btnJoin_Click(object sender, EventArgs e)
        {
            if (_fileManager.IsJoinCommandValid(GetJoinCommand()))
            {
                OperationStarted();
                var joinCommand = GetJoinCommand();

                var maxProgress = 10000;

                joinCommand.ExpectedProgressPrecision = maxProgress;
                joinCommand.ProgressChangedCallback =
                    status => operationProgressComponent.UpdateProgress(status.WorkerNumber, status.Progress);

                operationProgressComponent.StartProgress(1, maxProgress);

                var result = await _fileManager.JoinFile(joinCommand);

                operationProgressComponent.FinishProgress(result.Messages, result.IsComplete);

                OperationFinished();
            }

            FireAndForgetFolderSummaryUpdate();
        }

        private void OperationStarted()
        {
            btnJoin.Enabled = false;
        }

        private void OperationFinished()
        {
            btnJoin.Enabled = false;
        }

        private void FireAndForgetFolderSummaryUpdate()
        {
            var isSourceFolderSet = !string.IsNullOrEmpty(tbSourceFolderPath.Text);
            var isDestinationFileSet = !string.IsNullOrEmpty(tbDestinationFileName.Text);

            if (!isDestinationFileSet)
            {
                lblFileInUse.Hide();
                btnJoin.Enabled = false;
            }

            if (!isSourceFolderSet)
            {
                pnlDirectorySummary.Hide();
                lblInvalidDirectory.Hide();
                btnJoin.Enabled = false;
            }

            if (isDestinationFileSet || isSourceFolderSet)
            {
                btnJoin.Enabled = _fileManager.IsJoinCommandValid(GetJoinCommand());

                Task.Run(() =>
                {
                    if (isSourceFolderSet || isDestinationFileSet)
                    {
                        var query = new JoinFileOptionsSummaryQuery()
                        {
                            DestinationPath = tbDestinationFileName.Text,
                            SourcePath = tbSourceFolderPath.Text
                        };
                        var joinOptionsSummary = _fileManager.GetJoinOptionsSummary(query);

                        Invoke((MethodInvoker)(() => UpdateFolderSummary(joinOptionsSummary, isSourceFolderSet, isDestinationFileSet)));
                    }
                });
            }
        }

        private void UpdateFolderSummary(JoinOptionsSummary joinOptionsSummary, bool isSourceFolderSet, bool isDestinationFileSet)
        {
            pnlDirectorySummary.Visible = joinOptionsSummary.IsDirectoryValid;
            lblInvalidDirectory.Visible = !joinOptionsSummary.IsDirectoryValid && isSourceFolderSet;
            if (joinOptionsSummary.IsDirectoryValid)
            {
                lblbFilePartsCount.Text = joinOptionsSummary.FilesCount.ToString();
                lblPartsApproximateSize.Text = (joinOptionsSummary.ApproximateDestinationFileSize / 1024 / 1024).ToString();
            }

            lblFileInUse.Visible = joinOptionsSummary.IsFileInUse && isDestinationFileSet;

            tmrValidityRefresh.Stop();
        }

        private void RestarTimer()
        {
            tmrValidityRefresh.Stop();
            tmrValidityRefresh.Start();
        }

        private JoinFileCommand GetJoinCommand()
        {
            return new JoinFileCommand()
            {
                BufferSize = 50000,
                DestinationPath = tbDestinationFileName.Text,
                SourceFolderPath = tbSourceFolderPath.Text
            };
        }
    }
}
