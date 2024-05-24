using AutoMapper;
using SchulungMvc.Common.Utilities;
using SchulungMvc.Common.ViewModels;
using SchulungQotd.Domain;

namespace SchulungQotd.Mvc.Profiles
{
    public class QotdProfile : Profile
    {
        public QotdProfile()
        {
            CreateMap<Author, AuthorViewModel>();
            CreateMap<AuthorCreateViewModel, Author>()
                .ForMember(
                    dest => dest.Photo,
                    opt =>
                    {
                        opt.PreCondition(c => c.Photo != null);
                        opt.MapFrom(src => Util.GetFile(src.Photo).Result.fileContent);
                    })
                .ForMember(
                    dest => dest.PhotoMimeType,
                    opt =>
                    {
                        opt.PreCondition(c => c.Photo != null);
                        opt.MapFrom(src => src.Photo.ContentType);
                    });


            CreateMap<Quote, QuoteViewModel>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));

            CreateMap<Quote, QuoteOfTheDayViewModel>()
                .ForMember(dest => dest.AuthorImage, opt => opt.MapFrom(src => src.Author.Photo))
                .ForMember(dest => dest.AuthorImageMimeType, opt => opt.MapFrom(src => src.Author.PhotoMimeType));
        }
    }
}
