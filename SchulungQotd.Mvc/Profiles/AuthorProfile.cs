using AutoMapper;
using SchulungQotd.Domain;
using SchulungQotd.Service.Models;
using SchulungQotd.Service.Utilities;

namespace SchulungQotd.Mvc.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorViewModel>();

            CreateMap<AuthorCreateViewModel, Author>()
                .ForMember(
                    dest => dest.Photo,
                    opt =>
                    {
                        opt.PreCondition(c => c.Photo is not null);
                        opt.MapFrom(src => Util.GetFile(src.Photo).Result.fileContent);
                    })
                .ForMember(
                    dest => dest.PhotoMimeType,
                    opt =>
                    {
                        opt.PreCondition(c => c.Photo is not null);
                        opt.MapFrom(src => src.Photo.ContentType);
                    });
        }
    }
}
