namespace ultimate
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
            main_layout = new TableLayoutPanel();
            info_display = new DataGridView();
            datetime = new DataGridViewTextBoxColumn();
            info = new DataGridViewTextBoxColumn();
            foot_status.SuspendLayout();
            main_layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)info_display).BeginInit();
            SuspendLayout();
            // 
            // foot_status
            // 
            foot_status.GripMargin = new Padding(0);
            foot_status.ImageScalingSize = new Size(20, 20);
            foot_status.Items.AddRange(new ToolStripItem[] { server_connect_stratus });
            foot_status.Location = new Point(0, 869);
            foot_status.Name = "foot_status";
            foot_status.Padding = new Padding(1, 0, 18, 0);
            foot_status.Size = new Size(1522, 26);
            foot_status.TabIndex = 1;
            foot_status.Text = "statusStrip1";
            // 
            // server_connect_stratus
            // 
            server_connect_stratus.DisplayStyle = ToolStripItemDisplayStyle.Text;
            server_connect_stratus.ForeColor = Color.Red;
            server_connect_stratus.Name = "server_connect_stratus";
            server_connect_stratus.Size = new Size(174, 20);
            server_connect_stratus.Text = "服务器连接状态：未连接";
            // 
            // blink_timer
            // 
            blink_timer.Interval = 400;
            blink_timer.Tick += blink_timer_Tick;
            // 
            // main_layout
            // 
            main_layout.ColumnCount = 2;
            main_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            main_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            main_layout.Controls.Add(info_display, 1, 0);
            main_layout.Dock = DockStyle.Fill;
            main_layout.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            main_layout.Location = new Point(0, 0);
            main_layout.Margin = new Padding(0);
            main_layout.Name = "main_layout";
            main_layout.RowCount = 1;
            main_layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            main_layout.Size = new Size(1522, 869);
            main_layout.TabIndex = 4;
            // 
            // info_display
            // 
            info_display.AllowUserToAddRows = false;
            info_display.BorderStyle = BorderStyle.None;
            info_display.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            info_display.Columns.AddRange(new DataGridViewColumn[] { datetime, info });
            info_display.Dock = DockStyle.Fill;
            info_display.Location = new Point(989, 0);
            info_display.Margin = new Padding(0);
            info_display.Name = "info_display";
            info_display.ReadOnly = true;
            info_display.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            info_display.RowHeadersVisible = false;
            info_display.RowHeadersWidth = 51;
            info_display.RowTemplate.Height = 25;
            info_display.Size = new Size(533, 869);
            info_display.TabIndex = 4;
            // 
            // datetime
            // 
            datetime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datetime.HeaderText = "时间";
            datetime.MinimumWidth = 6;
            datetime.Name = "datetime";
            datetime.ReadOnly = true;
            // 
            // info
            // 
            info.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            info.HeaderText = "信息";
            info.MinimumWidth = 6;
            info.Name = "info";
            info.ReadOnly = true;
            // 
            // main
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1522, 895);
            Controls.Add(main_layout);
            Controls.Add(foot_status);
            Margin = new Padding(4);
            Name = "main";
            StartPosition = FormStartPosition.CenterScreen;
            Shown += main_Shown;
            foot_status.ResumeLayout(false);
            foot_status.PerformLayout();
            main_layout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)info_display).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip foot_status;
        private ToolStripStatusLabel server_connect_stratus;
        private System.Windows.Forms.Timer blink_timer;
        private TableLayoutPanel main_layout;
        private DataGridView info_display;
        private DataGridViewTextBoxColumn datetime;
        private DataGridViewTextBoxColumn info;
    }
}