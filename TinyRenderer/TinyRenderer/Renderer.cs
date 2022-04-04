using TinyRenderer.Canvas;

namespace TinyRenderer
{
    public class Renderer
    {
        public Image Image { get; set; }

        public Renderer(Image image)
        {
            Image = image;
        }

        public void Line(int x0, int y0, int x1, int y1, Color color)
        {
            bool steep = false;

            if (Math.Abs(x0 - x1) < Math.Abs(y0 - y1))
            {
                // if the line is steep, we transpose the image 
                (y0, x0) = (x0, y0);
                (y1, x1) = (x1, y1);

                steep = true;
            }

            if (x0 > x1)
            {
                // make it left−to−right 
                (x0, x1) = (x1, x0);
                (y0, y1) = (y1, y0);
            }

            int dx = x1 - x0;
            int dy = y1 - y0;
            int derror2 = Math.Abs(dy) * 2;
            int error2 = 0;
            int y = y0;

            for (int x = x0; x <= x1; x++)
            {
                if (steep)
                {
                    Image.SetPixel(y, x, color);
                }
                else
                {
                    Image.SetPixel(x, y, color);
                }

                error2 += derror2;

                if (error2 > dx)
                {
                    y += (y1 > y0 ? 1 : -1);
                    error2 -= dx * 2;
                }
            }
        }

        public void DrawModelFrame(Model model, Color color)
        {
            foreach (var face in model.Faces)
            {
                for (int i = 0; i < face.Count; i++)
                {
                    var v0 = model.Vertices[face[i]];
                    var v1 = model.Vertices[face[(i + 1) % 3]];

                    int x0 = (int)((v0.X + 1f) * Image.Width / 2f);
                    int y0 = (int)((v0.Y + 1f) * Image.Height / 2f);
                    int x1 = (int)((v1.X + 1f) * Image.Width / 2f);
                    int y1 = (int)((v1.Y + 1f) * Image.Height / 2f);

                    Line(x0, y0, x1, y1, color);
                }
            }
        }
    }
}
