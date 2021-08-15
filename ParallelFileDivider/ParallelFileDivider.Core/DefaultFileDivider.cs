using ParallelFileDivider.Core.Contracts;
using ParallelFileDivider.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Core
{
    public class DefaultFileDivider : IFileDivider
    {
        private readonly IFileAccessor _fileAccessor;

        public DefaultFileDivider(IFileAccessor fileAccessor)
        {
            _fileAccessor = fileAccessor ?? throw new ArgumentNullException(nameof(fileAccessor));
        }

        public async Task<FileOperationResult> DivideFile(string sourcePath, string destinationPath, int partsCount, int parallelStreamsCount, long bufferSize)
        {
            if (!_fileAccessor.IsFileExist(sourcePath))
            {
                throw new FileOperationException("Invalid file name");
            }

            _fileAccessor.EnsureFolderExists(destinationPath);

            var sourceSize = _fileAccessor.GetFileSize(sourcePath);
            var partsPerStream = partsCount / parallelStreamsCount;

            var tasks = Enumerable
                .Range(0, parallelStreamsCount)
                .Select(i =>
                {
                    var previousPartsCount = i * partsPerStream;
                    var partsForCurrentStream = i == parallelStreamsCount - 1
                        ? partsCount - previousPartsCount
                        : partsPerStream;
                    return DivideFilePart(sourcePath, destinationPath, previousPartsCount, partsForCurrentStream, partsCount, sourceSize, bufferSize);
                });
            await Task.WhenAll(tasks);

            return new FileOperationResult()
            {
                IsComplete = true
            };
        }

        public async Task<FileOperationResult> JoinFile(string folderPath, string destinationPath, int bufferSize)
        {
            if (!_fileAccessor.IsFolderExist(folderPath))
            {
                throw new FileOperationException("Invalid Directory");
            }

            if (_fileAccessor.IsFileExist(destinationPath))
            {
                throw new FileOperationException("File already exist");
            }

            var partFiles = _fileAccessor.GetFileNames(folderPath, "*.prt")
                .OrderBy(n =>
                {
                    var fileName = Path.GetFileName(n);
                    return int.Parse(fileName[5..].Split('.')[0]);
                });

            var bytes = new byte[bufferSize];
            using (var destinationStream = _fileAccessor.OpenFileForWrite(destinationPath))
            {
                foreach (var partFilePath in partFiles)
                {
                    using (var partStream = _fileAccessor.OpenFileForRead(partFilePath, false))
                    {
                        var read = 0;
                        while ((read = await partStream.ReadAsync(bytes)) > 0)
                        {
                            await destinationStream.WriteAsync(bytes, 0, read);
                        }
                    }
                }
            }

            return new FileOperationResult() { IsComplete = true };
        }

        private async Task DivideFilePart(string sourcePath, string destinationPath, int startFrom, int count, int totalPartsCount, long sourceSize, long bufferSize)
        {

            var nonLastPartSize = sourceSize / totalPartsCount;
            var offset = nonLastPartSize * startFrom;
            var destinationFileSize = sourceSize / totalPartsCount;

            using (var sourceStream = _fileAccessor.OpenFileForRead(sourcePath, true))
            {
                sourceStream.Seek(offset, SeekOrigin.Begin);

                long totalRead = offset;
                for (long iPart = startFrom; iPart < startFrom + count; iPart++)
                {
                    var isLastPart = iPart == totalPartsCount - 1;
                    var partSize = !isLastPart ? destinationFileSize : sourceSize - totalRead;

                    using (var destinationStream = _fileAccessor.OpenFileForWrite(Path.Combine(destinationPath, "chunk" + iPart + ".prt"), false))
                    {
                        long completedChunksSize = 0;
                        for (long currentChunkSize = 0; completedChunksSize < partSize; completedChunksSize += currentChunkSize)
                        {
                            currentChunkSize = Math.Min(bufferSize, partSize - completedChunksSize);
                            var bytes = new byte[currentChunkSize];
                            var read = await sourceStream.ReadAsync(bytes);
                            totalRead += read;

                            await destinationStream.WriteAsync(bytes, 0, read);
                        }
                    }
                }
            }
        }
    }
}
