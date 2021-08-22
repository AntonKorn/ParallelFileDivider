using ParallelFileDivider.Core.Contracts;
using ParallelFileDivider.Core.Dto;
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

        public Task<FileOperationResult> DivideFile(string sourcePath, string destinationPath, int partsCount, int parallelStreamsCount, long bufferSize)
        {
            var progress = new DivisionProgressObserverDto();
            return DivideFile(sourcePath, destinationPath, partsCount, parallelStreamsCount, bufferSize, progress);
        }

        public async Task<FileOperationResult> DivideFile(string sourcePath, string destinationPath, int partsCount, int parallelStreamsCount, long bufferSize, DivisionProgressObserverDto progressObserver)
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

                    void workerCallback((long Expected, long Current) status)
                    {
                        var progress = status.Current / (status.Expected + .0) * progressObserver.ExpectedProgressPrecision;
                        progressObserver.ProgressChangedCallback(((int)progress, i));
                    }

                    return DivideFilePart(sourcePath,
                        destinationPath,
                        previousPartsCount,
                        partsForCurrentStream,
                        partsCount,
                        sourceSize,
                        bufferSize,
                        progressObserver.ProgressChangedCallback != null ? workerCallback : null);
                });
            await Task.WhenAll(tasks);

            return new FileOperationResult()
            {
                IsComplete = true
            };
        }

        public Task<FileOperationResult> JoinFile(string folderPath, string destinationPath, int bufferSize)
        {
            return JoinFile(folderPath, destinationPath, bufferSize, null);
        }

        public async Task<FileOperationResult> JoinFile(string folderPath, string destinationPath, int bufferSize, JoinProgressObsererDto progressObserver)
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
            var totalRead = 0L;
            using (var destinationStream = _fileAccessor.OpenFileForWrite(destinationPath))
            {
                foreach (var partFilePath in partFiles)
                {
                    using (var partStream = _fileAccessor.OpenFileForRead(partFilePath, false))
                    {
                        var read = 0;
                        while ((read = await partStream.ReadAsync(bytes)) > 0)
                        {
                            totalRead += read;
                            await destinationStream.WriteAsync(bytes, 0, read);

                            if (progressObserver != null)
                            {
                                var progress = totalRead / (progressObserver.ExpectedDestiationFileSize + .0) * progressObserver.ExpectedProgressPrecision;
                                progressObserver?.ProgressChangedCallback?.Invoke(((int)progress, 0));
                            }
                        }
                    }
                }
            }

            return new FileOperationResult() { IsComplete = true };
        }

        private async Task DivideFilePart(string sourcePath, string destinationPath, int startFrom, int count, int totalPartsCount, long sourceSize, long bufferSize, Action<(long Expected, long Current)> progressCallback)
        {

            var nonLastPartSize = sourceSize / totalPartsCount;
            var offset = nonLastPartSize * startFrom;
            var destinationFileSize = sourceSize / totalPartsCount;
            long totalRead = offset;

            var expectedLength = (startFrom + count == totalPartsCount)
                ? sourceSize - totalRead
                : count * destinationFileSize;

            using (var sourceStream = _fileAccessor.OpenFileForRead(sourcePath, true))
            {
                sourceStream.Seek(offset, SeekOrigin.Begin);

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

                            progressCallback?.Invoke((expectedLength, totalRead - offset));

                            await destinationStream.WriteAsync(bytes, 0, read);
                        }
                    }
                }
            }
        }
    }
}
