namespace Homework.Parser
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Parser.Parse();
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
		}
	}
}