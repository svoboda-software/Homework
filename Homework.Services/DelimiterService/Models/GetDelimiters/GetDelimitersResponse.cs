using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Services.DelimiterService.Models
{
	public class GetDelimitersResponse : ResponseBase
	{
		public List<Delimiter> Delimiters { get; set; }
	}
}