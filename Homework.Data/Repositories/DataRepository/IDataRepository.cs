namespace Homework.Repositories.DataRepository
{
	public interface IDataRepository
	{
		GetDataResponse GetData(GetDataRequest request);
	}
}