using Homework.Data.Repositories.DelimiterRepository;
using FromRepo = Homework.Data.Repositories.DelimiterRepository.Models;
using FromService = Homework.Services.DelimiterService.Implementation;
using Homework.Services.DelimiterService.Models;
using Homework.Services.FileService;
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

			// Mock the file service.
			var mockfileService = new Mock<IFileService>();

			// Set the system under test.
			var sut = new FromService.DelimiterService(mockRepo.Object, mockfileService.Object);

			// Act.
			var getDelimitersResponse = sut.GetDelimiters(new GetDelimitersRequest());

			// Assert.
			Assert.NotNull(getDelimitersResponse.Delimiters);
			Assert.True(getDelimitersResponse?.Success);
		}
	}
}