using Homework.Shared.Base;

namespace Homework.Services.DelimiterService.Models
{
	public class GetDelimiterRequest : RequestBase
	{
		public string DelimitedValues { get; set; }
	}
}