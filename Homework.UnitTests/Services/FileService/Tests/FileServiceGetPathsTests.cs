using Homework.Data.Repositories.FileRepository;
using FromRepo = Homework.Data.Repositories.FileRepository.Models;
using FromService = Homework.Services.FileService.Implementation;
using Homework.Services.FileService.Models;
using System.Linq;
using Moq;
using Xunit;

namespace Homework.UnitTests.UnitTests.Services.FileService.UnitTests
{
	public class FileServiceGetPathsTests
	{
		public FileServiceGetPathsTests() { }

		[Fact]
		// Unit test naming convention: MethodTested_ExpectedResponse_StateUnderTest
		public void GetPaths_ReturnsSuccess_ValidDelimitersRequest()
		{
			// Arrange.
			string[] delimiterNames = { "comma", "pipe", "space" };

			// Mock the repo response.
			var response = new FromRepo.GetPathsResponse
			{
				Success = true,
				Paths = delimiterNames.Select(s => GetPath(s)).ToList()
			};

			// Mock the repo.
			var mockRepo = new Mock<IFileRepository>();
			mockRepo
				.Setup(s => s.GetPaths(It.IsAny<FromRepo.GetPathsRequest>()))
				.Returns(response);

			// Set the system under test.
			var sut = new FromService.FileService(mockRepo.Object);

			// Act.
			var getPathsResponse = sut.GetPaths(new GetPathsRequest());

			// Assert.
			Assert.NotNull(getPathsResponse?.FilePaths);
			Assert.True(getPathsResponse?.Success);
		}

		#region Private methods

		private string GetPath(string delmiterName)
		{
			return $@"../Files/{delmiterName}-delimited.txt";
		}
		#endregion
	}
}