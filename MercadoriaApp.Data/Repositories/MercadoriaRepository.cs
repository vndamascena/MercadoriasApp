using MercadoriaApp.Data.Contexts;
using MercadoriaApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoriaApp.Data.Repositories
{
    public class MercadoriaRepository
    {
        /// <summary>
        /// Método para inserir um produto no banco de dados
        /// </summary>
        public void Inserir(Mercadorias mercadorias)
        {
            using (var dataContext = new DataContexts())
            {
                dataContext.Add(mercadorias); //inserindo no banco de dados
                dataContext.SaveChanges(); //executando a operação
            }
        }
        /// <summary>
        /// Método para atualizar um produto no banco de dados
        /// </summary>
        public void Alterar(Mercadorias mercadorias)
        {
            using (var dataContext = new DataContexts())
            {
                dataContext.Update(mercadorias); //atualizando no banco de dados
                dataContext.SaveChanges(); //executando a operação
            }
        }
        /// <summary>
        /// Método para excluir um produto no banco de dados
        /// </summary>
        public void Excluir(Mercadorias mercadorias)
        {
            using (var dataContext = new DataContexts())
            {
                dataContext.Remove(mercadorias);
                dataContext.SaveChanges();
            }
        }
        /// <summary>
        /// Método para consultar todos os produtos cadastrados
        /// </summary>
        public List<Mercadorias> ObterTodos()
        {
            using (var dataContext = new DataContexts())
            {
                return dataContext
                .Set<Mercadorias>() //consultar a tabela de produto
                .Include(p => p.Fornecedor)//JOIN com a tabela de Fornecedor
                .Include(p => p.Categoria)//JOIN com a tabela de Categoria
                .OrderBy(p => p.Nome) //ordenar pelo nome
                .ToList(); //retornar uma lista

            }
        }
        /// <summary>
        /// Método para consultar 1 produto através do ID
        /// </summary>
        public Mercadorias? ObterPorId(Guid id)
        {
            using (var dataContext = new DataContexts())
            {
                return dataContext
                .Set<Mercadorias>() //consultar a tabela de produto
                .Include(p => p.Fornecedor)//JOIN com a tabela de Fornecedor
                .Include(p => p.Categoria)//JOIN com a tabela de Categoria

                .Where(p => p.Id == id)
                //filtrando pelo id (chave primária)

                .FirstOrDefault();

                //retornar o primeiro registro ou null

            }
        }
    }
}
