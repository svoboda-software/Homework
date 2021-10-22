using Homework.Data.Repositories.RecordRepository;
using FromRepo = Homework.Data.Repositories.RecordRepository.Models;
using FromService = Homework.Services.RecordService.Implementation;
using FromServiceModels = Homework.Services.RecordService.Models;
using Homework.Services.DelimiterService;
using FromDelimiterService = Homework.Services.DelimiterService.Models;
using Moq;
using System;
using Xunit;

namespace Homework.UnitTests.UnitTests.Services.RecordService.UnitTests
{
	public class RecordServiceAddRecordTests
	{
		public RecordServiceAddRecordTests() { }

		[Fact]
		// Unit test naming convention: MethodTested_ExpectedResponse_StateUnderTest
		public void AddRecord_ReturnsSuccess_CommaDelimited()
		{
			// Arrange.
			var expected = new FromServiceModels.Record
			{
				LastName = "Tester",
				FirstName = "Tommy",
				Email = "tommy@aol.com",
				FavoriteColor = "aqua",
				DateOfBirth = "3/12/1990"
			};

			// Mock the repo response from AddRecord().
			var addRecordResponse = new FromRepo.AddRecordResponse
			{
				Success = true,
			};

			// Mock the repo response from GetRecord().
			var getRecordResponse = new FromRepo.GetRecordResponse
			{
				Success = true,
				Record = new FromRepo.Record
				{
					LastName = expected.LastName,
					FirstName = expected.FirstName,
					Email = expected.Email,
					FavoriteColor = expected.FavoriteColor,
					DateOfBirth = Convert.ToDateTime(expected.DateOfBirth)
				}
			};

			// Mock the repo.
			var mockRepo = new Mock<IRecordRepository>();
			mockRepo
				.Setup(s => s.AddRecord(It.Is<FromRepo.AddRecordRequest>(x => true)))
				.Returns(addRecordResponse);
			mockRepo
				.Setup(s => s.GetRecord(It.Is<FromRepo.GetRecordRequest>(x => true)))
				.Returns(getRecordResponse);

			// Mock the delimiter service response from GetDelimiter().
			var getDelimiterResponse = new FromDelimiterService.GetDelimiterResponse
			{
				Success = true,
				Delimiter = new FromDelimiterService.Delimiter
				{
					Character = ',',
					Name = "comma",
					FilePath = @"../Files/comma-delimited.txt"
				}
			};

			// Mock the delimiter service response from GetValuesFromDelimiter().
			var getValuesResponse = new FromDelimiterService.GetValuesFromDelimiterResponse
			{
				Success = true,
				Values = new string[] { "Tester", "Tommy", "tommy@aol.com", "aqua", "3/12/1990" },
			};

			// Mock the delimiter service.
			var mockDelimiterService = new Mock<IDelimiterService>();
			mockDelimiterService
				.Setup(s => s.GetDelimiter(It.Is<FromDelimiterService.GetDelimiterRequest>(x => true)))
				.Returns(getDelimiterResponse);
			mockDelimiterService
				.Setup(s => s.GetValuesFromDelimiter(It.Is<FromDelimiterService.GetValuesFromDelimiterRequest>(x => true)))
				.Returns(getValuesResponse);

			// Set the system under test.
			var sut = new FromService.RecordService(mockRepo.Object, mockDelimiterService.Object);

			// Act.
			var response = sut.AddRecord(new FromServiceModels.AddRecordRequest
			{
				DelimitedValues = "Tester, Tommy, tommy@aol.com, aqua, 3/12/1990"
			});
			var actual = response.Record;
			// Assert.
			Assert.Equal(expected.LastName, actual.LastName);
			Assert.Equal(expected.FirstName, actual.FirstName);
			Assert.Equal(expected.Email, actual.Email);
			Assert.Equal(expected.FavoriteColor, actual.FavoriteColor);
			Assert.Equal(expected.DateOfBirth, actual.DateOfBirth);
			Assert.True(response.Success);
		}
	}
}