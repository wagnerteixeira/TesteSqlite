using TesteSqlite.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace TesteSqlite.Infrastructure.Mapping
{
    public class TarefaMappingFirebird : EntityTypeConfiguration<Tarefa>
    {
        public TarefaMappingFirebird()
        {
            HasKey(c => c.Id).Property(c => c.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
