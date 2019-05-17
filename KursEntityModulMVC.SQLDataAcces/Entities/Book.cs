using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursEntityModulMVC.SQLDataAcces.Entities
{
    public class Book
    {
        CoursesDbContext context = new CoursesDbContext();
        public Book()
        {
            Authors = context.Authors.ToList();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }

        public Genre Genre { get; set; }
        public int GenreId { get; set; }
      

        public int Year { get; set; }
        public int CountOfPage { get; set; }
        public int Bookmark { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public string Description { get; set; }
        public string Info { get; set; }

        [NotMapped]
        public ICollection<Author> Authors { get; set; }

    }
}
