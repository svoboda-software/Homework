using Homework.Services.DelimiterService.Models;

namespace Homework.Services.DelimiterService
{
	public interface IDelimiterService
	{
		GetDelimiterResponse GetDelimiter(GetDelimiterRequest request);
		GetDelimitersResponse GetDelimiters(GetDelimitersRequest request);
		SplitValuesResponse SplitValues(SplitValuesRequest request);
	}
}