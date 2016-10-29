using TesteSqlite.Entity;
using TesteSqlite.Infrastructure.Mapping;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

namespace TesteSqlite.Infrastructure
{
    public class TesteSqliteContext : DbContext
    {
        public TesteSqliteContext()
            : base("TesteSqliteConnectionString")
        {          

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            IEnumerable<Type> typesToRegister = null;

            if (Database.Connection is System.Data.SqlClient.SqlConnection)
            {
                Database.SetInitializer<TesteSqliteContext>(new TesteSqliteInitializer());

            }
            else if (Database.Connection is System.Data.SQLite.SQLiteConnection)
            {
                Database.SetInitializer<TesteSqliteContext>(new SqliteCreateDatabaseIfNotExists<TesteSqliteContext>(modelBuilder));
                typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                            .Where(type => !String.IsNullOrEmpty(type.Namespace))
                            .Where(type => type.Name.Contains(GetMappingDatabase(Database.Connection)))
                            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfigurationSqlite<>));
            }
            else if (Database.Connection is FirebirdSql.Data.FirebirdClient.FbConnection)
            {
                Database.SetInitializer<TesteSqliteContext>(null);
                typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                            .Where(type => !String.IsNullOrEmpty(type.Namespace))
                            .Where(type => type.Name.Contains(GetMappingDatabase(Database.Connection)))
                            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfigurationFirebird<>));
            }

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        private string GetMappingDatabase(System.Data.Common.DbConnection connection)
        {
            if (Database.Connection is System.Data.SqlClient.SqlConnection)
                return "MsSql";
            else if (Database.Connection is FirebirdSql.Data.FirebirdClient.FbConnection)
                return "Firebird";
            else
                return "";
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
