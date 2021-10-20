using Homework.Shared.Base;
using System.Collections.Generic;

namespace Homework.Data.Repositories.DelimiterRepository.Models
{
	public class GetDelimitersResponse : ResponseBase
	{
		public List<Delimiter> Delimiters { get; set; }
	}
}