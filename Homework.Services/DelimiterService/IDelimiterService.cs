using Homework.Services.DelimiterService.Models;

namespace Homework.Services.DelimiterService
{
	public interface IDelimiterService
	{
		GetValuesFromAllDelimitersResponse GetValuesFromAllDelimiters(GetValuesFromAllDelimitersRequest request);
		GetValuesFromDelimiterResponse GetValuesFromDelimiter(GetValuesFromDelimiterRequest request);
		GetDelimiterResponse GetDelimiter(GetDelimiterRequest request);
		GetDelimitersResponse GetDelimiters(GetDelimitersRequest request);
	}
}