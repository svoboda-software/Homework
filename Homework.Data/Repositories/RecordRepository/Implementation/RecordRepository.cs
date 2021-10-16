using Homework.Data.Repositories.RecordRepository.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Homework.Data.Repositories.RecordRepository.Implementation
{
	public class RecordRepository : IRecordRepository
	{
		public RecordRepository() { }

		#region "Public methods"

		/// <summary>
		/// Returns all records from the given files.
		/// <summary>
		public GetRecordsResponse GetRecords(GetRecordsRequest request)
		{
			var records = new List<Record>();

			request?.Files?
				.ForEach(f =>
					records.AddRange(
					// Lazy load the file with File.ReadLines() instead of loading the entire file into memory with File.ReadAllLines().
					File.ReadLines(f.Path)
					.Skip(1)
					.Select(s => s.Split(f.Delimiter))
					.Select(s => ToRecord(s))
					.ToList()));

			return new GetRecordsResponse
			{
				Success = records != null,
				Records = records
			};
		}
		#endregion

		#region "Private methods"

		private Record ToRecord(string[] values)
		{
			// Trim all values.
			values = values.Select(s => s.Trim()).ToArray();

			return new Record
			{
				LastName = values[0],
				FirstName = values[1],
				Email = values[2],
				FavoriteColor = values[3],
				DateOfBirth = Convert.ToDateTime(values[4])
			};
		}
		#endregion
	}
}