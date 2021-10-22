using Homework.Shared.Base;

namespace Homework.Services.FileService.Models
{
	public class GetPathResponse : ResponseBase
	{
		public string FilePath { get; set; }
	}
}