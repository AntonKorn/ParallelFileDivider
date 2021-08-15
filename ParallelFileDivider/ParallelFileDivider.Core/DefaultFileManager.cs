using ParallelFileDivider.Core.Commands;
using ParallelFileDivider.Core.Contracts;
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

        public Task<FileOperationResult> DivideFile(DivideFileCommand divideFileCommand)
        {
            try
            {
                return _fileDivider.DivideFile(divideFileCommand.SourcePath,
                    divideFileCommand.DestinationPath,
                    divideFileCommand.PartsCount,
                    divideFileCommand.ParallelStreamsCount,
                    divideFileCommand.BufferSize);
            }
            catch (FileOperationException ex)
            {
                return Task.FromResult(new FileOperationResult()
                {
                    IsComplete = false,
                    Messages = new string[] { ex.Message }
                });
            }
            catch (Exception)
            {
                return Task.FromResult(new FileOperationResult()
                {
                    IsComplete = false,
                    Messages = new string[] { "Unexpected error occurred" }
                });
            }

        }

        public Task<FileOperationResult> JoinFile(JoinFileCommand joinFileCommand)
        {
            try
            {
                return _fileDivider.JoinFile(joinFileCommand.SourceFolderPath, joinFileCommand.DestinationPath, joinFileCommand.BufferSize);
            }
            catch (FileOperationException ex)
            {
                return Task.FromResult(new FileOperationResult()
                {
                    IsComplete = false,
                    Messages = new string[] { ex.Message }
                });
            }
            catch (Exception)
            {
                return Task.FromResult(new FileOperationResult()
                {
                    IsComplete = false,
                    Messages = new string[] { "Unexpected error occurred" }
                });
            }
        }

        public DivisionOptionsSummary GetDivisionOptionsSummary(DivisionOptionsSummaryQuery divisionOptionsSummaryQuery)
        {
            var summary = new DivisionOptionsSummary();
            summary.IsFileValid = _fileAccessor.IsFileExist(divisionOptionsSummaryQuery.SourceFile);
            summary.IsDirectoryInUse = !string.IsNullOrEmpty(divisionOptionsSummaryQuery.DestinationFolder)
                && !_fileAccessor.IsDirectoryEmpty(divisionOptionsSummaryQuery.DestinationFolder);

            if (summary.IsFileValid)
            {
                summary.TargetFileSizeInBytes = _fileAccessor.GetFileSize(divisionOptionsSummaryQuery.SourceFile);
                summary.ApproximatePartSizeInBytes = summary.TargetFileSizeInBytes / divisionOptionsSummaryQuery.PartsCount;
            }

            return summary;
        }
    }
}
