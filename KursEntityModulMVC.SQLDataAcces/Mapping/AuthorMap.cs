using KursEntityModulMVC.SQLDataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursEntityModulMVC.SQLDataAcces.Mapping
{
   public class AuthorMap
    {
        public static void Map(EntityTypeConfiguration<Author> config)
        {
            config.HasKey(m => m.Id);
            config.Property(m => m.Name).HasMaxLength(20).HasColumnType("varchar").HasColumnName("AuthorName").IsRequired();
            
            config.HasMany(m => m.Books);
        }
    }
}
