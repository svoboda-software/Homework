using Homework.Services.DelimiterService.Models;

namespace Homework.Services.DelimiterService
{
	public interface IDelimiterService
	{
		GetDelimitedValuesResponse GetDelimitedValues(GetDelimitedValuesRequest request);
		GetDelimiterResponse GetDelimiter(GetDelimiterRequest request);
		GetDelimitersResponse GetDelimiters(GetDelimitersRequest request);
	}
}