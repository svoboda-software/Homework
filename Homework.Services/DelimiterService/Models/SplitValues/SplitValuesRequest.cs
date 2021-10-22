using Homework.Shared.Base;

namespace Homework.Services.DelimiterService.Models
{
	public class SplitValuesRequest : RequestBase
	{
		public string DelimitedValues { get; set; }
	}
}