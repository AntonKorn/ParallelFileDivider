using ParallelFileDivider.Core.Commands;
using ParallelFileDivider.Core.Contracts;
using ParallelFileDivider.Core.Exceptions;
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

        public DefaultFileManager(IFileDivider fileDivider)
        {
            _fileDivider = fileDivider;
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
    }
}
