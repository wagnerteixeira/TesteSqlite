using TesteSqlite.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace TesteSqlite.Infrastructure.Mapping
{
    public class TarefaMappingSqlite : EntityTypeConfigurationSqlite<Tarefa>
    {
        public TarefaMappingSqlite()
        {
            HasKey(c => c.Id).Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Descricao);
            Property(c => c.Ativo);
            Property(c => c.Status);
        }
    }
}
