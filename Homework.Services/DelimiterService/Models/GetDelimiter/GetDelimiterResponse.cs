using Homework.Shared.Base;

namespace Homework.Services.DelimiterService.Models
{
	public class GetDelimiterResponse : ResponseBase
	{
		public Delimiter Delimiter { get; set; }
	}
}