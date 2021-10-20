using Homework.Services.RecordService.Models;
namespace Homework.Services.RecordService
{
	public interface IRecordService
	{
		GetRecordsResponse GetRecords(GetRecordsRequest request);
		QueryPropertyResponse QueryProperty(QueryPropertyRequest request);
		QueryRecordsResponse QueryRecords(QueryRecordsRequest request);
	}
}