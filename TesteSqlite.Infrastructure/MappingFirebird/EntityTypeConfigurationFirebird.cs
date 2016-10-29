using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace TesteSqlite.Infrastructure.Mapping
{
    public class EntityTypeConfigurationFirebird<TEntityType> : EntityTypeConfiguration<TEntityType> where TEntityType : class
    {

    }
}
