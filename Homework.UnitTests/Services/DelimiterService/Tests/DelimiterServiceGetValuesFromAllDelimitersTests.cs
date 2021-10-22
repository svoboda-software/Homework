using Homework.Data.Repositories.DelimiterRepository;
using FromRepo = Homework.Data.Repositories.DelimiterRepository.Models;
using FromService = Homework.Services.DelimiterService.Implementation;
using Homework.Services.DelimiterService.Models;
using Homework.Services.FileService;
using FromFileService = Homework.Services.FileService.Models;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Homework.UnitTests.UnitTests.Services.DelimiterService.UnitTests
{
	public class DelimiterServiceGetValuesFromAllDelimitersTests
	{
		public DelimiterServiceGetValuesFromAllDelimitersTests() { }

		[Fact]
		// Unit test naming convention: MethodTested_ExpectedResponse_StateUnderTest
		public void GetValuesFromAllDelimiters_ReturnsSuccess_NullRequest()
		{
			// Arrange.
			// Mock the repo response from GetDelimiters().
			var getDelimitersResponse = new FromRepo.GetDelimitersResponse
			{
				Success = true,
				Delimiters = new List<FromRepo.Delimiter>
				{
					new FromRepo.Delimiter { Character = ',', Name = "comma", FilePath = @"../Files/comma-delimited.txt" },
				}
			};

			// Mock the repo response from SplitValuesList().
			var splitValuesListResponse = new FromRepo.SplitValuesListResponse
			{
				Success = true,
				ValuesList = new List<string[]>
				{
					new string[] { "Tester", "Tommy", "tommy@aol.com", "aqua", "3/12/1990" },
					new string[] { "Tester", "Tessa", "tessa@aol.com", "blue", "3/13/1990" }
				}
			};

			// Mock the repo.
			var mockRepo = new Mock<IDelimiterRepository>();
			mockRepo
				.Setup(s => s.GetDelimiters(It.Is<FromRepo.GetDelimitersRequest>(x => true)))
				.Returns(getDelimitersResponse);
			mockRepo
				.Setup(s => s.SplitValuesList(It.Is<FromRepo.SplitValuesListRequest>(x => true)))
				.Returns(splitValuesListResponse);

			// Mock the file service response from GetLines().
			var getLinesResponse = new FromFileService.GetLinesResponse
			{
				Success = true,
				FileLines = new List<string>
				{
					{ "Tester, Tommy, tommy@aol.com, aqua, 3/12/1990" },
					{ "Tester, Tessa, tessa@aol.com, blue, 3/13/1990" }
				}
			};

			// Mock the file service response from GetPath().
			var getPathResponse = new FromFileService.GetPathResponse
			{
				Success = true,
				FilePath = @"../Files/comma-delimited.txt"
			};

			// Mock the file service.
			var mockfileService = new Mock<IFileService>();
			mockfileService
				.Setup(s => s.GetLines(It.Is<FromFileService.GetLinesRequest>(x => true)))
				.Returns(getLinesResponse);
			mockfileService
				.Setup(s => s.GetPath(It.Is<FromFileService.GetPathRequest>(x => true)))
				.Returns(getPathResponse);

			// Set the system under test.
			var sut = new FromService.DelimiterService(mockRepo.Object, mockfileService.Object);

			// Act.
			var response = sut.GetValuesFromAllDelimiters(new GetValuesFromAllDelimitersRequest());

			// Assert.
			Assert.True(response.ValuesList.Count > 0);
			Assert.True(response.Success);
		}
	}
}