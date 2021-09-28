namespace Homework.Parser
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				var parser = new Parser();
				parser.Parse();
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
		}
	}
}