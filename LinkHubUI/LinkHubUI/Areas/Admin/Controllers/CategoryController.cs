using BLL;
using BOL;
using LinkHubUI.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin
{
    public class CategoryController : BaseAdminController
    {
       
        // GET: Admin/Category
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult Create(tbl_Category cat)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    objBs.cateogryBs.Insert(cat);
                    //objBs.categoryBs.Delete(id);
                    TempData["Msg"] = "Category Created Successfully";
                    return RedirectToAction("Index");
                } else
                {
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Category creation Failed : " + e1.Message;
                return RedirectToAction("Index");
            }

            

            
        }
    }
}