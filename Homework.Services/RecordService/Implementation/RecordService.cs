using Homework.Data.Repositories.RecordRepository;
using FromRepo = Homework.Data.Repositories.RecordRepository.Models;
using Homework.Services.FileService;
using Homework.Services.FileService.Models;
using Homework.Services.RecordService.Models;
using System.Collections.Generic;
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
			var records = new List<Record>();

			// TODO: Call the repo to get the sorted records.

			return new QueryRecordsResponse
			{
				Success = records != null,
				Records = records
			};
		}
		#endregion
	}
}