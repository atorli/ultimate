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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            foot_status = new StatusStrip();
            server_connect_stratus = new ToolStripStatusLabel();
            opc_item_table = new DataGridView();
            item_addr = new DataGridViewTextBoxColumn();
            desc = new DataGridViewTextBoxColumn();
            value = new DataGridViewTextBoxColumn();
            vertical_spliter = new SplitContainer();
            arrow1 = new WinFormsControlLibrary1.Arrow();
            menu = new MenuStrip();
            blink_timer = new System.Windows.Forms.Timer(components);
            foot_status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)opc_item_table).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vertical_spliter).BeginInit();
            vertical_spliter.Panel1.SuspendLayout();
            vertical_spliter.Panel2.SuspendLayout();
            vertical_spliter.SuspendLayout();
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
            // opc_item_table
            // 
            opc_item_table.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            opc_item_table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            opc_item_table.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            opc_item_table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            opc_item_table.Columns.AddRange(new DataGridViewColumn[] { item_addr, desc, value });
            opc_item_table.Dock = DockStyle.Fill;
            opc_item_table.Location = new Point(0, 0);
            opc_item_table.Name = "opc_item_table";
            opc_item_table.ReadOnly = true;
            opc_item_table.RowHeadersVisible = false;
            opc_item_table.RowTemplate.Height = 25;
            opc_item_table.Size = new Size(580, 715);
            opc_item_table.TabIndex = 3;
            // 
            // item_addr
            // 
            item_addr.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            item_addr.HeaderText = "地址";
            item_addr.Name = "item_addr";
            item_addr.ReadOnly = true;
            // 
            // desc
            // 
            desc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            desc.HeaderText = "描述";
            desc.Name = "desc";
            desc.ReadOnly = true;
            // 
            // value
            // 
            value.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            value.HeaderText = "值";
            value.Name = "value";
            value.ReadOnly = true;
            // 
            // vertical_spliter
            // 
            vertical_spliter.Dock = DockStyle.Fill;
            vertical_spliter.Location = new Point(0, 24);
            vertical_spliter.Name = "vertical_spliter";
            // 
            // vertical_spliter.Panel1
            // 
            vertical_spliter.Panel1.Controls.Add(arrow1);
            // 
            // vertical_spliter.Panel2
            // 
            vertical_spliter.Panel2.Controls.Add(opc_item_table);
            vertical_spliter.Size = new Size(1184, 715);
            vertical_spliter.SplitterDistance = 600;
            vertical_spliter.TabIndex = 4;
            // 
            // arrow1
            // 
            arrow1.ArrowDirection = WinFormsControlLibrary1.Arrow.Direction.Right;
            arrow1.Location = new Point(213, 133);
            arrow1.Name = "arrow1";
            arrow1.PaintColor = Color.Transparent;
            arrow1.Size = new Size(158, 100);
            arrow1.TabIndex = 0;
            // 
            // menu
            // 
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(1184, 24);
            menu.TabIndex = 2;
            menu.Text = "menuStrip1";
            // 
            // blink_timer
            // 
            blink_timer.Enabled = true;
            blink_timer.Interval = 400;
            blink_timer.Tick += blink_timer_Tick;
            // 
            // main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(vertical_spliter);
            Controls.Add(foot_status);
            Controls.Add(menu);
            MainMenuStrip = menu;
            Name = "main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ultimate";
            Shown += main_Shown;
            foot_status.ResumeLayout(false);
            foot_status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)opc_item_table).EndInit();
            vertical_spliter.Panel1.ResumeLayout(false);
            vertical_spliter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)vertical_spliter).EndInit();
            vertical_spliter.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip foot_status;
        private ToolStripStatusLabel server_connect_stratus;
        private DataGridView opc_item_table;
        private SplitContainer vertical_spliter;
        private DataGridViewTextBoxColumn item_addr;
        private DataGridViewTextBoxColumn desc;
        private DataGridViewTextBoxColumn value;
        private MenuStrip menu;
        private System.Windows.Forms.Timer blink_timer;
        private WinFormsControlLibrary1.Arrow arrow1;
    }
}