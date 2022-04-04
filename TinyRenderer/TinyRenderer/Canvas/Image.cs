using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace TinyRenderer.Canvas
{
    public class Image
    {
        public int Width { get; }
        public int Height { get; }

        private readonly Image<Rgba32> _innerImage;

        public Image(int width, int height)
        {
            Width = width;
            Height = height;

            _innerImage = new Image<Rgba32>(width, height);

            _innerImage.ProcessPixelRows(accessor =>
            {
                Rgba32 black = new (0, 0, 0);

                for (int y = 0; y < accessor.Height; y++)
                {
                    foreach (ref Rgba32 pixel in accessor.GetRowSpan(y))
                    {
                        pixel = black;
                    }
                }
            });
        }

        public void SetPixel(int x, int y, Color color)
        {
            if (y == Height) y = Height - 1;
            if (x == Width) x = Width - 1;

            _innerImage[x, y] = new Rgba32(color.R, color.G, color.B, color.A);
        }

        public void FlipVertically()
        {
            _innerImage.Mutate(i => i.Flip(FlipMode.Vertical));
        }

        public void FlipHorizontally()
        {
            _innerImage.Mutate(i => i.Flip(FlipMode.Horizontal));
        }

        public void Save(string filename)
        {
            _innerImage.Save(filename);
        }
    }
}
