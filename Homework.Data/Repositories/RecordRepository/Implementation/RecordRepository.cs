using Homework.Data.Repositories.RecordRepository.Models;
using System.Collections.Generic;

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
			var records = new List<Record>();

			// TODO: Use System.Linq to parse the list of input files.

			// request?.Files?
			// .ForEach(f =>
			// records.AddRange(

			// TODO: Use System.IO to read file into a string array.
			// TODO: Use System.Linq to project each element of the sequence into a record.

			// .ToList()));

			return new GetRecordsResponse
			{
				Success = records != null,
				Records = records
			};
		}

		#endregion
	}
}