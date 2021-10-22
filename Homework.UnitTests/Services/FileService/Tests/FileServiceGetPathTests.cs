using Homework.Data.Repositories.FileRepository;
using FromRepo = Homework.Data.Repositories.FileRepository.Models;
using FromService = Homework.Services.FileService.Implementation;
using Homework.Services.FileService.Models;
using Moq;
using Xunit;

namespace Homework.UnitTests.UnitTests.Services.FileService.UnitTests
{
	public class FileServiceGetPathTests
	{
		public FileServiceGetPathTests() { }

		[Fact]
		// Unit test naming convention: MethodTested_ExpectedResponse_StateUnderTest
		public void GetPath_ReturnsSuccess_ValidDelimiterRequest()
		{
			// Arrange.
			// Mock the repo response.
			var response = new FromRepo.GetPathResponse
			{
				Success = true,
				Path = $@"../Files/comma-delimited.txt"
			};

			// Mock the repo.
			var mockRepo = new Mock<IFileRepository>();
			mockRepo
				.Setup(s => s.GetPath(It.IsAny<FromRepo.GetPathRequest>()))
				.Returns(response);

			// Set the system under test.
			var sut = new FromService.FileService(mockRepo.Object);

			// Act.
			var getPathResponse = sut.GetPath(new GetPathRequest());

			// Assert.
			Assert.NotNull(getPathResponse?.FilePath);
			Assert.True(getPathResponse?.Success);
		}
	}
}