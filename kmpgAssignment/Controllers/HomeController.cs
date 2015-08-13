using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kmpgAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName) + new Random().Next().ToString();
                
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
                
                string[] lines = System.IO.File.ReadAllLines(path);

                var transactionsDataParser = new TransactionsDataParser();

                var result = transactionsDataParser.ParseCsvFile(lines);
                return View(result);

            }
            

            return View();
        }
    }
}