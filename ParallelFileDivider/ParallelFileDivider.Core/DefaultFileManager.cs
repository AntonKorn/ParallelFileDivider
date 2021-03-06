using ParallelFileDivider.Core.Commands;
using ParallelFileDivider.Core.Contracts;
using ParallelFileDivider.Core.Dto;
using ParallelFileDivider.Core.Exceptions;
using ParallelFileDivider.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core
{
    public class DefaultFileManager : IFileManager
    {
        private readonly IFileDivider _fileDivider;
        private readonly IFileAccessor _fileAccessor;

        public DefaultFileManager(IFileDivider fileDivider, IFileAccessor fileAccessor)
        {
            _fileDivider = fileDivider;
            _fileAccessor = fileAccessor;
        }

        public async Task<FileOperationResult> DivideFile(DivideFileCommand divideFileCommand)
        {
            try
            {
                return await _fileDivider.DivideFile(divideFileCommand.SourcePath,
                    divideFileCommand.DestinationPath,
                    divideFileCommand.PartsCount,
                    divideFileCommand.ParallelStreamsCount,
                    divideFileCommand.BufferSize,
                    divideFileCommand.DivisionProgressObserver);
            }
            catch (FileOperationException ex)
            {
                return new FileOperationResult()
                {
                    IsComplete = false,
                    Messages = new string[] { ex.Message }
                };
            }
            catch (OperationCanceledException)
            {
                return new FileOperationResult()
                {
                    IsComplete = false,
                    Messages = new string[] { "Operation was cancelled by user." }
                };
            }
            catch (Exception)
            {
                return new FileOperationResult()
                {
                    IsComplete = false,
                    Messages = new string[] { "Unexpected error occurred" }
                };
            }

        }

        public async Task<FileOperationResult> JoinFile(JoinFileCommand joinFileCommand)
        {
            try
            {
                var isOperationProgressCalculated = joinFileCommand.ProgressChangedCallback != null;

                var operationProgressObservable = isOperationProgressCalculated
                    ? new JoinProgressObsererDto()
                    {
                        ExpectedProgressPrecision = joinFileCommand.ExpectedProgressPrecision,
                        ProgressChangedCallback = joinFileCommand.ProgressChangedCallback,
                        CancellationToken = joinFileCommand.CancellationToken
                    }
                    : null;

                if (isOperationProgressCalculated)
                {
                    operationProgressObservable.ExpectedDestiationFileSize = await CalculateTotalPartsSizeAsync(joinFileCommand.SourceFolderPath);
                }

                return await _fileDivider.JoinFile(joinFileCommand.SourceFolderPath,
                    joinFileCommand.DestinationPath,
                    joinFileCommand.BufferSize,
                    operationProgressObservable);
            }
            catch (FileOperationException ex)
            {
                return new FileOperationResult()
                {
                    IsComplete = false,
                    Messages = new string[] { ex.Message }
                };
            }
            catch (OperationCanceledException)
            {
                return new FileOperationResult()
                {
                    IsComplete = false,
                    Messages = new string[] { "Operation was cancelled by user." }
                };
            }
            catch (Exception)
            {
                return new FileOperationResult()
                {
                    IsComplete = false,
                    Messages = new string[] { "Unexpected error occurred" }
                };
            }
        }

        public DivisionOptionsSummary GetDivisionOptionsSummary(DivisionOptionsSummaryQuery divisionOptionsSummaryQuery)
        {
            try
            {
                var summary = new DivisionOptionsSummary();
                summary.IsFileValid = !string.IsNullOrEmpty(divisionOptionsSummaryQuery.SourceFile)
                    && _fileAccessor.IsFileExist(divisionOptionsSummaryQuery.SourceFile);
                summary.IsDirectoryInUse = !string.IsNullOrEmpty(divisionOptionsSummaryQuery.DestinationFolder)
                    && !_fileAccessor.IsDirectoryEmpty(divisionOptionsSummaryQuery.DestinationFolder);

                if (summary.IsFileValid)
                {
                    summary.TargetFileSizeInBytes = _fileAccessor.GetFileSize(divisionOptionsSummaryQuery.SourceFile);
                    summary.ApproximatePartSizeInBytes = summary.TargetFileSizeInBytes / divisionOptionsSummaryQuery.PartsCount;
                }

                return summary;
            }
            catch (Exception)
            {
                return new DivisionOptionsSummary()
                {
                    IsFileValid = false,
                    IsDirectoryInUse = false
                };
            }
        }

        public bool IsJoinCommandValid(JoinFileCommand joinFileCommand)
        {
            try
            {
                if (string.IsNullOrEmpty(joinFileCommand.DestinationPath) || _fileAccessor.IsFileExist(joinFileCommand.DestinationPath))
                {
                    return false;
                }

                if (string.IsNullOrEmpty(joinFileCommand.SourceFolderPath) || !_fileAccessor.IsFolderExist(joinFileCommand.SourceFolderPath))
                {
                    return false;
                }

                if (!_fileAccessor.GetFileNames(joinFileCommand.SourceFolderPath, "*.prt").Any())
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public JoinOptionsSummary GetJoinOptionsSummary(JoinFileOptionsSummaryQuery joinFileOptionsSummaryQuery)
        {
            try
            {
                var summary = new JoinOptionsSummary();
                summary.IsFileInUse = !string.IsNullOrEmpty(joinFileOptionsSummaryQuery.DestinationPath)
                    && _fileAccessor.IsFileExist(joinFileOptionsSummaryQuery.DestinationPath);

                if (!string.IsNullOrEmpty(joinFileOptionsSummaryQuery.SourcePath) && _fileAccessor.IsFolderExist(joinFileOptionsSummaryQuery.SourcePath))
                {
                    var files = _fileAccessor.GetFileNames(joinFileOptionsSummaryQuery.SourcePath, "*.prt").ToList();
                    summary.FilesCount = files.Count;
                    summary.ApproximateDestinationFileSize = files
                        .Select(fileName => _fileAccessor.GetFileSize(fileName))
                        .Sum();
                }

                summary.IsDirectoryValid = summary.ApproximateDestinationFileSize != 0;
                return summary;
            }
            catch (Exception)
            {
                return new JoinOptionsSummary()
                {
                    IsDirectoryValid = false,
                    IsFileInUse = false
                };
            }
        }

        private Task<long> CalculateTotalPartsSizeAsync(string path)
        {
            return Task.Run(() => _fileAccessor
                .GetFileNames(path, "*.prt")
                .Select(fileName => _fileAccessor.GetFileSize(fileName))
                .Sum());
        }
    }
}
