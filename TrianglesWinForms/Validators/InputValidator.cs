using System.Collections.Generic;
namespace TrianglesWinForms.Validators
{
    public class InputValidator
    {
        public bool ValidateInput(List<string> input)
        {
            if (!int.TryParse(input[0], out var count))
            {
                return false;
            }

            if (input.Count - 1 != count)
            {
                return false;
            }
            
            for (int i = 1; i <= count; i++)
            {
                if (!ValidateString(input[i]))
                {
                    return false;
                }
            }
                
            return true;
        }

        private bool ValidateString(string line)
        {
            return line.Split(' ').Length == 6;
        }
    }
}