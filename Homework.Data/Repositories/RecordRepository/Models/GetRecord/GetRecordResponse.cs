using Homework.Shared.Base;

namespace Homework.Data.Repositories.RecordRepository.Models
{
	public class GetRecordResponse : ResponseBase
	{
		public Record Record { get; set; }
	}
}