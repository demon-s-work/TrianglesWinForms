using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TrianglesWinForms.Models
{
    public class Node<TShape> where TShape : AbstractPolygon
    {
        public TShape Content { get; set; }
        public List<Node<TShape>> Childs { get; set; } = new List<Node<TShape>>();
        
        public int Depth => CountDepth(1);
        
        public void Paint(Color baseColor)
        {
            Content.Color = baseColor;
            foreach (var child in Childs)
            {
                child.Paint(ControlPaint.Dark(baseColor, 0.1f));
            }
        }
        
        private int CountDepth(int curDepth)
        {
            curDepth++;
            var maxDepth = 0;
            foreach (var child in Childs)
            {
                var childDepth = child.CountDepth(curDepth);
                maxDepth = Math.Max(curDepth, childDepth);
            }
            
            return maxDepth;
        }
        
        public void DrawScaled(Graphics g, float aspect)
        {
            Content.DrawScaled(g, aspect);
            foreach (var child in Childs)
            {
                child.DrawScaled(g, aspect);
            }
            
        }
    }
}