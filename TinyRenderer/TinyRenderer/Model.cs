using System.Globalization;
using System.Numerics;

namespace TinyRenderer
{
    public class Model
    {
        public List<Vector3> Vertices { get; }
        public List<List<int>> Faces { get; }

        private Model(List<Vector3> vertices, List<List<int>> faces)
        {
            Vertices = vertices;
            Faces = faces;
        }

        public static Model Parse(string file)
        {
            char[] separators =
            {
                '/', ' '
            };


        var vertices = new List<Vector3>();
            var faces = new List<List<int>>();

            foreach (var line in File.ReadLines(file))
            {
                var parts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length > 0)
                {
                    switch(parts[0])
                    {
                        case "v":
                            var x = Convert.ToSingle(parts[1], CultureInfo.InvariantCulture.NumberFormat);
                            var y = Convert.ToSingle(parts[2], CultureInfo.InvariantCulture.NumberFormat);
                            var z = Convert.ToSingle(parts[3], CultureInfo.InvariantCulture.NumberFormat);
                            vertices.Add(new Vector3(x, y, z));
                            break;
                        case "f":
                            var face = new List<int>
                            {
                                Convert.ToInt32(parts[1]) - 1,
                                Convert.ToInt32(parts[4]) - 1,
                                Convert.ToInt32(parts[7]) - 1,
                            };

                            //face.AddRange();

                            //{
                            //    face.Add(vertices[Convert.ToInt32(parts[1]) - 1]);
                            //    vertices[Convert.ToInt32(parts[4]) - 1],
                            //    vertices[Convert.ToInt32(parts[7]) - 1],
                            //};

                            faces.Add(face);
                            break;
                    }
                }
            }

            static int ParseFaceValue(string faceString)
            {
                var value =  int.Parse(faceString.Split("/")[0]);
                return --value;
            }

            return new Model(vertices, faces);
        }
    }
}
