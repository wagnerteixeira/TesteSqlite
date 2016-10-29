using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace TesteSqlite.Infrastructure
{
    public class TesteSqliteInitializer : CreateDatabaseIfNotExists<TesteSqliteContext>
    {
        protected override void Seed(TesteSqliteContext context)
        {
            base.Seed(context);
        }
    }
}
