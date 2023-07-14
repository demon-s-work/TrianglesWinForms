using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrianglesWinForms.Models;
using TrianglesWinForms.Services;

namespace TrianglesWinForms
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }

        private Node<AbstractPolygon> _rootNode;
        private Color _baseColor = Color.Pink;

        private void ImportButton_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            var inputService = new InputService();
            inputService.OnError += (o, s) => {
                ShowOutput(s);
            };

            var arrangeService = new ArrangeService();
            arrangeService.OnError += ArrangeService_Error;
            arrangeService.OnComplete += ArrangeService_Complete;

            var rawData = inputService.GetUserInput();
            if (rawData != null)
            {
                Task.Run(() => {
                    var parsedTriangles = inputService.ParseTriangles(rawData);
                    arrangeService.Arrange(parsedTriangles);
                });
            }
        }

        private void ArrangeService_Complete(object sender, Node<AbstractPolygon> node)
        {
            _rootNode = node;
            _rootNode.Paint(_baseColor);
            Canvas.Invoke(new MethodInvoker(delegate {
                Canvas.Refresh();
            }));
            var hues = _rootNode.Depth;
            ShowOutput($"Hues count: {hues}");
        }

        private void ClearCanvas()
        {
            _rootNode = null;
            Canvas.Refresh();
        }

        private void ArrangeService_Error(object sender, EventArgs e)
        {
            ShowOutput("ERROR");
        }

        private void ShowOutput(string output)
        {
            OutputLabel.Invoke(new MethodInvoker(delegate {
                OutputLabel.Text = output;
            }));
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (_rootNode == null)
            {
                return;
            }
            var xAspect = (float)Canvas.Height / ((CanvasPolygon)_rootNode.Content).H;
            var yAspect = (float)Canvas.Width / ((CanvasPolygon)_rootNode.Content).W;
            _rootNode.DrawScaled(e.Graphics, Math.Min(xAspect, yAspect));
        }

        private void Canvas_Resize(object sender, EventArgs e)
        {
            Canvas.Refresh();
        }

        private void ColorPick_Click(object sender, EventArgs e)
        {
            var d = new ColorDialog();
            if (d.ShowDialog() == DialogResult.OK)
            {
                _baseColor = d.Color;
            }
            _rootNode?.Paint(_baseColor);
            Canvas.Refresh();
        }
    }
}