using System;
using PrimitiveSharp.Core;
using SixLabors.ImageSharp;

namespace PrimitiveSharp.Web.Services
{
    public interface IRenderService
    {
        void RenderImage(byte[] imageArray, ParametersModel settings);
        string GetSvg();
        string GetJpeg();
        string GetPng();
    }

    public class RenderService : IRenderService
    {
        RendererModel renderer;

        public void RenderImage(byte[] imageArray, ParametersModel settings)
        {
            renderer = new RendererModel(imageArray, settings);
            renderer.RunRenderer();
        }

        public string GetJpeg()
        {
            return renderer.GetFrames(false).ToBase64String(ImageFormats.Jpeg);
        }

        public string GetPng()
        {
            return renderer.GetFrames(false).ToBase64String(ImageFormats.Png);
        }

        public string GetSvg()
        {
            return String.Join(string.Empty, renderer.GetSVG(false));
        }
    }
}
