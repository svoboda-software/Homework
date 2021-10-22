using Homework.Services.RecordService.Models;
namespace Homework.Services.RecordService
{
	public interface IRecordService
	{
		AddRecordResponse AddRecord(AddRecordRequest request);
		GetRecordsResponse GetRecords(GetRecordsRequest request);
		QueryPropertyResponse QueryProperty(QueryPropertyRequest request);
		QueryRecordsResponse QueryRecords(QueryRecordsRequest request);
	}
}