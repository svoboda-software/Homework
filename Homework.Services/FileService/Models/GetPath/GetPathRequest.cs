using Homework.Shared.Base;

namespace Homework.Services.FileService.Models
{
	public class GetPathRequest : RequestBase
	{
		public string DelimiterName { get; set; }
	}
}