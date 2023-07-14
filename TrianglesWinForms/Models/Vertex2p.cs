using System.Drawing;
namespace TrianglesWinForms.Models
{
    public class Vertex2p
    {
        public Vertex2p(Point a, Point b)
        {
            A = a;
            B = b;
        }
        public Point A { get; set; }
        public Point B { get; set; }
    }
}