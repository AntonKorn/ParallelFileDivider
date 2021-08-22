using ParallelFileDivider.Core.Commands;
using ParallelFileDivider.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core.Contracts
{
    public interface IFileDivider
    {
        Task<FileOperationResult> DivideFile(string sourcePath, string destinationPath, int partsCount, int parallelStreamsCount, long bufferSize);

        Task<FileOperationResult> DivideFile(string sourcePath, string destinationPath, int partsCount, int parallelStreamsCount, long bufferSize, DivisionProgressObserverDto progress);
        Task<FileOperationResult> JoinFile(string folderPath, string destinationPath, int bufferSize);
        Task<FileOperationResult> JoinFile(string folderPath, string destinationPath, int bufferSize, JoinProgressObsererDto progress);
    }
}
