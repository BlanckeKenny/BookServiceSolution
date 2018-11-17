using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebApi.DTO;
using BookService.WebApi.Models;
using BookService.WebApi.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BookService.WebApi.Repositories
{
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(BookServiceContext context) : base(context)
        {
           
        }

        public async Task<List<AuthorBasic>> ListBasic()
        {
            return await Db.Authors.Select(A => new AuthorBasic
            {
                Id = A.Id,
                Name = $"{A.FirstName} {A.LastName}"
            }).ToListAsync();
        }
    }
}
