using System;
using System.Collections.Generic;
using System.Drawing;
using TrianglesWinForms.Models;
namespace TrianglesWinForms.Services
{
    public class ArrangeService
    {
        public event EventHandler OnError;
        public event EventHandler<CovariantNode<CanvasShape,Triangle>>OnComplete;
        public void Arrange(List<Triangle> triangles)
        {
            if (triangles == null)
            {
                return;
            }

            var root = new Node<Triangle>()
            {
                Content = triangles[0]
            };

            foreach (var tr in triangles)
            {
                if (tr.IsInside(root.Content))
                {
                    var localRoot = root;
                    var nodeState = NodeState.NotArranged;
                    while (localRoot.Childs.Count > 0 || nodeState == NodeState.LocalRootChanged)
                    {
                        nodeState = NodeState.NotArranged;
                        foreach (var rootChild in localRoot.Childs)
                        {
                            if (tr.IsInside(rootChild.Content))
                            {
                                localRoot = rootChild;
                                nodeState = NodeState.LocalRootChanged;
                                break;
                            }
                            if (rootChild.Content.IsInside(tr))
                            {
                                localRoot.Childs.Remove(rootChild);
                                localRoot.Childs.Add(new Node<Triangle>
                                {
                                    Content = tr,
                                    Childs = { rootChild }
                                });

                                nodeState = NodeState.Arranged;
                                break;
                            }
                            if (rootChild.Content.IsCrosses(tr))
                            {
                                Error();
                                return;
                            }
                        }

                        if (nodeState == NodeState.Arranged)
                        {
                            break;
                        }

                        if (nodeState == NodeState.LocalRootChanged)
                        {
                            continue;
                        }

                        localRoot.Childs.Add(new Node<Triangle>
                        {
                            Content = tr
                        });
                        break;
                    }
                }
                else if (root.Content.IsInside(tr))
                {
                    var newRoot = new Node<Triangle>
                    {
                        Childs = new List<Node<Triangle>> { root },
                        Content = tr
                    };

                    root = newRoot;
                }
                else if (root.Content.IsCrosses(tr))
                {
                    Error();
                    return;
                }
            }
            
            var canvasNode = new CovariantNode<CanvasShape, Triangle>()
            {
                Content = GetBoundingBox(root.Content),
                Childs = new List<Node<Triangle>> { root }
            };

            Complete(canvasNode);
        }
        private void Complete(CovariantNode<CanvasShape,Triangle> root)
        {
            if (OnComplete != null)
            {
                OnComplete.Invoke(this, root);
            }
        }

        private void Error()
        {
            if (OnError != null)
            {
                OnError.Invoke(this, EventArgs.Empty);
            }
        }

        private CanvasShape GetBoundingBox(Triangle tr)
        {
            var minX = Math.Min(tr.A.X, Math.Min(tr.B.X, tr.C.X));
            var maxX = Math.Max(tr.A.X, Math.Max(tr.B.X, tr.C.X));
            var minY = Math.Min(tr.A.Y, Math.Min(tr.B.Y, tr.C.Y));
            var maxY = Math.Max(tr.A.Y, Math.Max(tr.B.Y, tr.C.Y));

            return new CanvasShape
            {
                A = new Point(minX, maxY),
                B = new Point(maxX, maxY),
                C = new Point(maxX, minY),
                D = new Point(minX, minY)
            };
        }
    }
}