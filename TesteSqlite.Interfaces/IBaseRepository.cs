using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSqlite.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        string ValidarDados(T entity);

        string ValidarExclusao(T entity);

        string ExcluirCascata(T entity);
    }
}
