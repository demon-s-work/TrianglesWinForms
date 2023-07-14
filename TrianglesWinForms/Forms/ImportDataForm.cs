using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TrianglesWinForms.Validators;
namespace TrianglesWinForms.Forms
{
    public partial class ImportDataForm : Form
    {
        public List<string> ImportedData;
        private readonly string FileFilter = "txt files (*.txt)|*.txt";

        public ImportDataForm()
        {
            InitializeComponent();
        }
        private void LoadFromFileButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = FileFilter;
            fileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            List<string> imported = new List<string>();
            var dialResult = fileDialog.ShowDialog();
            if (dialResult == DialogResult.OK)
            {
                try
                {
                    imported = File.ReadLines(fileDialog.FileName).ToList();
                }
                catch (Exception)
                {
                    DialogResult = DialogResult.Abort;
                    Close();
                    return;
                }
            }
            else
            {
                return;
            }

            var validator = new InputValidator();
            if (!validator.ValidateInput(imported))
            {
                return;
            }

            ImportedData = imported;

            LoadedFileLabel.Text = $"Loaded: {fileDialog.SafeFileName}";
            SetFilePreview(imported);

        }

        private void SetFilePreview(IEnumerable<string> fileStrings)
        {
            textImportTextBox.Text = $"Preview\r\n{String.Join("\r\n", fileStrings)}";
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (ImportedData != null)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}