using System.Drawing;
namespace TrianglesWinForms.Models
{
    public interface IShape
    {
        Point[] GetPointsArray();
        void DrawScaled(Graphics g, float aspect);
    }
}