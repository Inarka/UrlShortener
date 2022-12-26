using System;
using UrlShortener.Core.Interfaces.Helpers;

namespace UrlShortener.Core.Services.Helpers.Validators
{
	internal class UriHelper : IUriHelper
	{
		public bool TryCreateValidUrl(string input, out string url)
		{
			url = new UriBuilder(input).Uri.ToString().ToLower();

			return Uri.IsWellFormedUriString(url, UriKind.Absolute);
		}
	}
}
