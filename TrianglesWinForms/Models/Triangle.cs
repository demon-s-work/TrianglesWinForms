using System.Drawing;
using System.Numerics;
using TrianglesWinForms.Extensions;
namespace TrianglesWinForms.Models
{
    public class Triangle : AbstractShape
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }

        public override Point[] GetPointsArray()
        {
            return new[] { A, B, C };
        }

        public bool IsInside(Triangle tr)
        {
            return A.IsInTriangle(tr) && B.IsInTriangle(tr) && C.IsInTriangle(tr);
        }

        public bool IsInside(CanvasShape c)
        {
            return true;
        }

        public bool IsCrosses(Triangle tr)
        {
            if (AreEdgesIntersecting(A, B, tr.A, tr.B) ||
                AreEdgesIntersecting(A, B, tr.B, tr.C) ||
                AreEdgesIntersecting(A, B, tr.C, tr.A))
            {
                return true;
            }

            if (AreEdgesIntersecting(B, C, tr.A, tr.B) ||
                AreEdgesIntersecting(B, C, tr.B, tr.C) ||
                AreEdgesIntersecting(B, C, tr.C, tr.A))
            {
                return true;
            }

            if (AreEdgesIntersecting(C, A, tr.A, tr.B) ||
                AreEdgesIntersecting(C, A, tr.B, tr.C) ||
                AreEdgesIntersecting(C, A, tr.C, tr.A))
            {
                return true;
            }

            return false;
        }

        private static float CalculateTriangleSign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        private static bool AreEdgesIntersecting(Point a1, Point a2, Point b1, Point b2)
        {
            float sign1 = CalculateTriangleSign(a1, a2, b1);
            float sign2 = CalculateTriangleSign(a1, a2, b2);
            bool hasOppositeSigns = (sign1 > 0 && sign2 < 0) || (sign1 < 0 && sign2 > 0);

            if (hasOppositeSigns)
            {
                float sign3 = CalculateTriangleSign(b1, b2, a1);
                float sign4 = CalculateTriangleSign(b1, b2, a2);
                return (sign3 > 0 && sign4 < 0) || (sign3 < 0 && sign4 > 0);
            }

            return false;
        }
        /*
        private static float CalculateTriangleSign(Point A, Point B, Point P)
        {
            return (A.X - P.X) * (B.Y - P.Y) - (B.X - P.X) * (A.Y - P.Y);
        }

        private static bool AreEdgesIntersecting(Point A1, Point B1, Point A2, Point B2)
        {
            float sign1 = CalculateTriangleSign(A1, A2, B1);
            float sign2 = CalculateTriangleSign(A1, A2, B2);
            bool hasOppositeSigns = (sign1 > 0 && sign2 < 0) || (sign1 < 0 && sign2 > 0);

            if (hasOppositeSigns)
            {
                float sign3 = CalculateTriangleSign(B1, B2, A1);
                float sign4 = CalculateTriangleSign(B1, B2, A2);
                return (sign3 > 0 && sign4 < 0) || (sign3 < 0 && sign4 > 0);
            }

            return false;
        }
        */
    }
}