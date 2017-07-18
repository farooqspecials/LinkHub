using BLL;
using LinkHubUI.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin
{
    public class ListCategoryController : BaseAdminController
    {


      
        // GET: Admin/ListCategory
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var cat = objBs.cateogryBs.GetALL();

            switch (SortBy)
            {
                case "CategoryName":
                    switch (SortOrder)
                    {

                        case "Asc":
                            cat = cat.OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "Desc":
                            cat = cat.OrderByDescending(x => x.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.cateogryBs.GetALL().Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            //  urls = urls.Skip((page - 1) * 10).Take(10);
            cat = cat.Skip((page - 1) * 10).Take(10);
            return View(cat);

          
        }

        public ActionResult Delete(int id)
        {

            try
            {
                objBs.cateogryBs.Delete(id);
                //objBs.categoryBs.Delete(id);
                TempData["Msg"] = "Deleted Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Delete Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}