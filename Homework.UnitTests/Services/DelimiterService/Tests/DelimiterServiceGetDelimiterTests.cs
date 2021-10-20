using Homework.Data.Repositories.DelimiterRepository;
using FromRepo = Homework.Data.Repositories.DelimiterRepository.Models;
using FromService = Homework.Services.DelimiterService.Implementation;
using Homework.Services.DelimiterService.Models;
using Homework.Services.FileService;
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
			var serviceRequest = new GetDelimiterRequest { DelimitedValues = delimitedValues };

			// Mock the repo response.
			var repoResponse = new FromRepo.GetDelimiterResponse
			{
				Success = true,
				Delimiter = char.Parse(",")
			};

			// Mock the repo.
			var mockRepo = new Mock<IDelimiterRepository>();
			mockRepo
				.Setup(s => s.GetDelimiter(It.Is<FromRepo.GetDelimiterRequest>(x => true)))
				.Returns(repoResponse);

			// Mock the file service.
			var mockfileService = new Mock<IFileService>();

			// Set the system under test.
			var sut = new FromService.DelimiterService(mockRepo.Object, mockfileService.Object);

			// Act.
			var getDelimiterResponse = sut.GetDelimiter(serviceRequest);

			// Assert.
			Assert.True(getDelimiterResponse.Delimiter.Equals(char.Parse(",")));
			Assert.True(getDelimiterResponse.Success);
		}
	}
}