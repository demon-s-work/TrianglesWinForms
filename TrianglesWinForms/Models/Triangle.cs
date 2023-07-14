using System.Drawing;
namespace TrianglesWinForms.Models
{
    public class Triangle : AbstractPolygon
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }


        public override Point[] Points()
        {
            return new[] { A, B, C };
        }

        public override Vertex2p[] Vertices()
        {
            return new[]
            {
                new Vertex2p(A, B),
                new Vertex2p(B, C),
                new Vertex2p(C, A)
            };
        }

        public override bool IsPointInside(Point p)
        {
            var v0 = (A.X - p.X) * (B.Y - A.Y) - (B.X - A.X) * (A.Y - p.Y);
            var v1 = (B.X - p.X) * (C.Y - B.Y) - (C.X - B.X) * (B.Y - p.Y);
            var v2 = (C.X - p.X) * (A.Y - C.Y) - (A.X - C.X) * (C.Y - p.Y);

            return v0 < 0 == v1 < 0 && v1 < 0 == v2 < 0;
        }
    }
}