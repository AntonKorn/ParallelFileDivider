using Moq;
using ParallelFileDivider.Core.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Tests.Helpers
{
    public static class FileAccesorMockUtils
    {
        public static Mock<IFileAccessor> CreateFileAccessorMock(
            string fileName,
            string folderName,
            long fileSize,
            int filesCount,
            Func<MemoryStream> createFileStream,
            Func<int, MemoryStream> createPartFileStream,
            bool isFileSource = true,
            bool isFileExists = true,
            bool isFolderExists = true
            )
        {
            var fileAccessorMock = new Mock<IFileAccessor>();
            fileAccessorMock.Setup(fa => fa.EnsureFolderExists(folderName));
            fileAccessorMock.Setup(fa => fa.IsFolderExist(folderName)).Returns(isFolderExists);
            fileAccessorMock.Setup(fa => fa.IsFileExist(fileName)).Returns(isFileExists);
            fileAccessorMock.Setup(fa => fa.GetFileSize(fileName)).Returns(fileSize);

            var partFiles = Enumerable.Range(0, filesCount).Select(i => $"chunk{i}.prt");
            fileAccessorMock.Setup(fa => fa.GetFileNames(folderName, "*.prt")).Returns(partFiles);

            if (isFileSource)
            {
                fileAccessorMock.Setup(fa => fa.OpenFileForRead(fileName, true)).Returns(createFileStream);
                fileAccessorMock.Setup(fa => fa.OpenFileForWrite(It.IsAny<string>(), It.IsAny<bool>()))
                    .Returns((string path, bool parallel) =>
                    {
                        var folderFileName = Path.GetFileName(path);
                        return createPartFileStream(int.Parse(folderFileName[5..].Split('.')[0]));
                    });
            }
            else
            {
                fileAccessorMock.Setup(fa => fa.OpenFileForRead(It.IsAny<string>(), It.IsAny<bool>()))
                    .Returns((string path, bool parallel) =>
                    {
                        var folderFileName = Path.GetFileName(path);
                        return createPartFileStream(int.Parse(folderFileName[5..].Split('.')[0]));
                    });

                fileAccessorMock.Setup(fa => fa.OpenFileForWrite(fileName, false)).Returns(createFileStream);
            }

            return fileAccessorMock;
        }

        public static Mock<IFileAccessor> CreateFileAccessorMockWithRandomDivisionSource(
            string fileName,
            string folderName,
            int fileSize,
            int filesCount,
            out byte[] sourceBuffer,
            out MemoryStream[] destinationStreams)
        {
            var buffer = CreateRandomBuffer(fileSize);

            var partsStreams = new MemoryStream[40];
            for (var i = 0; i < filesCount; i++)
            {
                partsStreams[i] = new MemoryStream();
            }

            sourceBuffer = buffer;
            destinationStreams = partsStreams;

            return CreateFileAccessorMock(
                fileName,
                folderName,
                fileSize,
                filesCount,
                () => new MemoryStream(buffer),
                (i) => partsStreams[i]);
        }

        public static Mock<IFileAccessor> CreateFileAccessorMockWithRandomJoinSource(
            string fileName,
            string folderName,
            int fileSize,
            int filesCount,
            int destinationParallelStreamsCount,
            out byte[][] sourceBuffers,
            out MemoryStream[] destinationStreams
            )
        {
            var sourceFileSize = fileSize / filesCount;

            var buffersInFolder = new byte[filesCount][];
            for (var i = 0; i < filesCount - 1; i++)
            {
                buffersInFolder[i] = CreateRandomBuffer(sourceFileSize);
            }

            var lastBufferSize = fileSize - ((filesCount - 1) * sourceFileSize);
            buffersInFolder[filesCount - 1] = CreateRandomBuffer(lastBufferSize);
            sourceBuffers = buffersInFolder;

            var resultStreams = new MemoryStream[destinationParallelStreamsCount];
            var nextDestinationStreamPointer = 0;
            destinationStreams = resultStreams;

            return CreateFileAccessorMock(
                fileName,
                folderName,
                fileSize,
                filesCount,
                () =>
                {
                    resultStreams[nextDestinationStreamPointer] = new MemoryStream();
                    return resultStreams[nextDestinationStreamPointer++];
                },
                i => new MemoryStream(buffersInFolder[i]),
                false,
                false);
        }

        public static byte[] CreateRandomBuffer(int size)
        {
            var buffer = new byte[size];
            var random = new Random();
            random.NextBytes(buffer);
            return buffer;
        }
    }
}
