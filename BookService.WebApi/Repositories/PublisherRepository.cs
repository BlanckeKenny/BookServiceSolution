using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookService.WebApi.DTO;
using BookService.WebApi.Models;
using BookService.WebApi.Repositories.Base;
using Microsoft.EntityFrameworkCore;


namespace BookService.WebApi.Repositories
{
    public class PublisherRepository : MappingRepository<Publisher>
    {

        public PublisherRepository(BookServiceContext context, IMapper mapper) : base (context, mapper)
        {
            
        }

        public async Task<List<PublisherBasic>> ListBasic()
        {
            return await Db.Publishers
                .ProjectTo<PublisherBasic>(Mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
