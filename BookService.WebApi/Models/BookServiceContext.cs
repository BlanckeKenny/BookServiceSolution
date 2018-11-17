using System;
using BookServiceLib.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.WebApi.Models
{
    public class BookServiceContext : DbContext
    {
        public BookServiceContext(DbContextOptions<BookServiceContext> options) 
        :base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reader>()
                .ToTable("Reader")
                .HasData(
                    new Reader
                    {
                        Id = 1,
                        FirstName = "trol",
                        LastName = "brol",
                    },
                    new Reader
                    {
                        Id = 2,
                        FirstName = "Kenny",
                        LastName = "blancke"
                    },
                    new Reader
                    {
                        Id = 3,
                        FirstName = "Jolande",
                        LastName = "Minne",
                    },
                    new Reader
                    {
                        Id = 4,
                        FirstName = "Luka",
                        LastName = "Blancke"
                    },
                    new Reader
                    {
                        Id = 5,
                        FirstName = "Louis",
                        LastName = "Blancke"
                    }
                    );
            modelBuilder.Entity<Rating>()
                .ToTable("Rating")
                .HasData(
                    new Rating {Id = 1, ReaderId = 1, BookId = 1, Score = 5},
                    new Rating {Id = 2, ReaderId = 1, BookId = 2, Score = 1},
                    new Rating {Id = 3, ReaderId = 2, BookId = 2, Score = 3},
                    new Rating {Id = 4, ReaderId = 3, BookId = 1, Score = 5},
                    new Rating {Id = 5, ReaderId = 3, BookId = 3, Score = 5},
                    new Rating {Id = 6, ReaderId = 2, BookId = 3, Score = 5},
                    new Rating {Id = 7, ReaderId = 2, BookId = 2, Score = 5},
                    new Rating {Id = 8, ReaderId = 1, BookId = 1, Score = 5}
                );
                    



           modelBuilder.Entity<Publisher>()
                .ToTable("Publisher")
                .HasData(
                    new Publisher
                    {
                        Country = "UK",
                        Id = 1,
                        Name = "IT-Publishers"
                    },
                    new Publisher
                    {
                        Id = 2,
                        Name = "FoodBooks",
                        Country = "Sweden"
                    }
                );
            modelBuilder.Entity<Author>()
                .ToTable("Author")
                .HasData(
                    new Author
                    {
                        Id = 1,
                        FirstName = "James",
                        LastName = "Sharp",
                        BirthDate = new DateTime(1980, 5, 20)
                    },
                    new Author
                    {
                        Id = 2,
                        FirstName = "Sophie",
                        LastName = "Netty",
                        BirthDate = new DateTime(1992, 3, 4)
                    },
                    new Author
                    {
                        Id = 3,
                        FirstName = "Elisa",
                        LastName = "Yammy",
                        BirthDate = new DateTime(1996, 8, 12)
                    });
            modelBuilder.Entity<Book>()
                .ToTable("Book")
                .HasData(
                    new
                    {
                        Id = 1,
                        ISBN = "123456789",
                        Title = "Learning C#",
                        NumberOfPages = 420,
                        FileName = "book1.jpg",
                        AuthorId = 1,
                        PublisherId = 1,
                        Price = 22.15M,
                        Year = 2010,
                        
                        
                    },
                    new
                    {
                        Id = 2,
                        ISBN = "45689132",
                        Title = "Mastering Linq",
                        NumberOfPages = 360,
                        FileName = "book2.jpg",
                        AuthorId = 2,
                        PublisherId = 1,
                        Price = 29.15M,
                        Year = 2001
                    },
                    new
                    {
                        Id = 3,
                        ISBN = "15856135",
                        Title = "Mastering Xamarin",
                        NumberOfPages = 360,
                        FileName = "book3.jpg",
                        AuthorId = 1,
                        PublisherId = 1,
                        Price = 15.15M,
                        Year = 2005
                    },
                    new
                    {
                        Id = 4,
                        ISBN = "56789564",
                        Title = "Exploring ASP.Net Core 2.0",
                        NumberOfPages = 360,
                        FileName = "book1.jpg",
                        AuthorId = 2,
                        PublisherId = 1,
                        Price = 30.15M,
                        Year = 2018
                    },
                    new
                    {
                        Id = 5,
                        ISBN = "234546684",
                        Title = "Unity Game Development",
                        NumberOfPages = 420,
                        FileName = "book2.jpg",
                        AuthorId = 2,
                        PublisherId = 1,
                        Price = 28.15M,
                        Year = 2015
                    },
                    new
                    {
                        Id = 6,
                        ISBN = "789456258",
                        Title = "Cooking is fun",
                        NumberOfPages = 40,
                        FileName = "book3.jpg",
                        AuthorId = 3,
                        PublisherId = 2,
                        Price = 15M,
                        Year = 2005
                    },
                    new
                    {
                        Id = 7,
                        ISBN = "94521546",
                        Title = "Secret recipes",
                        NumberOfPages = 53,
                        FileName = "book3.jpg",
                        AuthorId = 3,
                        PublisherId = 2,
                        Price = 18M,
                        Year = 2010
                    });
            modelBuilder.Entity<Reader>()
                .Property(r => r.Created)
                .HasDefaultValueSql("GetDate()")
                .ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Rating>()
                .Property(r => r.Created)
                .HasDefaultValueSql("GetDate()")
                .ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Book>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Publisher>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<Author>()
                .Property(p => p.Created)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();
        }


        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }  
        public DbSet<Rating> Ratings { get; set; }  
        public DbSet<Reader> Readers { get; set; }  
    }
}
