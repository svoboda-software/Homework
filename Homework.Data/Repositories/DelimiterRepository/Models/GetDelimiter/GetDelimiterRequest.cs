using Homework.Shared.Base;

namespace Homework.Data.Repositories.DelimiterRepository.Models
{
	public class GetDelimiterRequest : RequestBase
	{
		public string DelimitedValues { get; set; }
	}
}