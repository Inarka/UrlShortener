using UrlShortener.Core.Interfaces.Helpers;

namespace UrlShortener.Core.Services.Helpers.Validators
{
	internal class UriHelper : IUriHelper
	{
		public bool TryCreateValidUrl(string input, out string url)
		{
			url = new UriBuilder(input).Uri.ToString();

			var created = Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out var uri);

			if (created)
			{
				url = uri.ToString();
			}

			return created;
		}
	}
}
