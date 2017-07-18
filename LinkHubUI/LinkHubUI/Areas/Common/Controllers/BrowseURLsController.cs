using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace LinkHubUI.Areas.Common.Controllers
{
    [AllowAnonymous]
    public class BrowseURLsController : Controller
    {

        private CommonBs objBs;

        public BrowseURLsController()
        {
            objBs = new CommonBs();
        }
        

        // GET: Common/BrowseURLs
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {

            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            //  var Urls = ObjBs.GetALL().Where(x=>x.IsApproved=="A").ToList();

            var urls = objBs.urlBs.GetALL().Where(x => x.IsApproved == "A");

            switch (SortBy)
            {
                case "Title":
                    switch (SortOrder)
                    {

                        case "Asc":
                            urls = urls.OrderBy(x => x.UrlTitle).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UrlTitle).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Category":
                    switch (SortOrder)
                    {

                        case "Asc":
                            urls = urls.OrderBy(x => x.tbl_Category.CategoryName).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.tbl_Category.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "Url":
                    switch (SortOrder)
                    {

                        case "Asc":
                            urls = urls.OrderBy(x => x.Url).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.Url).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "UrlDesc":
                    switch (SortOrder)
                    {

                        case "Asc":
                            urls = urls.OrderBy(x => x.UrlDesc).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UrlDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    urls = urls.OrderBy(x => x.UrlTitle).ToList();
                    break;
            }

            ViewBag.TotalPages = Math.Ceiling(objBs.urlBs.GetALL().Where(x => x.IsApproved == "A").Count() / 10.0);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            urls = urls.Skip((page - 1) * 10).Take(10);

            return View(urls);
        }
    }
}