using AutoMapper;
using BookService.WebApi.DTO;
using BookService.WebApi.Models;

namespace BookService.WebApi.Services.AutoMapper
{
        public class AutoMapperProfileConfiguration : Profile
        {
            public AutoMapperProfileConfiguration() : this("MyProfile")
            {
            }

            protected AutoMapperProfileConfiguration(string profileName): base(profileName)
            {
                CreateMap<BookBasic, Book>();
                CreateMap<Book, BookDetail>()
                    .ForMember(
                        dest => dest.AuthorName,
                        from => from.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));
            }
        }
    }
