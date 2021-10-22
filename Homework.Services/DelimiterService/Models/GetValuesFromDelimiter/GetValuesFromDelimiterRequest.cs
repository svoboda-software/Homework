using Homework.Shared.Base;

namespace Homework.Services.DelimiterService.Models
{
	public class GetValuesFromDelimiterRequest : RequestBase
	{
		public string DelimitedValues { get; set; }
	}
}