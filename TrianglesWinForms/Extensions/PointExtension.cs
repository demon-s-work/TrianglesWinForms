using System.Drawing;
using TrianglesWinForms.Models;
namespace TrianglesWinForms.Extensions
{
    public static class PointExtension
    {
        public static bool IsInTriangle(this Point p, Triangle tr)
        {
            var v0 = (tr.A.X - p.X) * (tr.B.Y - tr.A.Y) - (tr.B.X - tr.A.X) * (tr.A.Y - p.Y);
            var v1 = (tr.B.X - p.X) * (tr.C.Y - tr.B.Y) - (tr.C.X - tr.B.X) * (tr.B.Y - p.Y);
            var v2 = (tr.C.X - p.X) * (tr.A.Y - tr.C.Y) - (tr.A.X - tr.C.X) * (tr.C.Y - p.Y);

            return ((v0 < 0) == (v1 < 0) && (v1 < 0) == (v2 < 0));
        }
    }
}