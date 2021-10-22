using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Data.Repositories.DelimiterRepository.Models
{
	public class SplitValuesListResponse : ResponseBase
	{
		public List<string[]> ValuesList { get; set; }
	}
}