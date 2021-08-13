using ParallelFileDivider.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core.Contracts
{
    public interface IFileManager
    {
        Task<FileOperationResult> DivideFile(DivideFileCommand divideFileCommand);
        Task<FileOperationResult> JoinFile(JoinFileCommand joinFileCommand);
    }
}
