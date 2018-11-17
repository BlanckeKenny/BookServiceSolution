using System.Linq;
using AutoMapper;
using BookServiceLib.DTO;
using BookServiceLib.Models;

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
                CreateMap<Book, BookStatistics>()
                    .ForMember(
                        dest => dest.RatingCount,
                        from => from.MapFrom(src => src.Ratings.Count))
                    .ForMember(
                        dest => dest.ScoreAverage,
                        from => from.MapFrom(src => src.Ratings.Average(a => a.Score)));
            }
        }
    }
