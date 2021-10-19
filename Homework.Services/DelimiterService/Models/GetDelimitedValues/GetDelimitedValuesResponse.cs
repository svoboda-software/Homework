using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Services.DelimiterService.Models
{
	public class GetDelimitedValuesResponse : ResponseBase
	{
		public List<string[]> Values { get; set; }
	}
}