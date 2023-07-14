using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TrianglesWinForms.Models
{
    public class Node<TShape> : CovariantNode<TShape, TShape> where TShape : AbstractShape
    {
    }

    public class CovariantNode<TShape, TNodeShape> where TShape : AbstractShape where TNodeShape : AbstractShape
    {
        public TShape Content { get; set; }
        public List<Node<TNodeShape>> Childs { get; set; } = new List<Node<TNodeShape>>();

        public void Paint(Color baseColor)
        {
            Content.Color = baseColor;
            foreach (var child in Childs)
            {
                child.Paint(ControlPaint.Dark(baseColor, 0.1f));
            }
        }

        public int Depth => CountDepth(1);
        
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