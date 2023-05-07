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
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle23 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle24 = new DataGridViewCellStyle();
            foot_status = new StatusStrip();
            server_connect_stratus = new ToolStripStatusLabel();
            current_label = new ToolStripStatusLabel();
            main_layout = new TableLayoutPanel();
            right_vertical_spliter = new SplitContainer();
            info_display = new DataGridView();
            info_datetime = new DataGridViewTextBoxColumn();
            info_message = new DataGridViewTextBoxColumn();
            warn_display = new DataGridView();
            warn_datetime = new DataGridViewTextBoxColumn();
            warn_message = new DataGridViewTextBoxColumn();
            rising_time = new ToolStripStatusLabel();
            foot_status.SuspendLayout();
            main_layout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)right_vertical_spliter).BeginInit();
            right_vertical_spliter.Panel1.SuspendLayout();
            right_vertical_spliter.Panel2.SuspendLayout();
            right_vertical_spliter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)info_display).BeginInit();
            ((System.ComponentModel.ISupportInitialize)warn_display).BeginInit();
            SuspendLayout();
            // 
            // foot_status
            // 
            foot_status.GripMargin = new Padding(0);
            foot_status.ImageScalingSize = new Size(20, 20);
            foot_status.Items.AddRange(new ToolStripItem[] { server_connect_stratus, current_label, rising_time });
            foot_status.Location = new Point(0, 859);
            foot_status.Name = "foot_status";
            foot_status.Padding = new Padding(1, 0, 18, 0);
            foot_status.Size = new Size(1522, 36);
            foot_status.TabIndex = 1;
            foot_status.Text = "statusStrip1";
            // 
            // server_connect_stratus
            // 
            server_connect_stratus.DisplayStyle = ToolStripItemDisplayStyle.Text;
            server_connect_stratus.Font = new Font("Microsoft YaHei UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            server_connect_stratus.ForeColor = Color.Red;
            server_connect_stratus.Name = "server_connect_stratus";
            server_connect_stratus.Size = new Size(255, 30);
            server_connect_stratus.Text = "服务器连接状态：未连接";
            // 
            // current_label
            // 
            current_label.Font = new Font("Microsoft YaHei UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            current_label.ForeColor = Color.Green;
            current_label.Name = "current_label";
            current_label.Size = new Size(165, 30);
            current_label.Text = "当前电流：N/A";
            // 
            // main_layout
            // 
            main_layout.ColumnCount = 2;
            main_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            main_layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            main_layout.Controls.Add(right_vertical_spliter, 1, 0);
            main_layout.Dock = DockStyle.Fill;
            main_layout.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            main_layout.Location = new Point(0, 0);
            main_layout.Margin = new Padding(0);
            main_layout.Name = "main_layout";
            main_layout.RowCount = 1;
            main_layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            main_layout.Size = new Size(1522, 859);
            main_layout.TabIndex = 4;
            // 
            // right_vertical_spliter
            // 
            right_vertical_spliter.Dock = DockStyle.Fill;
            right_vertical_spliter.Location = new Point(840, 3);
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
            right_vertical_spliter.Size = new Size(679, 853);
            right_vertical_spliter.SplitterDistance = 423;
            right_vertical_spliter.TabIndex = 5;
            // 
            // info_display
            // 
            info_display.AllowUserToAddRows = false;
            info_display.BackgroundColor = SystemColors.ControlLight;
            info_display.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle21.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = SystemColors.Control;
            dataGridViewCellStyle21.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle21.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = DataGridViewTriState.True;
            info_display.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
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
            dataGridViewCellStyle22.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            info_display.RowsDefaultCellStyle = dataGridViewCellStyle22;
            info_display.RowTemplate.Height = 25;
            info_display.Size = new Size(679, 423);
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
            dataGridViewCellStyle23.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = SystemColors.Control;
            dataGridViewCellStyle23.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle23.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = DataGridViewTriState.True;
            warn_display.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            warn_display.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            warn_display.Columns.AddRange(new DataGridViewColumn[] { warn_datetime, warn_message });
            warn_display.Dock = DockStyle.Fill;
            warn_display.Location = new Point(0, 0);
            warn_display.Name = "warn_display";
            warn_display.ReadOnly = true;
            warn_display.RowHeadersVisible = false;
            warn_display.RowHeadersWidth = 51;
            dataGridViewCellStyle24.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle24.ForeColor = Color.Red;
            warn_display.RowsDefaultCellStyle = dataGridViewCellStyle24;
            warn_display.RowTemplate.Height = 29;
            warn_display.Size = new Size(679, 426);
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
            // rising_time
            // 
            rising_time.Font = new Font("Microsoft YaHei UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            rising_time.ForeColor = Color.Green;
            rising_time.Name = "rising_time";
            rising_time.Size = new Size(165, 30);
            rising_time.Text = "上升时间：N/A";
            rising_time.TextAlign = ContentAlignment.MiddleLeft;
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
            WindowState = FormWindowState.Maximized;
            Shown += main_Shown;
            foot_status.ResumeLayout(false);
            foot_status.PerformLayout();
            main_layout.ResumeLayout(false);
            right_vertical_spliter.Panel1.ResumeLayout(false);
            right_vertical_spliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)right_vertical_spliter).EndInit();
            right_vertical_spliter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)info_display).EndInit();
            ((System.ComponentModel.ISupportInitialize)warn_display).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip foot_status;
        private TableLayoutPanel main_layout;
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
    }
}