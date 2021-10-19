using Homework.Data.Repositories.DelimiterRepository.Models;

namespace Homework.Data.Repositories.DelimiterRepository
{

	public interface IDelimiterRepository
	{
		GetDelimiterResponse GetDelimiter(GetDelimiterRequest request);
		GetDelimitersResponse GetDelimiters(GetDelimitersRequest request);
	}
}