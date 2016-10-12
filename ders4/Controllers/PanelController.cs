using ders4.Filters;
using ders4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ders4.Controllers
{
    [UserAuthorize]
    public class PanelController : Controller
    {
        // GET: Panel

        public List<Product> productList = new List<Product>(){
                new Product(){id=1,name = "kalem", detail = "mor", price = 22.00 },
                new Product(){id=2,name = "silgi", detail = "yesil", price = 11.00 },
                new Product(){id=3,name = "canta", detail = "mavi", price = 5.00 },
                new Product(){id=4,name = "masa", detail = "üçgen", price = 7.00 },
                new Product(){id=5,name = "sandalye", detail = "yeni", price = 19.00 }
          };

        public ActionResult Index()
        {
            if (Request.Cookies["mesaj_gosterildimi"]  == null)
            {
                HttpCookie cookie = new HttpCookie("mesaj_gosterildimi", "evet");
                Response.Cookies.Add(cookie);
                ViewBag.ShowMessage = true;
            }

            ViewBag.name = Session["name"];

            return View(this.productList);
        }
    }
}