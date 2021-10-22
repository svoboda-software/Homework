using Homework.Shared.Base;
using System.Collections.Generic;
namespace Homework.Data.Repositories.RecordRepository.Models
{
	public class GetRecordsRequest : RequestBase
	{
		public List<string[]> ValuesList { get; set; }
	}
}