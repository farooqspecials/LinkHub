using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin
{
    public class ListUserController : Controller
    {
        private UserBs objBs;

        public ListUserController()
        {
            objBs = new UserBs();
        }

        // GET: Admin/ListUser
        public ActionResult Index()
        {
            var user = objBs.GetALL().ToList();
            return View(user);
        }
    }
}