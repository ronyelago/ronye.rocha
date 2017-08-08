using ControleEstoque.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoque.Web.Controllers
{
    public class CadastroController : Controller
    {
        private StockEntities stock = new StockEntities();

        [HttpPost]
        [Authorize]
        public ActionResult SalvarCategoriaProduto(CategoriaProduto cp)
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
                    // Verifica se a categoria já existe
                    var c = stock.CategoriaProduto.FirstOrDefault(x => x.Id == cp.Id);

                    // Se não existe, adiciona e salva (create)
                    if (c == null)
                    {
                        c = cp;
                        stock.CategoriaProduto.Add(c);
                        stock.SaveChanges();
                    }
                    // Se existe, salva somente as alterações (update)
                    else
                    {
                        c.Nome = cp.Nome;
                        c.Estado = cp.Estado;
                        stock.SaveChanges();
                    }

                    idSalvo = c.Id.ToString();
                }
                catch (Exception ex)
                {
                    resultado = "ERRO: " + ex.Message;
                }


            }

            return Json( new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }

        [HttpPost]
        [Authorize]
        public ActionResult ExcluirCategoriaProduto(int id)
        {
            bool found = false;
            var cp = stock.CategoriaProduto.First(x => x.Id == id);

            if (cp != null)
            {
                found = true;
                stock.CategoriaProduto.Remove(cp);
                stock.SaveChanges();
            }

            return Json(found);
        }

        [Authorize]
        public ActionResult GrupoProduto()
        {
            return View(stock.CategoriaProduto.ToList());
        }

        [HttpPost]
        [Authorize]
        public ActionResult RecuperarGrupoProduto(int id)
        {
            CategoriaProduto cp = stock.CategoriaProduto.First(x => x.Id == id);

            return Json(cp);
        }
    }
}