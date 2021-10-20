using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Data.Repositories.DelimiterRepository.Models
{
	public class SplitValuesRequest : RequestBase
	{
		public List<string> DelimitedValues { get; set; }
	}
}