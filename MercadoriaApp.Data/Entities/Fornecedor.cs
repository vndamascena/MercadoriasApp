using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoriaApp.Data.Entities
{
    public class Fornecedor
    {
        #region Propriedades

        public Guid? Id { get; set; } //Chave primária
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }

        #endregion

        #region Relacionamentos de composição

        public List<Mercadorias>? Mercadorias { get; set; } //ter-muitos

        #endregion

    }
}
