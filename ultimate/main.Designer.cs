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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            foot_status = new StatusStrip();
            server_connect_stratus = new ToolStripStatusLabel();
            current_label = new ToolStripStatusLabel();
            rising_time = new ToolStripStatusLabel();
            right_vertical_spliter = new SplitContainer();
            info_display = new DataGridView();
            info_datetime = new DataGridViewTextBoxColumn();
            info_message = new DataGridViewTextBoxColumn();
            warn_display = new DataGridView();
            warn_datetime = new DataGridViewTextBoxColumn();
            warn_message = new DataGridViewTextBoxColumn();
            main_layout = new SplitContainer();
            foot_status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)right_vertical_spliter).BeginInit();
            right_vertical_spliter.Panel1.SuspendLayout();
            right_vertical_spliter.Panel2.SuspendLayout();
            right_vertical_spliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)info_display).BeginInit();
            ((System.ComponentModel.ISupportInitialize)warn_display).BeginInit();
            ((System.ComponentModel.ISupportInitialize)main_layout).BeginInit();
            main_layout.Panel2.SuspendLayout();
            main_layout.SuspendLayout();
            SuspendLayout();
            // 
            // foot_status
            // 
            foot_status.GripMargin = new Padding(0);
            foot_status.ImageScalingSize = new Size(20, 20);
            foot_status.Items.AddRange(new ToolStripItem[] { server_connect_stratus, current_label, rising_time });
            foot_status.Location = new Point(2, 731);
            foot_status.Name = "foot_status";
            foot_status.Size = new Size(1180, 28);
            foot_status.TabIndex = 1;
            foot_status.Text = "statusStrip1";
            // 
            // server_connect_stratus
            // 
            server_connect_stratus.BorderSides = ToolStripStatusLabelBorderSides.Right;
            server_connect_stratus.BorderStyle = Border3DStyle.Raised;
            server_connect_stratus.DisplayStyle = ToolStripItemDisplayStyle.Text;
            server_connect_stratus.Font = new Font("Microsoft YaHei UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            server_connect_stratus.ForeColor = Color.Red;
            server_connect_stratus.Margin = new Padding(0);
            server_connect_stratus.Name = "server_connect_stratus";
            server_connect_stratus.Size = new Size(212, 28);
            server_connect_stratus.Text = "服务器连接状态：未连接";
            // 
            // current_label
            // 
            current_label.BorderSides = ToolStripStatusLabelBorderSides.Right;
            current_label.BorderStyle = Border3DStyle.Raised;
            current_label.Font = new Font("Microsoft YaHei UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            current_label.ForeColor = Color.Green;
            current_label.Margin = new Padding(0);
            current_label.Name = "current_label";
            current_label.Size = new Size(140, 28);
            current_label.Text = "当前电流：N/A";
            // 
            // rising_time
            // 
            rising_time.BorderSides = ToolStripStatusLabelBorderSides.Right;
            rising_time.BorderStyle = Border3DStyle.Raised;
            rising_time.Font = new Font("Microsoft YaHei UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            rising_time.ForeColor = Color.Green;
            rising_time.Margin = new Padding(0);
            rising_time.Name = "rising_time";
            rising_time.Size = new Size(140, 28);
            rising_time.Text = "上升时间：N/A";
            rising_time.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // right_vertical_spliter
            // 
            right_vertical_spliter.Dock = DockStyle.Fill;
            right_vertical_spliter.Location = new Point(0, 0);
            right_vertical_spliter.Margin = new Padding(2, 3, 2, 3);
            right_vertical_spliter.Name = "right_vertical_spliter";
            right_vertical_spliter.Orientation = Orientation.Horizontal;
            // 
            // right_vertical_spliter.Panel1
            // 
            right_vertical_spliter.Panel1.Controls.Add(info_display);
            // 
            // right_vertical_spliter.Panel2
            // 
            right_vertical_spliter.Panel2.Controls.Add(warn_display);
            right_vertical_spliter.Size = new Size(580, 695);
            right_vertical_spliter.SplitterDistance = 341;
            right_vertical_spliter.SplitterWidth = 3;
            right_vertical_spliter.TabIndex = 5;
            // 
            // info_display
            // 
            info_display.AllowUserToAddRows = false;
            info_display.BackgroundColor = SystemColors.ControlLight;
            info_display.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            info_display.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            info_display.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            info_display.Columns.AddRange(new DataGridViewColumn[] { info_datetime, info_message });
            info_display.Dock = DockStyle.Fill;
            info_display.Location = new Point(0, 0);
            info_display.Margin = new Padding(0);
            info_display.Name = "info_display";
            info_display.ReadOnly = true;
            info_display.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            info_display.RowHeadersVisible = false;
            info_display.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point);
            info_display.RowsDefaultCellStyle = dataGridViewCellStyle2;
            info_display.RowTemplate.Height = 25;
            info_display.Size = new Size(580, 341);
            info_display.TabIndex = 4;
            // 
            // info_datetime
            // 
            info_datetime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            info_datetime.HeaderText = "时间";
            info_datetime.MinimumWidth = 6;
            info_datetime.Name = "info_datetime";
            info_datetime.ReadOnly = true;
            // 
            // info_message
            // 
            info_message.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            info_message.HeaderText = "信息";
            info_message.MinimumWidth = 6;
            info_message.Name = "info_message";
            info_message.ReadOnly = true;
            // 
            // warn_display
            // 
            warn_display.AllowDrop = true;
            warn_display.AllowUserToAddRows = false;
            warn_display.AllowUserToDeleteRows = false;
            warn_display.BackgroundColor = SystemColors.ControlLight;
            warn_display.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            warn_display.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            warn_display.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            warn_display.Columns.AddRange(new DataGridViewColumn[] { warn_datetime, warn_message });
            warn_display.Dock = DockStyle.Fill;
            warn_display.Location = new Point(0, 0);
            warn_display.Margin = new Padding(2, 3, 2, 3);
            warn_display.Name = "warn_display";
            warn_display.ReadOnly = true;
            warn_display.RowHeadersVisible = false;
            warn_display.RowHeadersWidth = 51;
            dataGridViewCellStyle4.Font = new Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.Red;
            warn_display.RowsDefaultCellStyle = dataGridViewCellStyle4;
            warn_display.RowTemplate.Height = 29;
            warn_display.Size = new Size(580, 351);
            warn_display.TabIndex = 0;
            // 
            // warn_datetime
            // 
            warn_datetime.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            warn_datetime.HeaderText = "时间";
            warn_datetime.MinimumWidth = 6;
            warn_datetime.Name = "warn_datetime";
            warn_datetime.ReadOnly = true;
            // 
            // warn_message
            // 
            warn_message.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            warn_message.HeaderText = "信息";
            warn_message.MinimumWidth = 6;
            warn_message.Name = "warn_message";
            warn_message.ReadOnly = true;
            // 
            // main_layout
            // 
            main_layout.Dock = DockStyle.Fill;
            main_layout.Location = new Point(2, 36);
            main_layout.Name = "main_layout";
            // 
            // main_layout.Panel2
            // 
            main_layout.Panel2.Controls.Add(right_vertical_spliter);
            main_layout.Size = new Size(1180, 695);
            main_layout.SplitterDistance = 597;
            main_layout.SplitterWidth = 3;
            main_layout.TabIndex = 6;
            // 
            // main
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1184, 761);
            Controls.Add(main_layout);
            Controls.Add(foot_status);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "main";
            Padding = new Padding(2, 36, 2, 2);
            ShowDragStretch = true;
            ShowTitleIcon = true;
            Style = Sunny.UI.UIStyle.Custom;
            Text = "XE08门板末检机";
            TitleFont = new Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ZoomScaleRect = new Rectangle(15, 15, 1184, 761);
            Shown += main_Shown;
            foot_status.ResumeLayout(false);
            foot_status.PerformLayout();
            right_vertical_spliter.Panel1.ResumeLayout(false);
            right_vertical_spliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)right_vertical_spliter).EndInit();
            right_vertical_spliter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)info_display).EndInit();
            ((System.ComponentModel.ISupportInitialize)warn_display).EndInit();
            main_layout.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)main_layout).EndInit();
            main_layout.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip foot_status;
        private DataGridView info_display;
        private SplitContainer right_vertical_spliter;
        private DataGridView warn_display;
        private DataGridViewTextBoxColumn info_datetime;
        private DataGridViewTextBoxColumn info_message;
        private DataGridViewTextBoxColumn warn_datetime;
        private DataGridViewTextBoxColumn warn_message;
        private ToolStripStatusLabel server_connect_stratus;
        private ToolStripStatusLabel current_label;
        private ToolStripStatusLabel rising_time;
        private SplitContainer main_layout;
    }
}