using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zadanie1.Models.Reposetory;
using zadanie1.Models;

namespace zadanie1.Controllers
{
    public class HomeController : Controller
    {
        private IDataReposetory context;

        public HomeController(IDataReposetory reposetory) : base()
        {
            context = reposetory;
        }



        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UpdateData(int page = 0, int record = 10)
        {
            ViewDataTable result = new ViewDataTable();
            result.data = context.GetRows(page, record);
            result.MaxRows = context.GetMaxRow();
            return Json(result, JsonRequestBehavior.DenyGet);
        }


    }
}