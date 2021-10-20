using Homework.Shared.Models;
using System.Collections.Generic;

namespace Homework.Data.Repositories.RecordRepository.Models
{
	public class QueryRecordsRequest
	{
		public List<Record> Records { get; set; }
		public List<Sort> Sorts { get; set; }
	}
}