using ControleEstoque.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoque.Web.Controllers
{
    public class FornecedorController : Controller
    {
        private StockEntities stock = new StockEntities();

        public ActionResult Index()
        {
            return View(stock.Fornecedor.ToList());
        }

        public ActionResult SalvarFornecedor(Fornecedor f)
        {
            string resultado = "OK";
            List<string> mensagens = new List<string>();
            string idSalvo = string.Empty;

            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(m => m.Errors).Select(m => m.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    // Verifica se o fornecedor já existe
                    var forn = stock.Fornecedor.FirstOrDefault(x => x.Id == f.Id);

                    // Se não existe, adiciona e salva (create)
                    if (forn == null)
                    {
                        forn = f;
                        stock.Fornecedor.Add(forn);
                        stock.SaveChanges();
                    }
                    // Se existe, salva somente as alterações (update)
                    else
                    {
                        forn.Nome = f.Nome;
                        forn.Telefone = f.Telefone;
                        forn.Endereco = f.Endereco;
                        forn.Cidade = f.Cidade;
                        forn.Pais = f.Pais;
                        stock.SaveChanges();
                    }

                    idSalvo = f.Id.ToString();
                }
                catch (Exception ex)
                {
                    resultado = "ERRO: " + ex.Message;
                }


            }

            return Json(new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }
    }
}