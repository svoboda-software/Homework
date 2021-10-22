using Homework.Shared.Base;

namespace Homework.Services.DelimiterService.Models
{
	public class SplitValuesResponse : ResponseBase
	{
		public string[] Values { get; set; }
	}
}