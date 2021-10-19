using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Data.Repositories.DelimiterRepository.Models
{
	public class SplitValuesResponse : ResponseBase
	{
		public List<string[]> ValueArrays { get; set; }
	}
}