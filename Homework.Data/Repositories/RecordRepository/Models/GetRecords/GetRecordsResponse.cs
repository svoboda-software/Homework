using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Data.Repositories.RecordRepository.Models
{
	public class GetRecordsResponse : ResponseBase
	{
		public List<Record> Records { get; set; }
	}
}