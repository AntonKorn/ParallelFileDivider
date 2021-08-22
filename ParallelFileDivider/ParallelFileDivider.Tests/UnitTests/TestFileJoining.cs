using NUnit.Framework;
using ParallelFileDivider.Core;
using ParallelFileDivider.Core.Dto;
using ParallelFileDivider.Core.Exceptions;
using ParallelFileDivider.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelFileDivider.Tests.UnitTests
{
    public class TestFileJoining
    {
        private string _sourceFolder = "source_folder";
        private string _destinationFile = "des_file";

        const int FILES_COUNT = 40;
        const int DESTINATION_FILE_SIZE = 184892;
        const int BUFFER_SIZE = 500;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task FileDivider_should_JoinFiles_in_one_stream_correctlyAsync()
        {
            var fileAccessorMock = FileAccesorMockUtils.CreateFileAccessorMockWithRandomJoinSource(
                _destinationFile,
                _sourceFolder,
                DESTINATION_FILE_SIZE,
                FILES_COUNT,
                1,
                out var sourceBufers,
                out var destinationStreams);

            var expectedResult = sourceBufers.Aggregate((first, second) => Enumerable.Concat(first, second).ToArray());
            var fileDivider = new DefaultFileDivider(fileAccessorMock.Object);

            var result = await fileDivider.JoinFile(_sourceFolder, _destinationFile, BUFFER_SIZE);

            Assert.IsTrue(result.IsComplete);
            Assert.AreEqual(expectedResult, destinationStreams[0].ToArray());
        }

        [Test]
        public async Task FileDivider_should_JoinFiles_in_one_stream_correctly_with_progress()
        {

            var fileAccessorMock = FileAccesorMockUtils.CreateFileAccessorMockWithRandomJoinSource(
                _destinationFile,
                _sourceFolder,
                DESTINATION_FILE_SIZE,
                FILES_COUNT,
                1,
                out var sourceBufers,
                out var destinationStreams);

            var progressPrecision = 10000;
            var progressUpdates = new List<int>();
            var progressObserver = new JoinProgressObsererDto()
            {
                ExpectedDestiationFileSize = DESTINATION_FILE_SIZE,
                ExpectedProgressPrecision = progressPrecision,
                ProgressChangedCallback = status => progressUpdates.Add(status.Progress)
            };

            var expectedResult = sourceBufers.Aggregate((first, second) => Enumerable.Concat(first, second).ToArray());
            var fileDivider = new DefaultFileDivider(fileAccessorMock.Object);

            var result = await fileDivider.JoinFile(_sourceFolder, _destinationFile, BUFFER_SIZE, progressObserver);

            Assert.IsTrue(result.IsComplete);
            Assert.AreEqual(expectedResult, destinationStreams[0].ToArray());
            Assert.AreEqual(progressPrecision, progressUpdates.Max());
            FileDividerUtils.AssertIsInAscendingOrder(progressUpdates);
        }

        [Test]
        public void FileDivider_should_throw_when_file_already_exists()
        {
            var fileAccessorMock = FileAccesorMockUtils.CreateFileAccessorMock(
                _destinationFile,
                _sourceFolder,
                DESTINATION_FILE_SIZE,
                FILES_COUNT,
                () => null,
                i => null,
                false,
                true);

            var fileDivider = new DefaultFileDivider(fileAccessorMock.Object);

            Assert.ThrowsAsync<FileOperationException>(async () => await fileDivider.JoinFile(_sourceFolder, _destinationFile, BUFFER_SIZE));
        }

        [Test]
        public void FileDivider_should_throw_when_folder_does_not_exists()
        {
            var fileAccessorMock = FileAccesorMockUtils.CreateFileAccessorMock(
                _destinationFile,
                _sourceFolder,
                DESTINATION_FILE_SIZE,
                FILES_COUNT,
                () => null,
                i => null,
                false,
                false,
                false);

            var fileDivider = new DefaultFileDivider(fileAccessorMock.Object);

            Assert.ThrowsAsync<FileOperationException>(async () => await fileDivider.JoinFile(_sourceFolder, _destinationFile, BUFFER_SIZE));
        }
    }
}
