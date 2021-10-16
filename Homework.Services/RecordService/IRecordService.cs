using Homework.Services.RecordService.Models;
namespace Homework.Services.RecordService
{
	public interface IRecordService
	{
		GetRecordsResponse GetRecords(GetRecordsRequest request);
		QueryRecordsResponse QueryRecords(QueryRecordsRequest request);
	}
}