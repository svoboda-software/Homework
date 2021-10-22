using Homework.Data.Repositories.RecordRepository.Models;

namespace Homework.Data.Repositories.RecordRepository
{
	public interface IRecordRepository
	{
		GetRecordResponse GetRecord(GetRecordRequest request);
		GetRecordsResponse GetRecords(GetRecordsRequest request);
		QueryRecordsResponse QueryRecords(QueryRecordsRequest request);
	}
}