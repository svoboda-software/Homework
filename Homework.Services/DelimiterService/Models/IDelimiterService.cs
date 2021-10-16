using Homework.Services.DelimiterService.Models;

namespace Homework.Services.DelimiterService
{
	public interface IDelimiterService
	{
		GetDelimitersResponse GetDelimiters(GetDelimitersRequest request);
	}
}