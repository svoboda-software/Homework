using Homework.Shared.Base;

namespace Homework.Data.Repositories.DelimiterRepository.Models
{
	public class SplitValuesRequest : RequestBase
	{
		public string DelimitedValues { get; set; }
	}
}