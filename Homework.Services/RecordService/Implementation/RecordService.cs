using Homework.Data.Repositories.RecordRepository;
using Homework.Services.RecordService.Models;

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
			return new GetRecordsResponse();
		}
		#endregion
	}
}