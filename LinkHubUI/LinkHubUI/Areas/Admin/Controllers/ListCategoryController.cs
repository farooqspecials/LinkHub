using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin
{
    public class ListCategoryController : Controller
    {


        private CategoryBs objBs;

        public ListCategoryController()
        {
            objBs = new CategoryBs();
        }
        // GET: Admin/ListCategory
        public ActionResult Index()
        {
            var cat = objBs.GetALL().ToList();
            return View(cat);

          
        }
    }
}