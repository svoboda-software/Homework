using Homework.Data.Repositories.RecordRepository.Models;

namespace Homework.Data.Repositories.RecordRepository
{
	public interface IRecordRepository
	{
		GetRecordsResponse GetRecords(GetRecordsRequest request);
	}
}