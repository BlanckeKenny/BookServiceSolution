using AutoMapper;
using BookService.WebApi.Models;

namespace BookService.WebApi.Repositories.Base
{
    public class MappingRepository<T> : Repository<T> where T : EntityBase
    {
        protected IMapper Mapper;

        public MappingRepository(BookServiceContext context, IMapper mapper): base(context)
        {
            Mapper = mapper;
        }
    }
}
