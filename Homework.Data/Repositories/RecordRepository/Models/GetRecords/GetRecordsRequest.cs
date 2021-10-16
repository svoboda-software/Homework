using Homework.Shared.Base;
using Homework.Shared.Models;
using System.Collections.Generic;

namespace Homework.Data.Repositories.RecordRepository.Models
{
	public class GetRecordsRequest : RequestBase
	{
		public List<File> Files { get; set; }
	}
}