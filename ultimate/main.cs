using OPCAutomation;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using NLog;
using project_a.modules.file_parse;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ProjectA
{
    public partial class main : Form
    {
        /// <summary>
        /// opc服务器对象，必须在创建对象的时候创建它
        /// </summary>
        private OPCServer _server;

        /// <summary>
        /// opc组群对象，用于包含多组，可以为null
        /// </summary>
        private OPCGroups? _groups;

        /// <summary>
        /// opc单组对象，用于包含items,可以为null
        /// </summary>
        private OPCGroup? _group;

        /// <summary>
        /// opc地址项组对象，用于包含单个地址项
        /// </summary>
        private OPCItems? _items;

        /// <summary>
        /// 配置对象
        /// </summary>
        private IConfigurationRoot _root;

        /// <summary>
        /// 日志对象
        /// </summary>
        private NLog.Logger _logger;

        /// <summary>
        /// 用于保存导入的项数据
        /// </summary>
        private DataTable? _dt;

        public main(IConfigurationRoot root, NLog.Logger logger)
        {
            InitializeComponent();
            _root = root;
            _logger = logger;
            _server = new OPCServer();
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
                    group.DataChange += (int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps) =>
                    {
                        for (int i = 1; i <= NumItems; i++)
                        {
                            object? idx = ClientHandles.GetValue(i);
                            if (idx is not null)
                            {
                                Object? values = ItemValues.GetValue(i);
                                if (values as Byte[] != null)
                                {
                                    foreach (var item in (Byte[])values)
                                    {
                                        _logger.Info($"value is {(Char)item}");
                                    }
                                }
                                //this.opc_item_table.Rows[(int)idx].Cells[2].Value = ItemValues.GetValue(i);
                            }
                        }
                    };

                    _items = group.OPCItems;

                    //解析地址文件，加载地址
                    int idx = 0;
                    _dt = csv_parse.parse(Path.Join("settings", "item_address.csv"));
                    foreach (DataRow row in _dt.Rows)
                    {
                        OPCItem item = _items.AddItem(row[0].ToString(), idx);
                        //this.opc_item_table.Rows.Add(row[0].ToString(), row[1].ToString(), 0);
                        idx++;
                        //Byte[] bytes = { 1, 2, 3, 4, 5, 6, 7, 8 };
                        //item.Write(bytes);
                    }
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

        /// <summary>
        /// 闪烁定时器，控件箭头的闪烁
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void blink_timer_Tick(object sender, EventArgs e)
        {
            //if (this.arrow1.PaintColor == Color.Transparent)
            //{
            //    this.arrow1.PaintColor = Color.Green;
            //}
            //else if (this.arrow1.PaintColor == Color.Green)
            //{
            //    arrow1.PaintColor = Color.Transparent;
            //}
        }
    }
}