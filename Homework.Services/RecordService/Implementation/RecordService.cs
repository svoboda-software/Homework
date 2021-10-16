using Homework.Data.Repositories.RecordRepository;
using FromRepo = Homework.Data.Repositories.RecordRepository.Models;
using Homework.Services.FileService;
using Homework.Services.FileService.Models;
using Homework.Services.RecordService.Models;
using System;
using System.Linq;

namespace Homework.Services.RecordService.Implementation
{
	public class RecordService : IRecordService
	{
		private readonly IRecordRepository repo;
		private readonly IFileService fileService;
		public RecordService(IRecordRepository repo, IFileService fileService)
		{
			this.repo = repo;
			this.fileService = fileService;
		}

		#region "Public methods"

		/// <summary>
		/// Returns all records from all data files.
		/// <summary>
		public GetRecordsResponse GetRecords(GetRecordsRequest request)
		{
			// Use the record repo to get the records..
			var records = repo.GetRecords(new FromRepo.GetRecordsRequest
			{
				Files = fileService.GetFiles(new GetFilesRequest())?.Files
			})?.Records?
			// Convert from the repo model to the service model.
			.Select(s => new Record
			{
				LastName = s.LastName,
				FirstName = s.FirstName,
				Email = s.Email,
				FavoriteColor = s.FavoriteColor,
				DateOfBirth = s.DateOfBirth.ToString()
			})
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
				// Convert from the service model to the repo entity for the request.
				Records = records?.Select(s => new FromRepo.Record
				{
					LastName = s.LastName,
					FirstName = s.FirstName,
					Email = s.Email,
					FavoriteColor = s.FavoriteColor,
					DateOfBirth = Convert.ToDateTime(s.DateOfBirth)
				}).ToList()
				// Convert from the repo entity to the service model for the response.
			})?.Records?.Select(s => new Record
			{
				LastName = s.LastName,
				FirstName = s.FirstName,
				Email = s.Email,
				FavoriteColor = s.FavoriteColor,
				DateOfBirth = s.DateOfBirth.ToString()
			}).ToList();


			return new QueryRecordsResponse
			{
				Success = sorted != null,
				Records = sorted
			};
		}
		#endregion
	}
}