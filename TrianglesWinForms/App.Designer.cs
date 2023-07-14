using System.Windows.Forms;
namespace TrianglesWinForms
{
    partial class App
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.Canvas = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ColorPickButton = new System.Windows.Forms.Button();
            this.OutputLabel = new System.Windows.Forms.Label();
            this.ImportButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.AutoSize = true;
            this.Canvas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Canvas.Location = new System.Drawing.Point(100, 0);
            this.Canvas.Margin = new System.Windows.Forms.Padding(2);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(825, 696);
            this.Canvas.TabIndex = 3;
            this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
            this.Canvas.Resize += new System.EventHandler(this.Canvas_Resize);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.ColorPickButton);
            this.panel1.Controls.Add(this.OutputLabel);
            this.panel1.Controls.Add(this.ImportButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.MaximumSize = new System.Drawing.Size(150, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(100, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(100, 696);
            this.panel1.TabIndex = 0;
            // 
            // ColorPickButton
            // 
            this.ColorPickButton.AutoSize = true;
            this.ColorPickButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ColorPickButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ColorPickButton.Location = new System.Drawing.Point(10, 640);
            this.ColorPickButton.Margin = new System.Windows.Forms.Padding(0);
            this.ColorPickButton.Name = "ColorPickButton";
            this.ColorPickButton.Size = new System.Drawing.Size(80, 23);
            this.ColorPickButton.TabIndex = 2;
            this.ColorPickButton.Text = "Pick color";
            this.ColorPickButton.UseVisualStyleBackColor = true;
            this.ColorPickButton.Click += new System.EventHandler(this.ColorPickClick);
            // 
            // OutputLabel
            // 
            this.OutputLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.OutputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OutputLabel.ForeColor = System.Drawing.Color.Black;
            this.OutputLabel.Location = new System.Drawing.Point(10, 10);
            this.OutputLabel.Name = "OutputLabel";
            this.OutputLabel.Size = new System.Drawing.Size(80, 155);
            this.OutputLabel.TabIndex = 1;
            // 
            // ImportButton
            // 
            this.ImportButton.AutoSize = true;
            this.ImportButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ImportButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ImportButton.Location = new System.Drawing.Point(10, 663);
            this.ImportButton.Margin = new System.Windows.Forms.Padding(0);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(80, 23);
            this.ImportButton.TabIndex = 0;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.LoadTriangles_Click);
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(925, 696);
            this.Controls.Add(this.Canvas);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(918, 519);
            this.Name = "App";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button ColorPickButton;
        private System.Windows.Forms.Label OutputLabel;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Canvas;
        #endregion
    }
}