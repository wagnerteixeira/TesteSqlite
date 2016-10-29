using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSqlite.Entity
{
    public class Tarefa : BaseClass
    {
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public bool Status { get; set; }
        public string LogExecucao { get; set; }
    }
}
