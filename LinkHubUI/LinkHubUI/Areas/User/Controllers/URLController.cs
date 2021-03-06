﻿using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.User
{
    [Authorize(Roles = "A,U")]
    public class URLController : Controller
    {
        // private CategoryBs CatBs;
        // private UrlBs UrlBs;
        // private UserBs UserBs;

        //public URLController(){
        //     CatBs = new CategoryBs();
        //     UrlBs = new UrlBs();
        //     UserBs = new UserBs();



        //     }
        private UserAreaBs objBs;

        public URLController()
        {
            objBs = new UserAreaBs();

        }

        // GET: User/URL
        public ActionResult Index()
        {
            //LinkHubDbEntities db = new LinkHubDbEntities();
            ViewBag.CategoryId = new SelectList(objBs.cateogryBs.GetALL(), "CategoryId", "CategoryName");
            //ViewBag.UserID = new SelectList(objBs.userBs.GetALL(), "UserId", "UserEmail");
            return View();
        }

        public ActionResult Create(tbl_Url myUrl)
        {
            //LinkHubDbEntities db = new LinkHubDbEntities();
            //ViewBag.CategoryId = new SelectList(db.tbl_Category, "CategoryId", "CategoryName");
            try
            {
                if (ModelState.IsValid)
                {
                    myUrl.UserId = objBs.userBs.GetALL().Where(x => x.UserEmail == User.Identity.Name).FirstOrDefault().UserId;
                   
                    myUrl.IsApproved = "P";
               objBs.urlBs.Insert(myUrl);
                TempData["Msg"] = "Created Successfully";
                return RedirectToAction("Index");
                }
                else
               {
                ViewBag.CategoryId = new SelectList(objBs.cateogryBs.GetALL().ToList(), "CategoryId", "CategoryName");
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