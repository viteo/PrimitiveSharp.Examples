using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using PrimitiveSharp.Web.Services;
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

        public IActionResult Result(Core.ParametersModel settingsModel)
        {
            ImageFileModel imageFileModel = new ImageFileModel();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var file = HttpContext.Request.Form.Files.First();
            using (Stream stream = file.OpenReadStream())
            {
                imageFileModel.ImageInput = new byte[file.Length];
                imageFileModel.ImageInputType = file.ContentType;
                stream.Read(imageFileModel.ImageInput);
                renderService.RenderImage(imageFileModel.ImageInput, settingsModel);
                imageFileModel.ImageSVG = Encoding.ASCII.GetBytes(renderService.GetSvg());
                imageFileModel.ImageResult = renderService.GetPng();
            }
            return View(imageFileModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
