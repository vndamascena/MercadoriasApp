using MercadoriaApp.Data.Entities;
using MercadoriaApp.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoriaApp.Data.Repositories
{
    public class CategoriaRepository
    {
        /// <summary>
        /// Método para consultar todas as categorias cadastradas
        /// </summary>
        public List<Categoria> ObterTodos()
        {
            using (var dataContext = new DataContexts())
            {
                return dataContext
                .Set<Categoria>() //tabela de categorias
                .OrderBy(c => c.Nome) //order de nome
                .ToList(); //retornando uma lista de categorias

            }
        }
    }
}
