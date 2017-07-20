using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class QuickURLController : Controller
    {
        private CommonBs objBs;

        public QuickURLController()
        {
            objBs = new CommonBs();
        }
        // GET: Common/QuickURL
        public ActionResult Index()
        {
            ViewBag.CategoryId = new SelectList(objBs.cateogryBs.GetALL(), "CategoryId", "CategoryName");
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(QuickURLSubmitModel MyModel)
        {
            // ViewBag.CategoryId = new SelectList(objBs.cateogryBs.GetALL(), "CategoryId", "CategoryName");
            // return View();

            try
            {
                //tbl_User U = MyModel.User;
                ModelState.Remove("User.Password");
                ModelState.Remove("User.ConfirmPassword");
                ModelState.Remove("MyUrl.UrlDesc");

                if (ModelState.IsValid)
                {
                    objBs.InsertQuickUrl(MyModel);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objBs.cateogryBs.GetALL(), "CategoryId", "CategoryName");
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}