using Homework.Data.Repositories.DelimiterRepository;
using FromRepo = Homework.Data.Repositories.DelimiterRepository.Models;
using FromService = Homework.Services.DelimiterService.Implementation;
using Homework.Services.DelimiterService.Models;
using Homework.Services.FileService;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

namespace Homework.UnitTests.UnitTests.Services.DelimiterService.UnitTests
{
	public class DelimiterServiceGetDelimitersTests
	{
		public DelimiterServiceGetDelimitersTests() { }

		#region Public methods

		[Fact]
		// Unit test naming convention: MethodTested_ExpectedResponse_StateUnderTest
		public void GetDelimiters_ReturnsSuccess_NullRequest()
		{
			// Arrange.
			var expected = GetDelimiters();

			// Mock the repo response.
			var response = new FromRepo.GetDelimitersResponse
			{
				Success = true,
				Delimiters = GetDelimiters()
					// Convert the expected result from the service model to the repository model.
					.Select(s => new FromRepo.Delimiter
					{
						Character = s.Character,
						Name = s.Name
					})
					.ToList()
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
		#endregion

		#region Private methods

		private List<Delimiter> GetDelimiters()
		{
			return new List<Delimiter>
			{
				new Delimiter{ Character = char.Parse(","), Name = "comma" },
				new Delimiter{ Character = char.Parse("|"), Name = "pipe" },
				new Delimiter{ Character = char.Parse(" "), Name = "space" }
			};
		}
		#endregion
	}
}