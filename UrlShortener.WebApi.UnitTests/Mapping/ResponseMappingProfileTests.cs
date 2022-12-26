using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Models.Entities;
using UrlShortener.WebApi.Models;
using Xunit;

namespace UrlShortener.WebApi.UnitTests.Mapping
{
	public class ResponseMappingProfileTests
	{
		[Fact]
		public void ResponseMappingProfileConfiguration_IsValid()
		{
			var configuration = new MapperConfiguration(cfg =>  cfg.CreateMap<UrlEntity, GenerateShortUrlResponse>());

			configuration.AssertConfigurationIsValid();
		}
	}
}
