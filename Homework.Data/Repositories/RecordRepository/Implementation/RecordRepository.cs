using Homework.Data.Repositories.RecordRepository.Models;
using Homework.Shared.Extensions;
using System.IO;
using System.Linq;

namespace Homework.Data.Repositories.RecordRepository.Implementation
{
	public class RecordRepository : IRecordRepository
	{
		public RecordRepository() { }

		#region Public methods

		/// <summary>
		/// Add the record to the data file.
		/// <summary>
		public AddRecordResponse AddRecord(AddRecordRequest request)
		{
			bool success = false;

			// Make an assumption that the file will exist, and we don't need to create a file.
			if (File.Exists(request.Path))
			{
				using (StreamWriter stream = File.AppendText(request.Path))
				{
					stream.WriteLine(request.DelimitedValues);
					success = true;
				}
			}

			return new AddRecordResponse
			{
				Success = success
			};
		}

		/// <summary>
		/// Returns a single record from a given value array.
		/// <summary>
		public GetRecordResponse GetRecord(GetRecordRequest request)
		{
			var record = ToRecord(request.Values);

			return new GetRecordResponse
			{
				Success = record != null,
				Record = record
			};
		}

		/// <summary>
		/// Returns all records from the given value array.
		/// <summary>
		public GetRecordsResponse GetRecords(GetRecordsRequest request)
		{
			var records = request.ValuesList
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
			var records = request.Records
				// Convert the list to IQueryable.
				.AsQueryable()
				// Use an IQueryable extension to query the records by each sort.
				.SortBy<Record>(request?.Sorts)
				.ToList();

			return new QueryRecordsResponse
			{
				Records = records,
				Success = records != null
			};
		}
		#endregion

		#region Private methods

		private Record ToRecord(string[] values)
		{
			// Trim all values.
			var v = values?.Select(s => s.Trim()).ToArray();

			return new Record
			{
				LastName = v[0],
				FirstName = v[1],
				Email = v[2],
				FavoriteColor = v[3],
				DateOfBirth = v[4].ToParsedDate()
			};
		}
		#endregion
	}
}