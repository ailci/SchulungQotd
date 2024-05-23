using AutoMapper;
using SchulungMvc.Common.ViewModels;
using SchulungQotd.Domain;

namespace SchulungQotd.Mvc.Profiles
{
    public class QotdProfile : Profile
    {
        public QotdProfile()
        {
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Quote, QuoteViewModel>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));

            CreateMap<Quote, QuoteOfTheDayViewModel>()
                .ForMember(dest => dest.AuthorImage, opt => opt.MapFrom(src => src.Author.Photo))
                .ForMember(dest => dest.AuthorImageMimeType, opt => opt.MapFrom(src => src.Author.PhotoMimeType));
        }
    }
}
