using Homework.Shared.Base;

namespace Homework.Services.RecordService.Models
{
	public class AddRecordResponse : ResponseBase
	{
		public Record Record { get; set; }
	}
}