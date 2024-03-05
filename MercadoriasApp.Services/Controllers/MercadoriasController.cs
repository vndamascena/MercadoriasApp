using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MercadoriasApp.Services.Model;
using MercadoriaApp.Data.Repositories;
using MercadoriaApp.Data.Entities;

namespace MercadoriasApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercadoriasController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(MercadoriasPostRequestModel model)
        {
            try
            {
                //Criando um objeto Produto (entidade)
                var mercadorias = new Mercadorias()
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Preco = model.Preco,
                    Quantidade = model.Quantidade,
                    CategoriaId = model.CategoriaId,
                    FornecedorId = model.FornecedorId

                };
                //gravar o produto no banco de dados
                var mercadoriasrepository = new MercadoriaRepository();
                mercadoriasrepository.Inserir(mercadorias);
                //retornar sucesso HTTP 201 (CREATED)
                return StatusCode(201, new
                {
                    Message = "Mercadoria cadastrada com sucesso!",

                    mercadorias.Id

                });
            }
            catch (Exception e)
            {
                //Erro do servidor (INTERNAL SERVER ERROR) HTTP 500
                return StatusCode(500, new { e.Message });
            }
        }
        [HttpPut]
        public IActionResult Put(MercadoriasPutRequestModel model)
        {
            try
            {
                //pesquisar o produto no banco de dados através do ID
                var mercadoriasRepository = new MercadoriaRepository();
                var mercadorias = mercadoriasRepository.ObterPorId(model.Id.Value);
                //verificar se o produto não foi encontrado
                if (mercadorias == null)
                    return StatusCode(400, new
                    {
                        Message = "Mercadoria não encontrado.Verifique o ID informado."
                    }); //alterar os dados do produto
                mercadorias.Nome = model.Nome;
                mercadorias.Preco = model.Preco;
                mercadorias.Quantidade = model.Quantidade;
                mercadorias.CategoriaId = model.CategoriaId;
                mercadorias.FornecedorId = model.FornecedorId;
                //atualizar no banco de dados
                mercadoriasRepository.Alterar(mercadorias);
                //retornar sucesso HTTP 200 (OK)
                return StatusCode(200, new
                {
                    Message = "Mercadoria atualizado com sucesso",

                    mercadorias.Id

                });
            }
            catch (Exception e)
            {
                //Erro do servidor (INTERNAL SERVER ERROR) HTTP 500
                return StatusCode(500, new { e.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //pesquisar o produto no banco de dados através do id
                var produtoRepository = new MercadoriaRepository();
                var produto = produtoRepository.ObterPorId(id);
                //verificar se o produto não foi encontrado

                if (produto == null)
                    return StatusCode(400, new
                    {
                        Message = "Mercadoria não encontrado.Verifique o ID informado."
                    });//excluir o produto

                produtoRepository.Excluir(produto);
                //retornar sucesso HTTP 200 (OK)
                return StatusCode(200, new
                {
                    Message = "Mercadoria excluído com sucesso",
                    produto.Id
                });
            }
            catch (Exception e)
            {
                //Erro do servidor (INTERNAL SERVER ERROR) HTTP 500
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<MercadoriasGetResponseModel>), 200)]
        public IActionResult GetAll()
        {
            try
            {
                //consultando os produtos no banco de dados
                var mercadoriaRepository = new MercadoriaRepository();
                var mercadorias = mercadoriaRepository.ObterTodos();
                var response = new List<MercadoriasGetResponseModel>();
                foreach (var item in mercadorias)
                {
                    response.Add(new MercadoriasGetResponseModel
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        Preco = item.Preco,
                        Quantidade = item.Quantidade,
                        Categoria = new CategoriasGetResponseModel

                        {
                            Id = item.Categoria?.Id,
                            Nome = item.Categoria?.Nome

                        },

                        Fornecedor = new FornecedoresGetResponseModel

                        {
                            Id = item.Fornecedor?.Id,

                            RazaoSocial = item.Fornecedor?.RazaoSocial,
                            Cnpj = item.Fornecedor?.Cnpj

                        }
                    });
                }
                //HTTP 200 (OK)
                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                //INTERNAL SERVER ERROR -> HTTP 500
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                //pesquisar um produto baseado no ID
                //pesquisar o produto no banco de dados através do id
                var produtoRepository = new MercadoriaRepository();
                var produto = produtoRepository.ObterPorId(id);
                //verificar se nenhum produto foi encontrado
                if (produto == null)
                    return NoContent(); //HTTP 204 (Não encontrado)
                                        //retornar os dados do produto
                var model = new MercadoriasGetResponseModel
                {
                    Id = produto.Id,
                    Nome = produto.Nome,
                    Preco = produto.Preco,
                    Quantidade = produto.Quantidade,
                    Categoria = new CategoriasGetResponseModel

                    {
                        Id = produto.Categoria?.Id,
                        Nome = produto.Categoria?.Nome

                    },

                    Fornecedor = new FornecedoresGetResponseModel

                    {
                        Id = produto.Fornecedor?.Id,

                        RazaoSocial = produto.Fornecedor?.RazaoSocial,
                        Cnpj = produto.Fornecedor?.Cnpj
                    }
                };
                return StatusCode(200, model);
            }
            catch (Exception e)
            {
                //INTERNAL SERVER ERROR -> HTTP 500
                return StatusCode(500, new { e.Message });
            }
        }

    }
}
