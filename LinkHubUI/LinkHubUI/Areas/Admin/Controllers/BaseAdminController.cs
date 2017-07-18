using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Admin.Controllers
{
    public class BaseAdminController : Controller
    {
        //use of protected due to inheritance
        protected AdminBs objBs;

        public BaseAdminController()
        {
            objBs = new AdminBs();
        }

    }
}