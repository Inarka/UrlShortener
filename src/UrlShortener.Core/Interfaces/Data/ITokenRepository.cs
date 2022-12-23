using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Core.Interfaces.Data
{
	public interface ITokenRepository
	{
		Task<int> GetCounterValue();
	}
}
