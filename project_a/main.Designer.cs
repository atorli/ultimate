﻿namespace ProjectA
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
            statusStrip1 = new StatusStrip();
            server_connect_stratus = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            文件ToolStripMenuItem = new ToolStripMenuItem();
            opc_item_table = new DataGridView();
            item_addr = new DataGridViewTextBoxColumn();
            value = new DataGridViewTextBoxColumn();
            splitContainer1 = new SplitContainer();
            pictureBox1 = new PictureBox();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)opc_item_table).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { server_connect_stratus });
            statusStrip1.Location = new Point(0, 739);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1184, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // server_connect_stratus
            // 
            server_connect_stratus.DisplayStyle = ToolStripItemDisplayStyle.Text;
            server_connect_stratus.ForeColor = Color.Red;
            server_connect_stratus.Name = "server_connect_stratus";
            server_connect_stratus.Size = new Size(140, 17);
            server_connect_stratus.Text = "服务器连接状态：未连接";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 文件ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1184, 25);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            文件ToolStripMenuItem.Size = new Size(44, 21);
            文件ToolStripMenuItem.Text = "文件";
            // 
            // opc_item_table
            // 
            opc_item_table.AllowUserToAddRows = false;
            dataGridViewCellStyle1.ForeColor = Color.Silver;
            opc_item_table.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            opc_item_table.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            opc_item_table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            opc_item_table.Columns.AddRange(new DataGridViewColumn[] { item_addr, value });
            opc_item_table.Dock = DockStyle.Fill;
            opc_item_table.Location = new Point(0, 0);
            opc_item_table.Name = "opc_item_table";
            opc_item_table.ReadOnly = true;
            opc_item_table.RowHeadersVisible = false;
            opc_item_table.RowTemplate.Height = 25;
            opc_item_table.Size = new Size(580, 714);
            opc_item_table.TabIndex = 3;
            // 
            // item_addr
            // 
            item_addr.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            item_addr.HeaderText = "地址";
            item_addr.Name = "item_addr";
            item_addr.ReadOnly = true;
            // 
            // value
            // 
            value.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            value.HeaderText = "值";
            value.Name = "value";
            value.ReadOnly = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 25);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(opc_item_table);
            splitContainer1.Size = new Size(1184, 714);
            splitContainer1.SplitterDistance = 600;
            splitContainer1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(600, 714);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 761);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ultimate";
            Shown += main_Shown;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)opc_item_table).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel server_connect_stratus;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private DataGridView opc_item_table;
        private DataGridViewTextBoxColumn item_addr;
        private DataGridViewTextBoxColumn value;
        private SplitContainer splitContainer1;
        private PictureBox pictureBox1;
    }
}