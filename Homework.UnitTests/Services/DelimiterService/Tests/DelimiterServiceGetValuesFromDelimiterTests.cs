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
	public class DelimiterServiceGetValuesFromDelimiterTests
	{
		public DelimiterServiceGetValuesFromDelimiterTests() { }

		[Fact]
		// Unit test naming convention: MethodTested_ExpectedResponse_StateUnderTest
		public void GetValuesFromDelimiter_ReturnsSuccess_NullRequest()
		{
			// Arrange.
			// Mock the repo response from GetDelimiter().
			var getDelimiterResponse = new FromRepo.GetDelimiterResponse
			{
				Success = true,
				Delimiter = new FromRepo.Delimiter { Character = ',', Name = "comma", FilePath = @"../Files/comma-delimited.txt" }
			};

			// Mock the repo response from SplitValuesList().
			var splitValuesResponse = new FromRepo.SplitValuesResponse
			{
				Success = true,
				Values = new string[] { "Tester", "Tommy", "tommy@aol.com", "aqua", "3/12/1990" }
			};

			// Mock the repo.
			var mockRepo = new Mock<IDelimiterRepository>();
			mockRepo
				.Setup(s => s.GetDelimiter(It.Is<FromRepo.GetDelimiterRequest>(x => true)))
				.Returns(getDelimiterResponse);
			mockRepo
				.Setup(s => s.SplitValues(It.Is<FromRepo.SplitValuesRequest>(x => true)))
				.Returns(splitValuesResponse);


			// Mock the file service response from GetPath().
			var getPathResponse = new FromFileService.GetPathResponse
			{
				Success = true,
				FilePath = @"../Files/comma-delimited.txt"
			};

			// Mock the file service.
			var mockfileService = new Mock<IFileService>();
			mockfileService
				.Setup(s => s.GetPath(It.Is<FromFileService.GetPathRequest>(x => true)))
				.Returns(getPathResponse);

			// Set the system under test.
			var sut = new FromService.DelimiterService(mockRepo.Object, mockfileService.Object);

			// Act.
			var response = sut.GetValuesFromDelimiter(new GetValuesFromDelimiterRequest());

			// Assert.
			Assert.True(response.Values.Length > 0);
			Assert.True(response.Success);
		}
	}
}