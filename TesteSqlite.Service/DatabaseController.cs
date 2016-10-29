using TesteSqlite.Entity;
using TesteSqlite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSqlite.LocalService
{
    public class DatabaseController
    {
        public TipoBancoDados RetornaTipoBancoDados()
        {
            return new DatabaseRepository().RetornaTipoBancoDados();
        }

        public string RetornaConnectionString()
        {
            return new DatabaseRepository().RetornaConnectionString();
        }
    }
}
