using AutoMapper;
using SchulungQotd.Domain;
using SchulungQotd.Service.Models;

namespace SchulungQotd.Mvc.Profiles
{
    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            CreateMap<Quote, QuoteOfTheDayViewModel>()
                .ForMember(c => c.AuthorImage, opt => opt.MapFrom(src => src.Author.Photo))
                .ForMember(c => c.AuthorImageMimeType, opt => opt.MapFrom(src => src.Author.PhotoMimeType));
        }
    }
}
