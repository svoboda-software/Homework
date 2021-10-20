using Homework.Shared.Base;

namespace Homework.Services.RecordService.Models
{
	public class QueryPropertyRequest : RequestBase
	{
		public string PropertyName { get; set; }
	}
}