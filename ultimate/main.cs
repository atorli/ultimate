using OPCAutomation;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using NLog;
using project_a.modules.file_parse;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using ultimate;
using System.Text;

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


        private Dictionary<int, Image> images = new Dictionary<int, Image>();


        /// <summary>
        /// opc地址前缀
        /// </summary>
        private string address_prefix = string.Empty;


        public main(IConfigurationRoot root, NLog.Logger logger)
        {
            InitializeComponent();
            _root = root;
            _logger = logger;
            _server = new OPCServer();

            address_prefix = $"{_root["channel"]}.{_root["device"]}.";

            images.Add(1, Image.FromFile(Path.Combine("pictures", $"{1}.png")));
            images.Add(2, Image.FromFile(Path.Combine("pictures", $"{2}.png")));
            images.Add(3, Image.FromFile(Path.Combine("pictures", $"{3}.png")));
            images.Add(4, Image.FromFile(Path.Combine("pictures", $"{4}.png")));
        }


        private void data_change(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            for (int i = 1; i <= NumItems; i++)
            {
                object? _clientHandles = ClientHandles.GetValue(i);
                if (_clientHandles is not null)
                {
                    int clientHandles = (int)_clientHandles;

                    if (clientHandles == OPCAddress.load_id.ClientHandle)
                    {
                        Object? value = ItemValues.GetValue(i);
                        if (value is not null)
                        {
                            Int16 pic_id = (Int16)value;
                            if (images.ContainsKey(pic_id))
                            {
                                picture_box.Image = images[pic_id];
                            }
                        }
                    }
                    else if (clientHandles == OPCAddress.product_name.ClientHandle)
                    {
                        StringBuilder sb = new StringBuilder();
                        Object? value = ItemValues.GetValue(i);
                        if (value as Byte[] != null)
                        {
                            foreach (var c in (Byte[])value)
                            {
                                sb.Append((Char)c);
                            }
                        }
                        this.Text = sb.ToString();
                    }
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
                    group.DataChange += data_change;

                    _items = group.OPCItems;

                    _items.AddItem($"{address_prefix}{OPCAddress.load_id.Name}", OPCAddress.load_id.ClientHandle);
                    _items.AddItem($"{address_prefix}{OPCAddress.product_name.Name}", OPCAddress.product_name.ClientHandle);
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