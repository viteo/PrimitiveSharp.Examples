using PrimitiveSharp.Web.ViewModels;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimitiveSharp.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //discover all the images in the /media folder and load into viewmodel
            HomeViewModel model = new HomeViewModel();
            model.Images = new DirectoryInfo(Server.MapPath("~/media"))
                .GetFiles("*.jpg")
                .Select(fi => new ImageViewModel
                {
                    RelativePath = $"/media/{fi.Name}"
                })
                .ToList();
            return View(model);
        }

        public ActionResult PrimitiveSharpSvg(string relativePath)
        {
            //take the image requested with relative path (prepend ~) and load with imagesharp
            string path = Server.MapPath($"~/{relativePath}");
            using (Image<Rgba32> image = Image.Load(path))
            {
                //pass settings with image to PrimitiveSharp.Core to generate the svg
                return Content(Helper.GenerateSvg(new SettingsModel {  Repeat = 0, NumberOfPrimitives = 10 }, image), "image/svg+xml");
            }
        }
    }
}