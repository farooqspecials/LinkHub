﻿using LinkHubUI.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin
{
    public class ApproveURLsController : BaseAdminController
    {
        // GET: Admin/ApproveURLs
        public ActionResult Index(string Status)
        {
            ViewBag.Status = (Status == null ? "P" : Status);
            if (Status == null)
            {
                var urls = objBs.urlBs.GetALL().Where(x => x.IsApproved == "P").ToList();
                return View(urls);
            }
            else
            {
                var urls = objBs.urlBs.GetALL().Where(x => x.IsApproved == Status).ToList();
                return View(urls);
            }
        }

        public ActionResult Approve(int id)
        {
            try
            {
                var myUrl = objBs.urlBs.GetByID(id);
                myUrl.IsApproved = "A";
                objBs.urlBs.Update(myUrl);
                TempData["Msg"] = "Approved Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Approval Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult Reject(int id)
        {
            try
            {
                var myUrl = objBs.urlBs.GetByID(id);
                myUrl.IsApproved = "R";
                objBs.urlBs.Update(myUrl);
                TempData["Msg"] = "Rejected Successfully";
                return RedirectToAction("Index");
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Reject Url Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}