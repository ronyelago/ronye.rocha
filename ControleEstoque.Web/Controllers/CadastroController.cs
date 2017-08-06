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
        private static List<GrupoProdutoModel> lista = new List<GrupoProdutoModel>()
        {
            new GrupoProdutoModel { Id = 1, Nome = "Laticínios", Ativo = true },
            new GrupoProdutoModel { Id = 2, Nome = "Ervas", Ativo = true },
            new GrupoProdutoModel { Id = 3, Nome = "Infantil", Ativo = true },
            new GrupoProdutoModel { Id = 4, Nome = "Jardinagem", Ativo = true },
            new GrupoProdutoModel { Id = 5, Nome = "Ferramentas", Ativo = true }
        };

        [HttpPost]
        [Authorize]
        public ActionResult SalvarGrupoProduto(GrupoProdutoModel model)
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
                    var gp = lista.Find(x => x.Id == model.Id);

                    if (gp == null)
                    {
                        gp = model;
                        gp.Id = lista.Max(x => x.Id) + 1;
                        lista.Add(gp);
                    }
                    else
                    {
                        gp.Nome = model.Nome;
                        gp.Ativo = model.Ativo;
                    }

                    idSalvo = gp.Id.ToString();
                }
                catch
                {
                    resultado = "ERRO";
                }


            }

            return Json( new { Resultado = resultado, Mensagens = mensagens, IdSalvo = idSalvo });
        }

        [HttpPost]
        [Authorize]
        public ActionResult ExcluirGrupoProduto(int id)
        {
            bool found = false;
            GrupoProdutoModel gp = lista.First(x => x.Id == id);

            if (gp != null)
            {
                found = true;
                lista.Remove(gp);
            }

            return Json(found);
        }

        [Authorize]
        public ActionResult GrupoProduto()
        {
            return View(lista);
        }

        [HttpPost]
        [Authorize]
        public ActionResult RecuperarGrupoProduto(int id)
        {
            return Json(lista.Find(x => x.Id == id));
        }

        [Authorize]
        public ActionResult MarcaProduto()
        {
            return View();
        }

        [Authorize]
        public ActionResult LocalProduto()
        {
            return View();
        }

        [Authorize]
        public ActionResult UnidadeMedida()
        {
            return View();
        }

        [Authorize]
        public ActionResult Produto()
        {
            return View();
        }

        [Authorize]
        public ActionResult Pais()
        {
            return View();
        }

        [Authorize]
        public ActionResult Estado()
        {
            return View();
        }

        [Authorize]
        public ActionResult Cidade()
        {
            return View();
        }

        [Authorize]
        public ActionResult Fornecedor()
        {
            return View();
        }

        [Authorize]
        public ActionResult PerfilUsuario()
        {
            return View();
        }

        [Authorize]
        public ActionResult Usuario()
        {
            return View();
        }
    }
}