using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Data.Repositories.DelimiterRepository.Models
{
	public class SplitValuesListRequest : RequestBase
	{
		public List<string> DelimitedValuesList { get; set; }
	}
}