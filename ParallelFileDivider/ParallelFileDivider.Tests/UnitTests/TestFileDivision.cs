using Moq;
using NUnit.Framework;
using ParallelFileDivider.Core;
using ParallelFileDivider.Core.Contracts;
using ParallelFileDivider.Core.Dto;
using ParallelFileDivider.Core.Exceptions;
using ParallelFileDivider.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelFileDivider.Tests.UnitTests
{
    public class TestFileDivision
    {
        private string _destinationFolder = "des_folder";
        private string _sourceFile = "source_file";

        const int FILES_COUNT = 40;
        const int SOURCE_FILE_SIZE = 184892;
        const int BUFFER_SIZE = 500;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task FileDivider_should_correctly_DivideFile_in_one_streamAsync()
        {
            var fileAccessorMock = FileAccesorMockUtils.CreateFileAccessorMockWithRandomDivisionSource(
                _sourceFile,
                _destinationFolder,
                SOURCE_FILE_SIZE,
                FILES_COUNT,
                out byte[] sourceBuffer,
                out MemoryStream[] destinationStreams);

            IFileDivider fileDivider = new DefaultFileDivider(fileAccessorMock.Object);
            var expectedFileResult = sourceBuffer;

            var result = await fileDivider.DivideFile(_sourceFile, _destinationFolder, FILES_COUNT, 1, BUFFER_SIZE);

            Assert.IsTrue(result.IsComplete);
            var outputFileResult = destinationStreams.Aggregate(new byte[0], (bytes, stream) => Enumerable.Concat(bytes, stream.ToArray()).ToArray());
            Assert.AreEqual(expectedFileResult, outputFileResult);
        }

        [Test]
        public async Task FileDivider_should_correctly_DivideFile_in_multiple_streamsAsync()
        {
            var fileAccessorMock = FileAccesorMockUtils.CreateFileAccessorMockWithRandomDivisionSource(
                _sourceFile,
                _destinationFolder,
                SOURCE_FILE_SIZE,
                FILES_COUNT,
                out byte[] sourceBuffer,
                out MemoryStream[] destinationStreams);

            IFileDivider fileDivider = new DefaultFileDivider(fileAccessorMock.Object);
            var expectedFileResult = sourceBuffer;

            var result = await fileDivider.DivideFile(_sourceFile, _destinationFolder, FILES_COUNT, 20, BUFFER_SIZE);

            Assert.IsTrue(result.IsComplete);
            var outputFileResult = destinationStreams.Aggregate(new byte[0], (bytes, stream) => Enumerable.Concat(bytes, stream.ToArray()).ToArray());
            Assert.AreEqual(expectedFileResult, outputFileResult);
        }

        [Test]
        public async Task FileDivider_should_correctly_DivideFile_in_multiple_streams_with_progress()
        {
            var fileAccessorMock = FileAccesorMockUtils.CreateFileAccessorMockWithRandomDivisionSource(
                _sourceFile,
                _destinationFolder,
                SOURCE_FILE_SIZE,
                FILES_COUNT,
                out byte[] sourceBuffer,
                out MemoryStream[] destinationStreams);

            var parallelStreams = 20;
            var progressPrecision = 10000;
            var progressUpdatesLists = CreateProgressUpdatesLists(parallelStreams);
            var progressObserver = new DivisionProgressObserverDto()
            {
                ExpectedProgressPrecision = progressPrecision,
                ProgressChangedCallback = workerProgress => progressUpdatesLists[workerProgress.WorkerNumber].Add(workerProgress.Progress)
            };

            IFileDivider fileDivider = new DefaultFileDivider(fileAccessorMock.Object);
            var expectedFileResult = sourceBuffer;

            var result = await fileDivider.DivideFile(_sourceFile, _destinationFolder, FILES_COUNT, parallelStreams, BUFFER_SIZE, progressObserver);

            Assert.IsTrue(result.IsComplete);
            var outputFileResult = destinationStreams.Aggregate(new byte[0], (bytes, stream) => Enumerable.Concat(bytes, stream.ToArray()).ToArray());
            Assert.AreEqual(expectedFileResult, outputFileResult);

            foreach (var progressUpdates in progressUpdatesLists)
            {
                Assert.AreEqual(progressPrecision, progressUpdates.Max());
                AssertIsInAscendingOrder(progressUpdates);
            }
        }

        [Test]
        public void FileDivider_should_throw_when_file_does_not_exist()
        {
            var fileAccessorMock = FileAccesorMockUtils.CreateFileAccessorMock(
                _sourceFile,
                _destinationFolder,
                SOURCE_FILE_SIZE,
                FILES_COUNT,
                () => null,
                i => null,
                false,
                false);

            var fileDivider = new DefaultFileDivider(fileAccessorMock.Object);

            Assert.ThrowsAsync<FileOperationException>(async () => await fileDivider.DivideFile(_sourceFile, _destinationFolder, FILES_COUNT, 20, BUFFER_SIZE));
        }

        private List<int>[] CreateProgressUpdatesLists(int parallelThreads)
        {
            return Enumerable
                .Repeat<List<int>>(null, parallelThreads)
                .Select(_ => new List<int>())
                .ToArray();
        }

        private void AssertIsInAscendingOrder(List<int> updates)
        {
            var orderedUpdates = updates.OrderBy(i => i).ToList();
            Assert.IsTrue(orderedUpdates.SequenceEqual(updates));
        }
    }
}