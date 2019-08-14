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
            var slug = args[1];
            var episode_no = args[2];
            var subject = args[3];

            System.IO.Directory.CreateDirectory(OUTPUT_DIR);

            var image = Image.Load(src_path);

            var font = SystemFonts.CreateFont("Consolas", 100, FontStyle.Regular);

            var rendererOptions = new RendererOptions(font);
            var text = "Episode #" + episode_no + " " + '\u00B7' + " " + subject;

            image.Mutate(ctx => ctx.DrawText(text, font, Rgba32.Black, new PointF(100, 2700)));

            image.Save(OUTPUT_DIR + "/" + slug + ".png");
                
        }
    }
}
