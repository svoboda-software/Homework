using Homework.Data.Repositories.DelimiterRepository;
using FromRepo = Homework.Data.Repositories.DelimiterRepository.Models;
using FromService = Homework.Services.DelimiterService.Implementation;
using Homework.Services.DelimiterService.Models;
using Homework.Shared.Models;
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
		public void GetDelimiters_ReturnsSuccess_WithNullRequest()
		{
			// Arrange.
			var request = new FromRepo.GetDelimitersRequest();
			var response = new FromRepo.GetDelimitersResponse
			{
				Delimiters = new List<Delimiter>
				{
					new Delimiter { Symbol = ",", Name = "comma" },
					new Delimiter { Symbol = "|", Name = "pipe" },
					new Delimiter { Symbol = " ", Name = "space" }
				}
			};

			var mockRepo = new Mock<IDelimiterRepository>();
			mockRepo
				.Setup(s => s.GetDelimiters(It.IsAny<FromRepo.GetDelimitersRequest>()))
				.Returns(response);

			// Set the system under test.
			var sut = new FromService.DelimiterService(mockRepo.Object);

			// Act.
			var getDelimitersResponse = sut.GetDelimiters(new GetDelimitersRequest());

			// Assert.
			Assert.NotNull(getDelimitersResponse?.Delimiters);
			Assert.True(getDelimitersResponse?.Success);
		}
	}
}