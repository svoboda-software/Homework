using Homework.Shared.Base;
using Homework.Shared.Models;
using System.Collections.Generic;

namespace Homework.Services.RecordService.Models
{
	public class QueryRecordsRequest : RequestBase
	{
		public List<Sort> Sorts { get; set; }
	}
}