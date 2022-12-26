using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Core.Interfaces.Helpers
{
	public interface IUriHelper
	{
		public bool TryCreateValidUrl(string input, out string url);
	}
}
