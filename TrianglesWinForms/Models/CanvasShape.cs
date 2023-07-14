using System.Drawing;
namespace TrianglesWinForms.Models
{
    public class CanvasShape : AbstractShape
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }
        public int W => B.X - A.X;
        public int H => A.Y - D.Y;
        public override Point[] GetPointsArray()
        {
            return new[] { A, B, C, D };
        }
    }
}