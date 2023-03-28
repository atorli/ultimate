using System.Drawing.Drawing2D;

namespace WinFormsControlLibrary1
{
    partial class arrow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Point p1 = new Point();
        private Point p2 = new Point();
        private Point p3 = new Point();
        private Point p4 = new Point();
        private Point p5 = new Point();
        private Point p6 = new Point();
        private Point p7 = new Point();


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

        public Color paint_color { get; set; } = Color.Black;

        public float rotate_angle { get; set; } = 0; 


        protected override void OnPaint(PaintEventArgs e)
        {
            int half_height = this.Height / 2;
            p1.X = this.Width;
            p1.Y = half_height;
            p2.X = this.Width - half_height;
            p2.Y = 0;
            p3.X = p2.X;
            p3.Y = half_height / 2;
            p4.X = 0;
            p4.Y = p3.Y;
            p5.X = 0;
            p5.Y = p3.Y + half_height;
            p6.X = p2.X;
            p6.Y = p5.Y;
            p7.X = p2.X;
            p7.Y = this.Height;

            GraphicsPath path = new GraphicsPath();
            path.AddLine(p1,p2);
            path.AddLine(p2, p3);
            path.AddLine(p3, p4);
            path.AddLine(p4, p5);
            path.AddLine(p5, p6);
            path.AddLine(p6, p7);
            path.AddLine(p7, p1);

            // graphics.
            e.Graphics.SetClip(path);
            e.Graphics.RotateTransform(this.rotate_angle);
            e.Graphics.FillPath(new SolidBrush(paint_color),path);

        }


        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(100, 50);
        }

        #endregion
    }
}