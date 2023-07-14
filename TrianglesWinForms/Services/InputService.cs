using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TrianglesWinForms.Forms;
using TrianglesWinForms.Models;
namespace TrianglesWinForms.Services
{
    public class InputService
    {
        public event EventHandler<string> OnError;
        public List<string> GetUserInput()
        {
            List<string> trianglesData;
            bool inputResult = true;

            var importForm = new ImportDataForm();
            if (importForm.ShowDialog() == DialogResult.OK)
            {
                trianglesData = importForm.ImportedData;
            }
            else
            {
                Error("Input Error");
                return null;
            }

            trianglesData.RemoveAt(0);
            return trianglesData;
        }

        public List<Triangle> ParseTriangles(List<string> rawData)
        {
            if (rawData == null)
            {
                Error("Parse error");
                return null;
            }
            
            List<Triangle> parsedData = new List<Triangle>();
            foreach (var triangle in rawData)
            {
                bool parseResult = true;

                var points = triangle.Split(' ');
                parseResult &= int.TryParse(points[0], out var aX);
                parseResult &= int.TryParse(points[1], out var aY);
                parseResult &= int.TryParse(points[2], out var bX);
                parseResult &= int.TryParse(points[3], out var bY);
                parseResult &= int.TryParse(points[4], out var cX);
                parseResult &= int.TryParse(points[5], out var cY);

                if (!parseResult)
                {
                    Error("Parse error");
                    return null;
                }

                var a = new Point(aX, aY);
                var b = new Point(bX, bY);
                var c = new Point(cX, cY);

                parsedData.Add(new Triangle
                {
                    A = a,
                    B = b,
                    C = c,
                });
            }

            return parsedData;
        }
        
        private void Error(string message) {
            if (OnError != null)
            {
                OnError.Invoke(this, message);
            }
        }
    }
}