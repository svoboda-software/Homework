using Homework.Shared.Base;

namespace Homework.Data.Repositories.RecordRepository.Models
{
	public class GetRecordRequest : RequestBase
	{
		public string[] Values { get; set; }
	}
}