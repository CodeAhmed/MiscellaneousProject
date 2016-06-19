using GProvSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GProvSample.Controllers
{
    public class DashboardController : Controller
    {
        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Index()
        //{
        //    ObjectData objtemp = new ObjectData();
        //    List<ObjectData> listobjnullsite = objtemp.GetObjects(); //load all the available uploaded list which has site id as null
        //    //List<ObjectData> menuTree = objtemp.GetMenuTree(listobjnullsite, listobjnullsite.FirstOrDefault().ObjType, listobjnullsite.FirstOrDefault().ObjSubType);
        //    List<ObjectData> menuTree = objtemp.GetMenuTree(listobjnullsite, "OT1");
        //    return View(menuTree);
        //}

        public JsonResult Test()
        {
            MenuTree mt = new MenuTree();
            List<MenuTree> listmenuTree = mt.GetTreeData();
            List<MenuTree> menuTree = mt.GetMenuTree(listmenuTree);
            //List<MenuTree> menuTree = mt.GetMenuTree(listmenuTree, listmenuTree.FirstOrDefault().ObjType);
            return Json(menuTree, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MenuIndex()
        {
            MenuTree mt = new MenuTree();
            List<MenuTree> listmenuTree = mt.GetTreeData();
            List<MenuTree> menuTree = mt.GetMenuTree(listmenuTree);
            return View(menuTree);
        }

        public ActionResult NewIndex()
        {
            return View();
        }
    }
}