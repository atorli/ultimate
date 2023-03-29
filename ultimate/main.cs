using OPCAutomation;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using NLog;
using project_a.modules.file_parse;
using System.Data;

namespace ProjectA
{
    public partial class main : Form
    {
        private OPCServer _server;
        private OPCGroups? _groups;
        private OPCGroup? _group;
        private OPCItems? _items;
        private IConfigurationRoot _root;
        private NLog.Logger _logger;
        private DataTable? _dt;

        public main(IConfigurationRoot root, NLog.Logger logger)
        {
            InitializeComponent();
            _root = root;
            _logger = logger;
            _server = new OPCServer();
        }

        private void Group_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            for (int i = 1; i <= NumItems; i++)
            {
                object? idx = ClientHandles.GetValue(i);
                if (idx is not null)
                {
                    this.opc_item_table.Rows[(int)idx].Cells[2].Value = ItemValues.GetValue(i);
                }
            }
        }

        /// <summary>
        /// 当主界面第一次显示时，开始连接服务器，并且开始做一些
        /// 监听数据的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void main_Shown(object sender, EventArgs e)
        {
            try
            {
                _server.Connect(_root["server_name"]);
                if (_server.ServerState == (int)OPCServerState.OPCRunning)
                {
                    this.server_connect_stratus.Text = "服务器连接状态：已连接";
                    this.server_connect_stratus.ForeColor = Color.Green;

                    _groups = _server.OPCGroups;
                    _groups.DefaultGroupDeadband = 0;
                    _groups.DefaultGroupIsActive = true;
                    _groups.DefaultGroupUpdateRate = 250;

                    OPCGroup group = _groups.Add("group1");
                    group.IsSubscribed = true;
                    group.DataChange += Group_DataChange;

                    _items = group.OPCItems;
                }
                else
                {
                    //连接失败
                    _logger.Error($"连接KepServer失败,服务端的状态为:{Enum.GetName<OPCServerState>((OPCServerState)_server.ServerState)}");
                }
            }
            catch (Exception ex)
            {
                //连接失败
                _logger.Error($"连接KepServer失败，{ex.Message}.请检查Kepserver是否正常运行以及配置文件中的服务器名称是否正确!");
            }
        }

        private void import_csv_file_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "csv文件(*.csv)|*.csv";

                int idx = 0;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (_items is not null)
                    {
                        _dt = csv_parse.parse(dialog.FileName);
                        foreach (DataRow row in _dt.Rows)
                        {
                            _items.AddItem(row[0].ToString(), idx);
                            this.opc_item_table.Rows.Add(row[0].ToString(), row[1].ToString(), 0);
                            idx++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error($"处理导入的地址文件失败，失败信息:{ex.Message}");
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}