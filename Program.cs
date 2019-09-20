using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.Shapes;
using SixLabors.Primitives;
using SixLabors.Fonts;
using SixLabors.ImageSharp.PixelFormats;
using System;

namespace htpcovgen
{
    class Program
    {
        const string OUTPUT_DIR = "output";
        static void Main(string[] args)
        {
            var src_path = args[0];
            var scr_path_1080p = args[1];
            var slug = args[2];
            var episode_no = args[3];
            var subject = args[4];

            System.IO.Directory.CreateDirectory(OUTPUT_DIR);


            var text = "Episode #" + episode_no + " " + '\u00B7' + " " + subject;

            // create standard cover
            var font = SystemFonts.CreateFont("Consolas", 100, FontStyle.Regular);
            var rendererOptions = new RendererOptions(font);
            var image = Image.Load(src_path);
            image.Mutate(ctx => ctx.DrawText(text, font, Rgba32.Black, new PointF(100, 00)));
            image.Save(OUTPUT_DIR + "/" + slug + ".png");

            // create 1080p cover
            var font_1080p = SystemFonts.CreateFont("Consolas", 50, FontStyle.Regular);
            var rendererOptions_1080p = new RendererOptions(font_1080p);
            var image_1080p = Image.Load(scr_path_1080p);
            image_1080p.Mutate(ctx => ctx.DrawText(text, font_1080p, Rgba32.Black, new PointF(350, 970)));
            image_1080p.Save(OUTPUT_DIR + "/" + slug + "_1080p.png");

        }
    }
}
