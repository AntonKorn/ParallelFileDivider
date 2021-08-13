using ParallelFileDivider.Core.Commands;
using ParallelFileDivider.Core.Contracts;
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
            return _fileDivider.DivideFile(divideFileCommand.SourcePath,
                divideFileCommand.DestinationPath,
                divideFileCommand.PartsCount,
                divideFileCommand.ParallelStreamsCount,
                divideFileCommand.BufferSize);
        }

        public Task<FileOperationResult> JoinFile(JoinFileCommand joinFileCommand)
        {
            return _fileDivider.JoinFile(joinFileCommand.SourceFolderPath, joinFileCommand.DestinationPath);
        }
    }
}
