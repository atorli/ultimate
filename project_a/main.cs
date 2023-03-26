using OPCAutomation;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using NLog;


namespace ProjectA
{
    public partial class main : Form
    {
        private OPCServer server;
        private IConfigurationRoot _root;
        private NLog.Logger _logger;


        public main(IConfigurationRoot root, NLog.Logger logger)
        {
            InitializeComponent();
            _root = root;
            _logger = logger;
            server = new OPCServer();
        }

        private void Group_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            for (int i = 1; i <= NumItems; i++)
            {
                object? idx = ClientHandles.GetValue(i);
                if (idx is not null)
                {
                    this.opc_item_table.Rows[(int)idx].Cells[1].Value = ItemValues.GetValue(i);
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
                server.Connect(_root["server_name"]);
                if (server.ServerState == (int)OPCServerState.OPCRunning)
                {
                    this.server_connect_stratus.Text = "服务器连接状态：已连接";
                    this.server_connect_stratus.ForeColor = Color.Green;
                    OPCGroups groups = server.OPCGroups;
                    groups.DefaultGroupDeadband = 0;
                    groups.DefaultGroupIsActive = true;
                    groups.DefaultGroupUpdateRate = 250;
                    OPCGroup group = groups.Add("group1");
                    group.IsSubscribed = true;
                    OPCItems items = group.OPCItems;
                    OPCItem item = items.AddItem("ch1.dev1.item1", 0);
                    this.opc_item_table.Rows.Add("ch1.dev1.item1", 0);
                    group.DataChange += Group_DataChange;
                    _logger.Info("监听数据初始化完成，开始监听中......");
                }
                else
                {
                    //连接失败
                    _logger.Error($"连接KepServer失败,服务端的状态为:{Enum.GetName<OPCServerState>((OPCServerState)server.ServerState)}");
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