using Homework.Data.Repositories.DelimiterRepository;
using FromRepo = Homework.Data.Repositories.DelimiterRepository.Models;
using Homework.Services.DelimiterService.Models;
using System.Collections.Generic;
using System.Linq;

namespace Homework.Services.DelimiterService.Implementation
{
	public class DelimiterService : IDelimiterService
	{
		private IDelimiterRepository repo { get; }

		public DelimiterService(IDelimiterRepository repo)
		{
			this.repo = repo;
		}

		public GetDelimitersResponse GetDelimiters(GetDelimitersRequest request)
		{
			var delimiters = repo.GetDelimiters(new FromRepo.GetDelimitersRequest())?
				.Delimiters?
				.Select(s => new Delimiter { Symbol = s.Symbol, Name = s.Name })
				.ToList();

			return new GetDelimitersResponse
			{
				Success = delimiters != null,
				Delimiters = delimiters
			};
		}
	}
}