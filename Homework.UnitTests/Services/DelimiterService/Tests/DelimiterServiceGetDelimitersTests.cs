using Homework.Data.Repositories.DelimiterRepository;
using FromRepo = Homework.Data.Repositories.DelimiterRepository.Models;
using FromService = Homework.Services.DelimiterService.Implementation;
using Homework.Services.DelimiterService.Models;
using Homework.Services.FileService;
using FromFileService = Homework.Services.FileService.Models;
using System.Collections.Generic;
using Moq;
using Xunit;

namespace Homework.UnitTests.UnitTests.Services.DelimiterService.UnitTests
{
	public class DelimiterServiceGetDelimitersTests
	{
		public DelimiterServiceGetDelimitersTests() { }

		[Fact]
		// Unit test naming convention: MethodTested_ExpectedResponse_StateUnderTest
		public void GetDelimiters_ReturnsSuccess_NullRequest()
		{
			// Arrange.
			// Mock the repo response.
			var response = new FromRepo.GetDelimitersResponse
			{
				Success = true,
				Delimiters = new List<FromRepo.Delimiter>
				{
					new FromRepo.Delimiter{ Character = char.Parse(","), Name = "comma" },
					new FromRepo.Delimiter{ Character = char.Parse("|"), Name = "pipe" },
					new FromRepo.Delimiter{ Character = char.Parse(" "), Name = "space" }
				}
			};

			// Mock the repo.
			var mockRepo = new Mock<IDelimiterRepository>();
			mockRepo
				.Setup(s => s.GetDelimiters(It.IsAny<FromRepo.GetDelimitersRequest>()))
				.Returns(response);

			// Mock the file service response for GetPath().
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
			var getDelimitersResponse = sut.GetDelimiters(new Homework.Services.DelimiterService.Models.GetDelimitersRequest());

			// Assert.
			Assert.NotNull(getDelimitersResponse.Delimiters);
			Assert.True(getDelimitersResponse?.Success);
		}
	}
}