using Homework.Services.FileService.Models;

namespace Homework.Services.FileService
{
	public interface IFileService
	{
		GetFilesResponse GetFiles(GetFilesRequest request);
	}
}