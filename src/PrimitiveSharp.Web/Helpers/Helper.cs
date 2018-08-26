using PrimitiveSharp.Core;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace PrimitiveSharp.Web
{
    public class Helper
    {
        public static string GenerateSvg(SettingsModel settings, Image<Rgba32> image)
        {
            //generate PrimitiveSharp.Core ParametersModel from PrimitiveSharp.Web SettingsModel
            ParametersModel parameters = new ParametersModel();
            parameters.Mode = settings.ShapeType;
            parameters.Alpha = settings.AlphaValue;
            parameters.Repeat = settings.Repeat;
            parameters.Nprimitives = settings.NumberOfPrimitives;            
            parameters.CanvasResize = settings.CanvasSize;
            parameters.RenderSize = settings.RenderSize;

            //default values not exposed in SettingsModel
            parameters.NthFrame = 1;
            parameters.LogLevel = (int)settings.LogLevel;
            parameters.WorkersCount = Environment.ProcessorCount;
            parameters.Background = Core.Core.AverageImageColor(image);
            
            //Speed tuning; reduces attempts at the cost of accuracy
            parameters.ShapeAge = 10; //Default: 100
            parameters.ShapeProbeCount = 10; //Default: 1000

            //Create PrimitiveSharp.Core renderer
            RendererModel model = new RendererModel(image, parameters);
            //Run render
            model.RunRenderer();

            //get SVG from results
            var svg = model.GetSVG(false, parameters.NthFrame).First();
            return svg;
        }

    }
}
