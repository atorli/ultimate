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
            up_arrow = new WinFormsControlLibrary1.Arrow();
            down_arrow = new WinFormsControlLibrary1.Arrow();
            up_arrow_blink_timer = new System.Windows.Forms.Timer(components);
            down_arrow_blink_timer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // up_arrow
            // 
            up_arrow.ArrowDirection = WinFormsControlLibrary1.Arrow.Direction.Up;
            up_arrow.BackColor = Color.Transparent;
            up_arrow.Location = new Point(82, 73);
            up_arrow.Margin = new Padding(4);
            up_arrow.Name = "up_arrow";
            up_arrow.PaintColor = Color.Transparent;
            up_arrow.Size = new Size(50, 125);
            up_arrow.TabIndex = 2;
            // 
            // down_arrow
            // 
            down_arrow.ArrowDirection = WinFormsControlLibrary1.Arrow.Direction.Down;
            down_arrow.BackColor = Color.Transparent;
            down_arrow.Location = new Point(69, 318);
            down_arrow.Margin = new Padding(4);
            down_arrow.Name = "down_arrow";
            down_arrow.PaintColor = Color.Transparent;
            down_arrow.Size = new Size(50, 125);
            down_arrow.TabIndex = 3;
            // 
            // up_arrow_blink_timer
            // 
            up_arrow_blink_timer.Interval = 150;
            up_arrow_blink_timer.Tick += up_arrow_blink_timer_Tick;
            // 
            // down_arrow_blink_timer
            // 
            down_arrow_blink_timer.Interval = 150;
            down_arrow_blink_timer.Tick += down_arrow_blink_timer_Tick;
            // 
            // ModeBase
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(down_arrow);
            Controls.Add(up_arrow);
            Name = "ModeBase";
            Size = new Size(599, 500);
            SizeChanged += ModeBase_SizeChanged;
            ResumeLayout(false);
        }

        #endregion
        protected WinFormsControlLibrary1.Arrow up_arrow;
        protected WinFormsControlLibrary1.Arrow down_arrow;
        protected System.Windows.Forms.Timer up_arrow_blink_timer;
        protected System.Windows.Forms.Timer down_arrow_blink_timer;
    }
}
