using Homework.Shared.Base;

namespace Homework.Data.Repositories.FileRepository.Models
{
	public class GetPathRequest : RequestBase
	{
		public string DelimiterName { get; set; }
	}
}