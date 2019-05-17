using KursEntityModulMVC.SQLDataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursEntityModulMVC.SQLDataAcces.Mapping
{
    public class StatusMap
    {
        public static void Map(EntityTypeConfiguration<Status> config)
        {
            config.HasKey(m => m.Id);
            config.Property(m => m.Title).HasMaxLength(20).HasColumnType("varchar").HasColumnName("Title").IsRequired();

            config.HasMany(m => m.Books);
        }
    }
}
