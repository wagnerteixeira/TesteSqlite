using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSqlite.Infrastructure
{
    public class TesteSqliteTransaction
    {
        private TesteSqliteTransaction()
        {

        }

        public static DbContextTransaction CreateDbContextTransaction(TesteSqliteContext db)
        {
            if (db.Database.Connection is System.Data.SQLite.SQLiteConnection)
                return db.Database.BeginTransaction();
            else
                return db.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
        }
    }
}
