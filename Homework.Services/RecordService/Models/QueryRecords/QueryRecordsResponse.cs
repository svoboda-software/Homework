using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Services.RecordService.Models
{
	public class QueryRecordsResponse : ResponseBase
	{
		public List<Record> Records { get; set; }
	}
}