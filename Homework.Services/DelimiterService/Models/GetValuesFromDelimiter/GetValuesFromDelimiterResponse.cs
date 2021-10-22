using Homework.Shared.Base;

namespace Homework.Services.DelimiterService.Models
{
	public class GetValuesFromDelimiterResponse : ResponseBase
	{
		public string[] Values { get; set; }
	}
}