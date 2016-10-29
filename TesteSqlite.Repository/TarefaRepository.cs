using TesteSqlite.Entity;
using TesteSqlite.Infrastructure;
using TesteSqlite.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSqlite.Repository
{
    public class TarefaRepository : IPadraoRepository<Tarefa>, IBaseRepository<Tarefa>
    {
        private TesteSqliteContext _db = new TesteSqliteContext();
        private IRepository<Tarefa> _repository;

        public TarefaRepository(TesteSqliteContext context = null)
        {
            _repository = new Repository<Tarefa>(context == null ? new TesteSqliteContext() : context);
        }

        public string Incluir(Tarefa entity)
        {
            string mensagem = this.ValidarDados(entity);
            if (mensagem == "")
            {
                mensagem = _repository.Insert(entity);
            }
            return mensagem;
        }

        public string Alterar(Tarefa entity)
        {
            string mensagem = this.ValidarDados(entity);
            if (mensagem == "")
            {
                mensagem = _repository.Update(entity);
            }
            return mensagem;
        }

        public string Excluir(Tarefa entity)
        {
            string mensagem = this.ValidarExclusao(entity);
            if (mensagem == "")
            {
                mensagem = _repository.Delete(entity);
            }
            return mensagem;
        }

        public Tarefa Selecionar(int id)
        {
            return _repository.GetById(id);
        }

        public IQueryable<Tarefa> SelecionarTodos()
        {
            return _repository.GetAll();
        }

        public IQueryable<Tarefa> Filtrar(string condicao)
        {
            return _repository.Filter(condicao);
        }

        public string ValidarDados(Tarefa entity)
        {
            return "";
        }

        public string ValidarExclusao(Tarefa entity)
        {
            return "";
        }

        public string ExcluirCascata(Tarefa entity)
        {
            return "";
        }
    }

}
