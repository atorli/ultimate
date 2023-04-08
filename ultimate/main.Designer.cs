namespace ProjectA
{
    partial class main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            foot_status = new StatusStrip();
            server_connect_stratus = new ToolStripStatusLabel();
            blink_timer = new System.Windows.Forms.Timer(components);
            picture_box = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            info_display = new ListBox();
            foot_status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picture_box).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // foot_status
            // 
            foot_status.Items.AddRange(new ToolStripItem[] { server_connect_stratus });
            foot_status.Location = new Point(0, 739);
            foot_status.Name = "foot_status";
            foot_status.Size = new Size(1184, 22);
            foot_status.TabIndex = 1;
            foot_status.Text = "statusStrip1";
            // 
            // server_connect_stratus
            // 
            server_connect_stratus.DisplayStyle = ToolStripItemDisplayStyle.Text;
            server_connect_stratus.ForeColor = Color.Red;
            server_connect_stratus.Name = "server_connect_stratus";
            server_connect_stratus.Size = new Size(140, 17);
            server_connect_stratus.Text = "服务器连接状态：未连接";
            // 
            // blink_timer
            // 
            blink_timer.Interval = 400;
            blink_timer.Tick += blink_timer_Tick;
            // 
            // picture_box
            // 
            picture_box.Dock = DockStyle.Fill;
            picture_box.Location = new Point(0, 0);
            picture_box.Margin = new Padding(0);
            picture_box.Name = "picture_box";
            picture_box.Size = new Size(769, 739);
            picture_box.SizeMode = PictureBoxSizeMode.Zoom;
            picture_box.TabIndex = 3;
            picture_box.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.Controls.Add(picture_box, 0, 0);
            tableLayoutPanel1.Controls.Add(info_display, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1184, 739);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // info_display
            // 
            info_display.Dock = DockStyle.Fill;
            info_display.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            info_display.FormattingEnabled = true;
            info_display.ItemHeight = 27;
            info_display.Location = new Point(772, 3);
            info_display.Name = "info_display";
            info_display.Size = new Size(409, 733);
            info_display.TabIndex = 4;
            // 
            // main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(foot_status);
            Name = "main";
            StartPosition = FormStartPosition.CenterScreen;
            Shown += main_Shown;
            foot_status.ResumeLayout(false);
            foot_status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picture_box).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip foot_status;
        private ToolStripStatusLabel server_connect_stratus;
        private System.Windows.Forms.Timer blink_timer;
        private PictureBox picture_box;
        private TableLayoutPanel tableLayoutPanel1;
        private ListBox info_display;
    }
}