using Homework.Data.Repositories.DelimiterRepository;
using FromRepo = Homework.Data.Repositories.DelimiterRepository.Models;
using FromService = Homework.Services.DelimiterService.Implementation;
using Homework.Services.DelimiterService.Models;
using Homework.Services.FileService;
using FromFileService = Homework.Services.FileService.Models;
using Moq;
using Xunit;

namespace Homework.UnitTests.UnitTests.Services.DelimiterService.UnitTests
{
	public class DelimiterServiceGetDelimiterTests
	{
		public DelimiterServiceGetDelimiterTests() { }

		[Fact]
		// Unit test naming convention: MethodTested_ExpectedResponse_StateUnderTest
		public void GetDelimiter_ReturnsSuccess_CommaDelimitedRequest()
		{
			// Arrange.
			var delimitedValues = "Tester, Tommy, tommy@aol.com, aqua, 3/12/1990";
			var filePath = @"../Files/comma-delimited.txt";

			// Mock the repo response.
			var repoResponse = new FromRepo.GetDelimiterResponse
			{
				Success = true,
				Delimiter = new FromRepo.Delimiter
				{
					Character = char.Parse(","),
					Name = "comma",
					FilePath = filePath
				}
			};

			// Mock the repo.
			var mockRepo = new Mock<IDelimiterRepository>();
			mockRepo
				.Setup(s => s.GetDelimiter(It.Is<FromRepo.GetDelimiterRequest>(x => true)))
				.Returns(repoResponse);

			// Mock the file service response.
			var fileServiceResponse = new FromFileService.GetPathResponse
			{
				Success = true,
				FilePath = filePath
			};

			// Mock the file service.
			var mockfileService = new Mock<IFileService>();
			mockfileService
				.Setup(s => s.GetPath(It.Is<FromFileService.GetPathRequest>(x => true)))
				.Returns(fileServiceResponse);

			var serviceRequest = new GetDelimiterRequest { DelimitedValues = delimitedValues };

			// Set the system under test.
			var sut = new FromService.DelimiterService(mockRepo.Object, mockfileService.Object);

			// Act.
			var getDelimiterResponse = sut.GetDelimiter(serviceRequest);

			// Assert.
			Assert.True(getDelimiterResponse.Delimiter != null);
			Assert.True(getDelimiterResponse.Success);
		}
	}
}