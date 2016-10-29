using TesteSqlite.Entity;
using TesteSqlite.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSqlite.Repository
{
    public class DatabaseRepository
    {
        private TesteSqliteContext _db = null;

        public DatabaseRepository(TesteSqliteContext context = null)
        {
            _db = context == null ? new TesteSqliteContext() : context;
            
        }

        public string RetornaConnectionString()
        {
            return _db.Database.Connection.ConnectionString;
        }

        public TipoBancoDados RetornaTipoBancoDados()
        {
            if (_db.Database.Connection is System.Data.SqlClient.SqlConnection)
            {
                return TipoBancoDados.SqlServer;
            }
            else if (_db.Database.Connection is FirebirdSql.Data.FirebirdClient.FbConnection)
            {
                return TipoBancoDados.Firebird;
            }
            else if (_db.Database.Connection is System.Data.SQLite.SQLiteConnection)
            {
                return TipoBancoDados.Sqlite;
            }
            else
            {
                return TipoBancoDados.Indefinido;
            }
        }



    }
}
