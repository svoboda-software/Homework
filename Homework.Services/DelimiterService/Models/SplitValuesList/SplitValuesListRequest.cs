using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Services.DelimiterService.Models
{
	public class SplitValuesListRequest : RequestBase
	{
		public List<string> DelimitedValuesList { get; set; }
	}
}