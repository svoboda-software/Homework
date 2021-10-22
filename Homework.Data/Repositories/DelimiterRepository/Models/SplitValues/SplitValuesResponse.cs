using Homework.Shared.Base;

namespace Homework.Data.Repositories.DelimiterRepository.Models
{
	public class SplitValuesResponse : ResponseBase
	{
		public string[] Values { get; set; }
	}
}