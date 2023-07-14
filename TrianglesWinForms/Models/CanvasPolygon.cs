using System.Drawing;
using System.Windows.Forms;
namespace TrianglesWinForms.Models
{
    public class CanvasPolygon : AbstractPolygon
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }
        public int W => B.X - A.X;
        public int H => A.Y - D.Y;
        
        public override Point[] Points()
        {
            return new[] { A, B, C, D };
        }

        public override Vertex2p[] Vertices()
        {
            return new[]
            {
                new Vertex2p(A, B),
                new Vertex2p(B, C),
                new Vertex2p(C, D),
                new Vertex2p(D, A)
            };
        }

        public override bool IsPolygonInside(AbstractPolygon polygon)
        {
            return true;
        }

        public override bool IsPointInside(Point p)
        {
            return true;
        }

        public override bool IsPolygonCrosses(AbstractPolygon polygon)
        {
            return false;
        }
    }
}