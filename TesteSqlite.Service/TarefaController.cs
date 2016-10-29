using TesteSqlite.Entity;
using TesteSqlite.Infrastructure;
using TesteSqlite.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteSqlite.LocalService
{
    public class TarefaController
    {
        private string _mensagem = "";

        public List<Tarefa> SelecionarTodos()
        {
            return new TarefaRepository().SelecionarTodos().ToList();
        }

        public Tarefa Selecionar(int id)
        {
            return new TarefaRepository().Selecionar(id);
        }

        public string Excluir(Tarefa entity)
        {
            TesteSqliteContext contexto = new TesteSqliteContext();
            using (DbContextTransaction transacao = TesteSqliteTransaction.CreateDbContextTransaction(contexto))
            {
                _mensagem = new TarefaRepository(contexto).Excluir(entity);

                if (_mensagem == "")
                    transacao.Commit();
                else
                    transacao.Rollback();
            }
            return _mensagem;
        }

        public string Salvar(Tarefa entity)
        {
            TesteSqliteContext contexto = new TesteSqliteContext();
            using (DbContextTransaction transacao = TesteSqliteTransaction.CreateDbContextTransaction(contexto))
            {
                if (entity.Id == 0)
                    _mensagem = new TarefaRepository(contexto).Incluir(entity);
                else
                    _mensagem = new TarefaRepository(contexto).Alterar(entity);

                if (_mensagem == "")
                    transacao.Commit();
                else
                    transacao.Rollback();
            }
            return _mensagem;
        }
    }
}
