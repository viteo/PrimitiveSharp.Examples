using PrimitiveSharp.Core;
using System;

namespace PrimitiveSharp.Web
{
    public class SettingsModel
    {
        public byte AlphaValue { get; set; } = 0x80; //0-255 the polygons will be drawn with this alpha level
        public int CanvasSize { get; set; } = 256; //the input image is resampled to this width before polygon generation, height is aspect calculated
        public int RenderSize { get; set; } = 1024; //the output SVG width (viewbox); height will be aspect calculated
        public int Repeat { get; set; } = 0; //add N extra shapes per iteration with reduced search

        public ShapeEnum Mode { get; set; } = ShapeEnum.Combination;
        public LogLevelEnum LogLevel { get; internal set; } = LogLevelEnum.None;
        public ShapeType ShapeType { get; internal set; } = ShapeType.Any;
        public int NumberOfPrimitives { get; internal set; } = 10;
    }
    public enum LogLevelEnum
    {
        None,
        Verbose,
        VeryVerbose
    }
    public enum ShapeEnum
    {
        Combination,
        Triangle,
        Rectangle,
        Ellipse,
        Circle,
        RotatedRectangle,
        Beziers,
        RotatedEllipse,
        Polygon,
        Quadratic
    }
}