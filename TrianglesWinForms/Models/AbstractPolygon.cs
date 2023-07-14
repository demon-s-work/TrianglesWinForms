using System;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Permissions;
namespace TrianglesWinForms.Models
{
    public abstract class AbstractPolygon
    {
        private Pen defaultPen = new Pen(Color.Black, 3);
        public Color Color { get; set; }
        public void DrawScaled(Graphics g, float aspect)
        {
            var points = Points().Select(p => new PointF(p.X * aspect, p.Y * aspect)).ToArray();
            g.DrawPolygon(defaultPen, points);
            g.FillPolygon(new SolidBrush(Color), points);
        }

        public virtual bool IsPolygonInside(AbstractPolygon polygon)
        {
            return polygon.Points().All(IsPointInside);
        }

        public virtual bool IsPolygonCrosses(AbstractPolygon polygon)
        {
            return Vertices()
                .Any(v0 => polygon.Vertices()
                    .Any(v1 => AreVerticesIntersecting(v0.A, v0.B, v1.A, v1.B)));
        }
        
        public virtual bool IsPointInside(Point p)
        {
            throw new NotImplementedException();
        }

        public virtual Point[] Points()
        {
            throw new NotImplementedException();
        }

        public virtual Vertex2p[] Vertices()
        {
            throw new NotImplementedException();
        }
        
        private static float CalculateTriangleSign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }
        
        private bool AreVerticesIntersecting(Point a1, Point a2, Point b1, Point b2)
        {
            float sign1 = CalculateTriangleSign(a1, a2, b1);
            float sign2 = CalculateTriangleSign(a1, a2, b2);
            bool hasOppositeSigns = (sign1 > 0 && sign2 < 0) || (sign1 < 0 && sign2 > 0);

            if (hasOppositeSigns)
            {
                float sign3 = CalculateTriangleSign(b1, b2, a1);
                float sign4 = CalculateTriangleSign(b1, b2, a2);
                return sign3 > 0 && sign4 < 0 || sign3 < 0 && sign4 > 0;
            }

            return false;
        }
    }
}