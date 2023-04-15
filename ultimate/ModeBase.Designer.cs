namespace ultimate
{
    partial class ModeBase
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            UpArrow = new WinFormsControlLibrary1.Arrow();
            DownArrow = new WinFormsControlLibrary1.Arrow();
            blink_timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // UpArrow
            // 
            UpArrow.ArrowDirection = WinFormsControlLibrary1.Arrow.Direction.Up;
            UpArrow.BackColor = Color.Transparent;
            UpArrow.Location = new Point(82, 73);
            UpArrow.Margin = new Padding(4);
            UpArrow.Name = "UpArrow";
            UpArrow.PaintColor = Color.Transparent;
            UpArrow.Size = new Size(50, 125);
            UpArrow.TabIndex = 2;
            // 
            // DownArrow
            // 
            DownArrow.ArrowDirection = WinFormsControlLibrary1.Arrow.Direction.Down;
            DownArrow.BackColor = Color.Transparent;
            DownArrow.Location = new Point(69, 318);
            DownArrow.Margin = new Padding(4);
            DownArrow.Name = "DownArrow";
            DownArrow.PaintColor = Color.Transparent;
            DownArrow.Size = new Size(50, 125);
            DownArrow.TabIndex = 3;
            // 
            // blink_timer
            // 
            blink_timer.Interval = 500;
            blink_timer.Tick += blink_timer_Tick;
            // 
            // ModeBase
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DownArrow);
            Controls.Add(UpArrow);
            Name = "ModeBase";
            Size = new Size(599, 500);
            ResumeLayout(false);
        }

        #endregion
        protected WinFormsControlLibrary1.Arrow UpArrow;
        protected WinFormsControlLibrary1.Arrow DownArrow;
        protected System.Windows.Forms.Timer blink_timer;
    }
}
