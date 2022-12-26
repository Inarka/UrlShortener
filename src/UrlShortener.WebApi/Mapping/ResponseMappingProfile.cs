using AutoMapper;
using UrlShortener.Core.Models.Entities;
using UrlShortener.WebApi.Models;

namespace UrlShortener.WebApi.Mapping
{
	public class ResponseMappingProfile : Profile
	{
		public ResponseMappingProfile()
		{
			CreateMap<UrlEntity, GenerateShortUrlResponse>();
		}
	}
}
