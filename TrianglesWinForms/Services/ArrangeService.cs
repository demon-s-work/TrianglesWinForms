using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using TrianglesWinForms.Models;
namespace TrianglesWinForms.Services
{
    public class ArrangeService
    {
        public event EventHandler OnError;
        public event EventHandler<Node<AbstractPolygon>> OnComplete;
        public void Arrange(List<Triangle> polygons)
        {
            if (polygons == null)
            {
                return;
            }

            var root = new Node<AbstractPolygon>
            {
                Content = new CanvasPolygon()
            };
            
            foreach (var pl in polygons)
            {
                if (!ArrangePolygon(root, pl))
                {
                    Error();
                    return;
                }
            }
            root.Content = GetBoundingBox(root);
            Complete(root);
        }

        private bool ArrangePolygon(Node<AbstractPolygon> node, AbstractPolygon polygon)
        {
            if (node.Childs.Count == 0)
            {
                node.Childs.Add(new Node<AbstractPolygon>
                {
                    Content = polygon
                });
                return true;
            }

            foreach (var rootChild in node.Childs)
            {
                if (rootChild.Content.IsPolygonInside(polygon))
                {
                    return ArrangePolygon(rootChild, polygon);
                }

                if (polygon.IsPolygonInside(rootChild.Content))
                {
                    node.Childs.Remove(rootChild);
                    node.Childs.Add(new Node<AbstractPolygon>
                    {
                        Content = polygon,
                        Childs = { rootChild }
                    });
                    return true;
                }

                if (rootChild.Content.IsPolygonCrosses(polygon))
                {
                    Error();
                    return false;
                }
            }

            node.Childs.Add(new Node<AbstractPolygon>
            {
                Content = polygon
            });
            
            return true;
        }

        private void Complete(Node<AbstractPolygon> root)
        {
            OnComplete?.Invoke(this, root);
        }

        private void Error()
        {
            OnError?.Invoke(this, EventArgs.Empty);
        }

        private CanvasPolygon GetBoundingBox(Node<AbstractPolygon> node)
        {
            var minX = Int32.MaxValue;
            var maxX = Int32.MinValue;
            var minY = Int32.MaxValue;
            var maxY = Int32.MinValue;
            
            foreach (var child in node.Childs)
            {
                minX = Math.Min(minX, child.Content.Points().Min(p => p.X));
                maxX = Math.Max(maxX, child.Content.Points().Max(p => p.X));
                minY = Math.Min(minY, child.Content.Points().Min(p => p.Y));
                maxY = Math.Max(maxY, child.Content.Points().Max(p => p.Y));
            }
            return new CanvasPolygon
            {
                A = new Point(minX, maxY),
                B = new Point(maxX, maxY),
                C = new Point(maxX, minY),
                D = new Point(minX, minY)
            };
        }
    }
}