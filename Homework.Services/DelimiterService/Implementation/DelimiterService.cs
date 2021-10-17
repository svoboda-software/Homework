using Homework.Data.Repositories.DelimiterRepository;
using FromRepo = Homework.Data.Repositories.DelimiterRepository.Models;
using Homework.Services.DelimiterService.Models;

namespace Homework.Services.DelimiterService.Implementation
{
	public class DelimiterService : IDelimiterService
	{
		private IDelimiterRepository repo { get; }

		public DelimiterService(IDelimiterRepository repo) { this.repo = repo; }

		public GetDelimitersResponse GetDelimiters(GetDelimitersRequest request)
		{
			var delimiters = repo.GetDelimiters(new FromRepo.GetDelimitersRequest())?.Delimiters;

			return new GetDelimitersResponse
			{
				Success = delimiters != null,
				Delimiters = delimiters
			};
		}
	}
}