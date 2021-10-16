using Homework.Data.Repositories.RecordRepository;
using FromRepo = Homework.Data.Repositories.RecordRepository.Models;
using Homework.Services.RecordService.Models;
using System.Linq;

namespace Homework.Services.RecordService.Implementation
{
	public class RecordService : IRecordService
	{
		private readonly IRecordRepository repo;
		public RecordService(IRecordRepository repo)
		{
			this.repo = repo;
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
				// TODO: Use a file service to return the files in order to request records.
				// Files = fileService.GetFiles()
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
		#endregion
	}
}