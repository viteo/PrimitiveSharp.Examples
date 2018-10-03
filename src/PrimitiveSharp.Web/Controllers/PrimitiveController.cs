using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using PrimitiveSharp.Core.Services;
using PrimitiveSharp.Web.Models;


namespace PrimitiveSharp.Web.Controllers
{
    public class PrimitiveController : Controller
    {
        private readonly IRenderService renderService;

        public PrimitiveController(IRenderService renderService)
        {
            this.renderService = renderService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View(new Core.ParametersModel());
        }

        public IActionResult Test(Core.ParametersModel settingsModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var file = HttpContext.Request.Form.Files.First();
            string result;
            using (Stream stream = file.OpenReadStream())
            {
                byte[] imageArr = new byte[file.Length];
                stream.Read(imageArr);
                result = renderService.GetSvg(imageArr, settingsModel);
            }                 
            return Content(result, "image/svg+xml");
            //return View(Content(result, "image/svg+xml"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
