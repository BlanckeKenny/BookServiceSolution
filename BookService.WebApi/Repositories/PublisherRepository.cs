using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.WebApi.Repositories
{
    public class PublisherRepository
    {
        private BookServiceContext _context;

        public PublisherRepository(BookServiceContext context)
        {
            _context = context;
        }

        public List<Publisher> List()
        {
            return _context.Publishers.ToList();
        }

        public List<Publisher> GetById(int id)
        {
            return _context.Publishers.Where(a => a.Id == id).ToList();
        }

        public async Task<Publisher> Update(Publisher publisher)
        {
            try
            {
                _context.Entry(publisher).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublisherExist(publisher.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return publisher;
        }

        public async Task<Publisher> Add(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }


        public async Task<Publisher> Delete(int id)
        {
            var publisher = await _context.Publishers.FindAsync(id);
            if (publisher == null)
            {
                return null;
            }
            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
            return publisher;
        }







        private bool PublisherExist(int id)
        {
            return _context.Publishers.Any(p => p.Id == id);
        }
    }
}
