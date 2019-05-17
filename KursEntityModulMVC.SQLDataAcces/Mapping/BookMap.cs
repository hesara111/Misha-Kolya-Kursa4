using KursEntityModulMVC.SQLDataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursEntityModulMVC.SQLDataAcces.Mapping
{
    public static class BookMap
    {
            public static void Map(EntityTypeConfiguration<Book> config)
            {
                config.HasKey(m => m.Id);
                config.Property(m => m.Title).HasMaxLength(20).HasColumnType("varchar").HasColumnName("BookTitle").IsRequired();
                config.Property(m => m.Year).HasColumnType("int").HasColumnName("YearOfRelease").IsRequired();
                config.Property(m => m.Title).HasMaxLength(20).HasColumnType("varchar").HasColumnName("BookTitle").IsRequired();
            
                config.Property(m => m.CountOfPage).HasColumnType("int").HasColumnName("CountOfPages").IsRequired();
                config.Property(m => m.Bookmark).HasColumnType("int").HasColumnName("BookMark").IsRequired();
                config.Property(m => m.Info).HasMaxLength(20).HasColumnType("varchar").HasColumnName("BookInfo");
                config.Property(m => m.Info).HasMaxLength(20).HasColumnType("varchar").HasColumnName("BookInfo");
                //config.HasMany(m => m.Authors);
            }
        }
}
