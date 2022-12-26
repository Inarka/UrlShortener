using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Services.Helpers;
using Xunit;

namespace UrlShortener.Infrastructure.UnitTests.Services.Helpers
{
	public class Base62EncoderTests
	{
		[Theory]
		[InlineData(100, "1c")]
		[InlineData(999999, "4C91")]
		public void Encode_ifInputIsGiven_ShoulReturnCorrectlyEncodedString(int input, string excepted)
		{
			//Act
			var result = Base62Encoder.Encode(input);

			//Assert
			Assert.Equal(excepted, result);	
		}
	}
}
