using System;
using System.Drawing;
using System.Linq;
namespace TrianglesWinForms.Models
{
    public abstract class AbstractShape : IShape
    {
        private Pen defaultPen = new Pen(Color.Black, 3);
        public void DrawScaled(Graphics g, float aspect)
        {
            var points = GetPointsArray().Select(p => new PointF(p.X * aspect, p.Y * aspect)).ToArray();
            g.DrawPolygon(defaultPen, points);
            g.FillPolygon(new SolidBrush(Color), points);
        }

        public virtual Point[] GetPointsArray()
        {
            return Array.Empty<Point>();
        }

        public Color Color { get; set; }
    }
}