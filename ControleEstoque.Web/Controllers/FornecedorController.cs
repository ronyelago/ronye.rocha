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
    }
}