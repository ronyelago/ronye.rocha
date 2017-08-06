using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleEstoque.Web.Models
{
    public class GrupoProdutoModel
    {
        public int Id { get; set; }

        // Mensagem de erro que será retornada caso o campo seja deixado em branco
        [Required(ErrorMessage = "O campo Nome é obrigatório!")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }
    }
}