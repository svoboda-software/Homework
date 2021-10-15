using Homework.Data.Repositories.RecordRepository.Models;

namespace Homework.Data.Repositories.RecordRepository.Implementation
{
	public class RecordRepository : IRecordRepository
	{
		public RecordRepository() { }

		#region "Public methods"

		/// <summary>
		/// Returns all records from all file sources.
		/// <summary>
		public GetRecordsResponse GetRecords(GetRecordsRequest request)
		{
			return new GetRecordsResponse
			{
			};
		}

		#endregion
	}
}