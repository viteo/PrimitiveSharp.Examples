using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimitiveSharp.Web.Models
{
    public class ImageFileModel
    {
        public byte[] ImageSVG;
        public readonly string ImageSVGType = "image/svg+xml";
        public byte[] ImageInput;
        public string ImageInputType;
        public string ImageResult;
        public string ImageResultType;
    }
}
