using AutoMapper;
using UrlShortener.Core.Models.Entities;
using UrlShortener.WebApi.Models;

namespace UrlShortener.WebApi.Mapping
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public class ResponseMappingProfile : Profile
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
		public ResponseMappingProfile()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
		{
			CreateMap<UrlEntity, GenerateShortUrlResponse>()
				.ForMember(dest => dest.ShortUrl, opt => opt.MapFrom((src, dest, destMember, context) 
													  => context.Items["BaseShortUrl"] + dest.Token));
		}
	}
}
