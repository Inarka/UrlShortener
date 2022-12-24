namespace UrlShortener.Core.Interfaces.Data
{
	public interface ITokenRepository
	{
		public Task<int> GetCounterValue();
	}
}
