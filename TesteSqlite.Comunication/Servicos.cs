using TesteSqlite.LocalService;
using TesteSqlite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSqlite.Comunication
{
    public static class Servicos
    {
        public static TarefaController tarefaServico = new TarefaController();
        public static DatabaseController databaseServico = new DatabaseController();
    }
}
