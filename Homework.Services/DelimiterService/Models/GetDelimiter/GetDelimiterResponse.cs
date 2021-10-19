using Homework.Shared.Base;

namespace Homework.Services.DelimiterService.Models
{
	public class GetDelimiterResponse : ResponseBase
	{
		public char Delimiter { get; set; }
	}
}