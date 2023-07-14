using System.ComponentModel;
namespace TrianglesWinForms.Forms
{
    partial class ImportDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textImportTextBox = new System.Windows.Forms.TextBox();
            this.ImportDescriptionLabel = new System.Windows.Forms.Label();
            this.LoadFromFileButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.LoadedFileLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textImportTextBox
            // 
            this.textImportTextBox.AcceptsReturn = true;
            this.textImportTextBox.Location = new System.Drawing.Point(8, 38);
            this.textImportTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textImportTextBox.Multiline = true;
            this.textImportTextBox.Name = "textImportTextBox";
            this.textImportTextBox.ReadOnly = true;
            this.textImportTextBox.Size = new System.Drawing.Size(371, 186);
            this.textImportTextBox.TabIndex = 0;
            // 
            // ImportDescriptionLabel
            // 
            this.ImportDescriptionLabel.Location = new System.Drawing.Point(9, 10);
            this.ImportDescriptionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ImportDescriptionLabel.Name = "ImportDescriptionLabel";
            this.ImportDescriptionLabel.Size = new System.Drawing.Size(145, 21);
            this.ImportDescriptionLabel.TabIndex = 1;
            this.ImportDescriptionLabel.Text = "Import as text or load from file";
            // 
            // LoadFromFileButton
            // 
            this.LoadFromFileButton.Location = new System.Drawing.Point(159, 6);
            this.LoadFromFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadFromFileButton.Name = "LoadFromFileButton";
            this.LoadFromFileButton.Size = new System.Drawing.Size(83, 22);
            this.LoadFromFileButton.TabIndex = 2;
            this.LoadFromFileButton.Text = "open file";
            this.LoadFromFileButton.UseVisualStyleBackColor = true;
            this.LoadFromFileButton.Click += new System.EventHandler(this.LoadFromFileButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(294, 226);
            this.ImportButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(83, 22);
            this.ImportButton.TabIndex = 2;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // LoadedFileLabel
            // 
            this.LoadedFileLabel.Location = new System.Drawing.Point(246, 10);
            this.LoadedFileLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LoadedFileLabel.Name = "LoadedFileLabel";
            this.LoadedFileLabel.Size = new System.Drawing.Size(120, 15);
            this.LoadedFileLabel.TabIndex = 3;
            // 
            // ImportDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 256);
            this.Controls.Add(this.LoadedFileLabel);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.LoadFromFileButton);
            this.Controls.Add(this.ImportDescriptionLabel);
            this.Controls.Add(this.textImportTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportDataForm";
            this.ShowIcon = false;
            this.Text = "ImportDataForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Label LoadedFileLabel;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Label ImportDescriptionLabel;
        private System.Windows.Forms.Button LoadFromFileButton;
        private System.Windows.Forms.TextBox textImportTextBox;
        #endregion
    }
}