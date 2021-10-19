using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Services.DelimiterService.Models
{
	public class SplitValuesRequest : RequestBase
	{
		public List<string> DelimitedValues { get; set; }
	}
}