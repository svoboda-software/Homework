using Homework.Data.Repositories.DelimiterRepository.Models;

namespace Homework.Data.Repositories.DelimiterRepository
{

	public interface IDelimiterRepository
	{
		GetDelimitersResponse GetDelimiters(GetDelimitersRequest request);
	}
}