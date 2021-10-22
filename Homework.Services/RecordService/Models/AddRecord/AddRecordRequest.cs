using Homework.Shared.Base;

namespace Homework.Services.RecordService.Models
{
	public class AddRecordRequest : RequestBase
	{
		public string DelimitedValues { get; set; }
	}
}