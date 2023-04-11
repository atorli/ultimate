using System.Drawing.Drawing2D;

namespace WinFormsControlLibrary1
{
    partial class Arrow
    {
        #region Component Designer generated code

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

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Arrow
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Margin = new Padding(4, 4, 4, 4);
            Name = "Arrow";
            Size = new Size(129, 118);
            ResumeLayout(false);
        }

        #endregion

        /// <summary>
        /// 绘制箭头的点
        /// </summary>
        private Point p1 = new Point();
        private Point p2 = new Point();
        private Point p3 = new Point();
        private Point p4 = new Point();
        private Point p5 = new Point();
        private Point p6 = new Point();
        private Point p7 = new Point();

        /// <summary>
        /// 控制箭头绘制的颜色
        /// </summary>
        private Color _paint_color;

        /// <summary>
        /// 控制箭头的方向
        /// </summary>
        public enum Direction
        {
            Right,
            Left,
            Up,
            Down
        }

        /// <summary>
        /// 箭头绘制颜色
        /// </summary>
        public Color PaintColor
        {
            get
            {
                return _paint_color;
            }
            set
            {
                _paint_color = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// 箭头方向
        /// </summary>
        public Direction ArrowDirection { get; set; } = Direction.Right;

        /// <summary>
        /// 绘制箭头
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            int half_height = this.Height / 2;
            switch (ArrowDirection)
            {
                case Direction.Right:
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
                    break;
                case Direction.Left:
                    p1.X = 0;
                    p1.Y = half_height;
                    p2.X = half_height;
                    p2.Y = this.Height;
                    p3.X = p2.X;
                    p3.Y = half_height + half_height / 2;
                    p4.X = Width;
                    p4.Y = p3.Y;
                    p5.X = Width;
                    p5.Y = half_height / 2;
                    p6.X = p2.X;
                    p6.Y = p5.Y;
                    p7.X = p2.X;
                    p7.Y = 0;
                    break;
                case Direction.Up:
                    p1.X = Width / 2;
                    p1.Y = 0;
                    p2.X = 0;
                    p2.Y = Width / 2;
                    p3.X = Width / 4;
                    p3.Y = p2.Y;
                    p4.X = p3.X;
                    p4.Y = Height;
                    p5.X = Width / 4 + Width / 2;
                    p5.Y = p4.Y;
                    p6.X = p5.X;
                    p6.Y = p3.Y;
                    p7.X = Width;
                    p7.Y = p6.Y;
                    break;
                case Direction.Down:
                    p1.X = Width / 2;
                    p1.Y = Height;
                    p2.X = 0;
                    p2.Y = Height - (Width / 2);
                    p3.X = Width / 4;
                    p3.Y = p2.Y;
                    p4.X = p3.X;
                    p4.Y = 0;
                    p5.X = Width / 4 + Width / 2;
                    p5.Y = p4.Y;
                    p6.X = p5.X;
                    p6.Y = p3.Y;
                    p7.X = Width;
                    p7.Y = p6.Y;
                    break;
            }

            GraphicsPath path = new GraphicsPath();
            path.AddLine(p1, p2);
            path.AddLine(p2, p3);
            path.AddLine(p3, p4);
            path.AddLine(p4, p5);
            path.AddLine(p5, p6);
            path.AddLine(p6, p7);
            path.AddLine(p7, p1);
            // graphics.
            e.Graphics.SetClip(path);
            e.Graphics.FillPath(new SolidBrush(PaintColor), path);

        }

    }
}