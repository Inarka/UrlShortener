using AutoMapper;
using UrlShortener.Core.Models.Entities;
using UrlShortener.WebApi.Models;

namespace UrlShortener.WebApi.Mapping
{
	public class ResponseMappingProfile : Profile
	{
		public ResponseMappingProfile()
		{
			CreateMap<UrlEntity, GenerateShortUrlResponse>()
				.ForMember(dest => dest.ShortUrl, opt => opt.MapFrom((src, dest, destMember, context) => context.Items["BaseShortUrl"] + dest.Token));
		}
	}
}
