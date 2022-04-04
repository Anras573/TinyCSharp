namespace TinyRenderer.Canvas
{
    public struct Color
    {
        public const int NumberOfBytes = 4;

        public byte R { get; }
        public byte G { get; }
        public byte B { get; }
        public byte A { get; }

        public Color(byte r, byte g, byte b, byte a = byte.MaxValue)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}
