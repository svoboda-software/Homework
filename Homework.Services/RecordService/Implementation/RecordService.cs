using Homework.Data.Repositories.RecordRepository;
using FromRepo = Homework.Data.Repositories.RecordRepository.Models;
using Homework.Services.DelimiterService;
using Homework.Services.DelimiterService.Models;
using Homework.Services.RecordService.Extensions;
using Homework.Services.RecordService.Models;
using Homework.Shared.Extensions;
using Homework.Shared.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Homework.Services.RecordService.Implementation
{
	public class RecordService : IRecordService
	{
		private readonly IRecordRepository repo;
		private readonly IDelimiterService delimiterService;
		public RecordService(IRecordRepository repo, IDelimiterService delimiterService)
		{
			this.repo = repo;
			this.delimiterService = delimiterService;
		}

		#region Public methods

		/// <summary>
		/// Returns all records from all data files.
		/// <summary>
		public GetRecordsResponse GetRecords(GetRecordsRequest request)
		{
			var records = GetRecords();

			return new GetRecordsResponse
			{
				Success = records != null,
				Records = records
			};
		}

		/// <summary>
		/// Returns all sorted records from all data files given a property to sort.
		/// <summary>
		public QueryPropertyResponse QueryProperty(QueryPropertyRequest request)
		{
			// Build the sorts.
			var sorts = new List<Sort>
			{
				new Sort
				{
					// Use string extension ToParsedPropertyName() to map api routes to Record property names.
					PropertyName = request.PropertyName.ToParsedPropertyName(),
					SortDirection = ListSortDirection.Ascending
				}
			};
			// Query the records.
			var sortedRecords = QueryRecords(GetRecords(), sorts);

			return new QueryPropertyResponse
			{
				Success = sortedRecords != null,
				Records = sortedRecords
			};

		}

		/// <summary>
		/// Returns all sorted records from all data files given a list of sorts.
		/// <summary>
		public QueryRecordsResponse QueryRecords(QueryRecordsRequest request)
		{
			// Query the records.
			var sortedRecords = QueryRecords(GetRecords(), request.Sorts);

			return new QueryRecordsResponse
			{
				Success = sortedRecords != null,
				Records = sortedRecords
			};
		}
		#endregion

		#region Private methods

		private Delimiter GetDelimiter(string delimitedValues)
		{
			// Use the delimiterService to get the delimiting character and the path to the delimited data file.
			return delimiterService.GetDelimiter(
				new GetDelimiterRequest { DelimitedValues = delimitedValues })
				.Delimiter;
		}

		private string[] GetValuesFromDelimiter(string delimitedValues)
		{
			return delimiterService.GetValuesFromDelimiter(
				new GetValuesFromDelimiterRequest
				{ DelimitedValues = delimitedValues })
				.Values;
		}

		private List<string[]> GetValuesFromAllDelimiters()
		{
			return delimiterService.GetValuesFromAllDelimiters(
				new GetValuesFromAllDelimitersRequest())
				.ValuesList;
		}

		/// <summary>
		/// Returns the record object and data source file name based on the delimited values.
		/// <summary>
		private Record GetRecord(string delimitedValues)
		{
			// Use the delimiter service to extract the delimiting character from the delimited string.
			var valuesList = delimiterService.GetValuesFromDelimiter(
				new GetValuesFromDelimiterRequest
				{ DelimitedValues = delimitedValues })
				.Values;

			var repoRecord = repo.GetRecord(
				new FromRepo.GetRecordRequest
				{ Values = valuesList })
				.Record;

			return ToServiceRecord(repoRecord);
		}

		private List<Record> GetRecords()
		{
			// Use the record repo to get the records.
			return repo.GetRecords(new FromRepo.GetRecordsRequest
			{
				// Get the delimited values from the data sources.
				ValuesList = GetValuesFromAllDelimiters()
			})?.Records?
			// Convert from the repo model to the service model.
			.Select(s => ToServiceRecord(s))
			.ToList();
		}

		private List<Sort> ParseSorts(List<Sort> sorts)
		{
			return sorts?.Select(s => new Sort
			{
				// Use string extension ToParsedPropertyName() to map api routes to Record property names.
				PropertyName = s.PropertyName.ToParsedPropertyName(),
				SortDirection = s.SortDirection
			}).ToList();
		}

		private List<Record> QueryRecords(List<Record> records, List<Sort> sorts)
		{
			// Use the Record repository to get the sorted records.
			return repo.QueryRecords(new FromRepo.QueryRecordsRequest
			{
				Sorts = sorts,
				Records = records?
					// Convert from the service model to the repo model.
					.Select(s => ToRepoRecord(s)).ToList()
			})?.Records?
			// Convert from the repo model to the service model.
			.Select(s => ToServiceRecord(s)).ToList();
		}

		private Record ToServiceRecord(FromRepo.Record r)
		{
			return new Record
			{
				LastName = r.LastName,
				FirstName = r.FirstName,
				Email = r.Email,
				FavoriteColor = r.FavoriteColor,
				// Use the Record service to handle the business logic of formatting dates.
				DateOfBirth = r.DateOfBirth.ToFormattedDateString()
			};
		}

		private FromRepo.Record ToRepoRecord(Record r)
		{
			return new FromRepo.Record
			{
				LastName = r.LastName,
				FirstName = r.FirstName,
				Email = r.Email,
				FavoriteColor = r.FavoriteColor,
				// Use DateTime extension to handle bad date data.
				DateOfBirth = r.DateOfBirth.ToParsedDate()
			};
		}
		#endregion
	}
}