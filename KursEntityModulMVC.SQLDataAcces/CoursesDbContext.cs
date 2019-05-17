using KursEntityModulMVC.SQLDataAcces.Entities;
using KursEntityModulMVC.SQLDataAcces.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursEntityModulMVC.SQLDataAcces
{
    public class CoursesDbContext:DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Status> Genres { get; set; }
        public virtual DbSet<Genre> Statuses { get; set; }


        public CoursesDbContext()
           : base("DbConnection")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            BookMap.Map(modelBuilder.Entity<Book>());
            AuthorMap.Map(modelBuilder.Entity<Author>());
            GenreMap.Map(modelBuilder.Entity<Genre>());
            StatusMap.Map(modelBuilder.Entity<Status>());
        }

       
    }
}
