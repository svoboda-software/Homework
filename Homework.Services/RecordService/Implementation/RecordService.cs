using Homework.Data.Repositories.RecordRepository;
using FromRepo = Homework.Data.Repositories.RecordRepository.Models;
using Homework.Services.DelimiterService;
using Homework.Services.DelimiterService.Models;
using Homework.Services.RecordService.Models;
using Homework.Shared.Extensions;
using System;
using System.Collections.Generic;
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
			// Use the record repo to get the records.
			var records = repo.GetRecords(new FromRepo.GetRecordsRequest
			{
				// Get the delimited values from the data sources.
				ValueArrays = GetDelimitedValues()
			})?.Records?
			// Convert from the repo model to the service model.
			.Select(s => ToRecord(s))
			.ToList();

			return new GetRecordsResponse
			{
				Success = records != null,
				Records = records
			};
		}

		public QueryRecordsResponse QueryRecords(QueryRecordsRequest request)
		{
			// Get the records.
			var records = GetRecords(new GetRecordsRequest())?.Records;

			// Query the records.
			var sorted = repo.QueryRecords(new FromRepo.QueryRecordsRequest
			{
				Sorts = request?.Sorts,
				Records = records?
					// Convert from the service model to the repo model.
					.Select(s => ToRepoRecord(s)).ToList()
			})?.Records?
			// Convert from the repo model to the service model.
			.Select(s => ToRecord(s)).ToList();

			return new QueryRecordsResponse
			{
				Success = sorted != null,
				Records = sorted
			};
		}
		#endregion

		#region Private methods

		private List<string[]> GetDelimitedValues()
		{
			return delimiterService.GetDelimitedValues(
				new GetDelimitedValuesRequest())
				.Values;
		}

		private Record ToRecord(FromRepo.Record r)
		{
			return new Record
			{
				LastName = r.LastName,
				FirstName = r.FirstName,
				Email = r.Email,
				FavoriteColor = r.FavoriteColor,
				// Use the record service to handle the business logic of formatting dates.
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
				DateOfBirth = Convert.ToDateTime(r.DateOfBirth)
			};
		}
		#endregion
	}
}