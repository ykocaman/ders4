using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace ders4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            if(HttpContext.Application["counter"] == null){
                HttpContext.Application["counter"] = 0;
            }

            HttpContext.Application["counter"] = Convert.ToInt16(HttpContext.Application["counter"]) + 1;
            
            ViewBag.counter = HttpContext.Application["counter"];

            return View();
        }

        [HttpPost]
        public ActionResult Control(string txtUsername,string txtPassword)
        {
            XmlDocument xml = new XmlDocument();

            xml.Load(Server.MapPath(@"\App_Data\db.xml"));
            var admin = xml.SelectSingleNode(@"/admin");

            var name = admin.SelectSingleNode("name").InnerText;
            var password = admin.SelectSingleNode("password").InnerText;

            if (txtUsername == name && txtPassword == password)
            {
                Session["name"] = name;
                Session["admin"] = true;
                return Redirect("/Panel/Index");
            }

            ViewBag.LoginFailed = true;

            return Redirect("/Home/Index");
        }

    }
}