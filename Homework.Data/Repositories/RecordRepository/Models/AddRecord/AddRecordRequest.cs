using Homework.Shared.Base;

namespace Homework.Data.Repositories.RecordRepository.Models
{
	public class AddRecordRequest : RequestBase
	{
		public string DelimitedValues { get; set; }
		public string Path { get; set; }

	}
}