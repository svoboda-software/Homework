using Homework.Data.Repositories.FileRepository;
using FromRepo = Homework.Data.Repositories.FileRepository.Models;
using FromService = Homework.Services.FileService.Implementation;
using Homework.Services.FileService.Models;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace Homework.UnitTests.UnitTests.Services.FileService.UnitTests
{
	public class FileServiceGetLinesTests
	{
		public FileServiceGetLinesTests() { }

		[Fact]
		// Unit test naming convention: MethodTested_ExpectedResponse_StateUnderTest
		public void GetLines_ReturnsSuccess_ValidFilePaths()
		{
			// Arrange.
			// Mock the repo response.
			var response = new FromRepo.GetLinesResponse
			{
				Success = true,
				Lines = new List<string> { "Tester, Tommy, tommy@aol.com, aqua, 3/12/1990" }
			};

			// Mock the repo.
			var mockRepo = new Mock<IFileRepository>();
			mockRepo
				.Setup(s => s.GetLines(It.IsAny<FromRepo.GetLinesRequest>()))
				.Returns(response);

			// Set the system under test.
			var sut = new FromService.FileService(mockRepo.Object);

			// Act.
			var GetLinesResponse = sut.GetLines(new GetLinesRequest());

			// Assert.
			Assert.NotNull(GetLinesResponse?.FileLines);
			Assert.True(GetLinesResponse?.Success);
		}
	}
}