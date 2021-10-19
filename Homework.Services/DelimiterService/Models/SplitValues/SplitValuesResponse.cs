using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Services.DelimiterService.Models
{
	public class SplitValuesResponse : ResponseBase
	{
		public List<string[]> ValueArrays { get; set; }
	}
}