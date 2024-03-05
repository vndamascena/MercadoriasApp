using MercadoriaApp.Data.Entities;
using MercadoriaApp.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoriaApp.Data.Repositories
{
    public class FornecedorRepository
    {
        public List<Fornecedor> ObterTodos()
        {
            using (var dataContext = new DataContexts())
            {
                return dataContext
                .Set<Fornecedor>() //tabela de fornecedores

                .OrderBy(f => f.RazaoSocial)
                //ordenar pelo campo razão social

                .ToList(); //retornando uma lista de fornecedores
            }
        }
    }
}
