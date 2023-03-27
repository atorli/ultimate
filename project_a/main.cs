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

                    OPCGroups groups = _server.OPCGroups;
                    groups.DefaultGroupDeadband = 0;
                    groups.DefaultGroupIsActive = true;
                    groups.DefaultGroupUpdateRate = 250;

                    OPCGroup group = groups.Add("group1");
                    group.IsSubscribed = true;
                    group.DataChange += Group_DataChange;

                    OPCItems items = group.OPCItems;

                    _dt = csv_parse.parse("./test.csv");

                    int idx = 0;
                    foreach (DataRow row in _dt.Rows)
                    {
                        items.AddItem(row[0].ToString(), idx);
                        this.opc_item_table.Rows.Add(row[0].ToString(),row[1].ToString(),0);
                        idx++;
                    }
                    //OpenFileDialog fd = new OpenFileDialog();
                    //fd.Filter = "csv文件(*.csv)|*.csv";
                    //fd.ShowDialog();
                    _logger.Info("监听数据初始化完成，开始监听中......");
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
    }
}