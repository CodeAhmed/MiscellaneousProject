using GProvSample.DAL;
using GProvSample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GProvSample.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /Upload/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, Templates objtemplates)
        {
            if (file == null || file.ContentLength == 0)
            {
                ModelState.AddModelError("", "Please select file or your file is empty");
            }
            else if (file.ContentLength > 0)
            {
                string[] AllowedFileExtensions = new string[] { ".xlsx", ".csv" };
                if (!AllowedFileExtensions.Contains(System.IO.Path.GetExtension(file.FileName)))
                {
                    ModelState.AddModelError("", "Please Select file of type: " + string.Join(", ", AllowedFileExtensions));
                }
                else
                {
                    var fileExt = Path.GetExtension(file.FileName);
                    var fileName = Path.GetFileName(file.FileName) + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + fileExt;
                    string directory = Server.MapPath("~/Content/Upload/");
                    if (!Directory.Exists(directory))
                    {
                        Directory.CreateDirectory(directory);
                    }
                    var path = Path.Combine(directory, fileName);
                    file.SaveAs(path);
                    DALProperty prop = new DALProperty();
                    prop.ParseExcel(path, objtemplates.Type.ToString());
                    ViewBag.Message = "File has been uploaded successfully. You can proceed by selecting the required site from Top Navigation.";
                    return View("Index");
                }
            }
            return View("Index");
        }
	}
}