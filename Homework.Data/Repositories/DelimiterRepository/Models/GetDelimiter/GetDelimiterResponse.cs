using Homework.Shared.Base;

namespace Homework.Data.Repositories.DelimiterRepository.Models
{
	public class GetDelimiterResponse : ResponseBase
	{
		public Delimiter Delimiter { get; set; }
	}
}