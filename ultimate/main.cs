using OPCAutomation;
using Microsoft.Extensions.Configuration;
using NLog;
using System.Text;

namespace ultimate
{
    public partial class main : Form
    {
        /// <summary>
        /// opc服务器对象，必须在创建对象的时候创建它
        /// </summary>
        public OPCServer Server { get; set; }

        /// <summary>
        /// opc组群对象，用于包含多组，可以为null
        /// </summary>
        public OPCGroups? Groups { get; set; }

        /// <summary>
        /// 元数据组，包括加载模式,产品名称等
        /// </summary>
        public OPCGroup? MetaGroup { get; set; }

        /// <summary>
        /// 元数据组项集合
        /// </summary>
        public OPCItems? MetaGroupItems { get; set; }

        /// <summary>
        /// 流程组
        /// </summary>
        public OPCGroup? StepGroup { get; set; }

        /// <summary>
        /// 流程组项集合
        /// </summary>
        public OPCItems? StepGroupItems { get; set; }

        /// <summary>
        /// 配置对象
        /// </summary>
        public IConfigurationRoot Config { get; set; }

        /// <summary>
        /// 日志对象
        /// </summary>
        public Logger Logger { get; set; }

        /// <summary>
        /// 模式对应的控件集合
        /// </summary>
        public Dictionary<int, Control> modes = new Dictionary<int, Control>();

        /// <summary>
        /// opc地址前缀
        /// </summary>
        public string AddressPrefix = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="logger"></param>
        public main(IConfigurationRoot root, Logger logger)
        {
            InitializeComponent();
            Config = root;
            Logger = logger;
            Server = new OPCServer();

            AddressPrefix = $"{Config["channel"]}.{Config["device"]}.";

            modes.Add(1, new mode1());
            modes.Add(2, new mode2());
            modes.Add(3, new mode3());
            modes.Add(4, new mode4());

            foreach (var values in modes.Values)
            {
                values.Dock = DockStyle.Fill;
            }

        }

        /// <summary>
        /// 元数据组数据变化事件处理程序
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="NumItems"></param>
        /// <param name="ClientHandles"></param>
        /// <param name="ItemValues"></param>
        /// <param name="Qualities"></param>
        /// <param name="TimeStamps"></param>
        private void meta_group_data_change(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            for (int i = 1; i <= NumItems; i++)
            {
                object? _clientHandle = ClientHandles.GetValue(i);
                if (_clientHandle != null)
                {
                    int clientHandle = (int)_clientHandle;

                    if (clientHandle == OPCAddress.load_id.ClientHandle)
                    {
                        //加载模式
                        Object? value = ItemValues.GetValue(i);

                        if (value != null)
                        {
                            Int16 mode_id = (Int16)value;
                            if (modes.ContainsKey(mode_id))
                            {
                                this.main_layout.Controls.Add(modes[mode_id], 0, 0);
                            }
                            else
                            {
                                Logger.Error($"错误的加载模式:{mode_id}");
                            }
                        }
                        else
                        {
                            Logger.Error("获取加载模式异常，加载模式为空引用");
                        }
                    }
                    else if (clientHandle == OPCAddress.product_name.ClientHandle)
                    {
                        //产品名称
                        Object? value = ItemValues.GetValue(i);
                        if (value as Byte[] != null)
                        {
                            StringBuilder sb = new StringBuilder();
                            foreach (var c in (Byte[])value)
                            {
                                sb.Append((Char)c);
                            }
                            this.Text = sb.ToString();
                        }
                        else
                        {
                            this.Text = string.Empty;
                            Logger.Error("获取产品名称异常，产品名称为空引用");
                        }
                    }
                    else if (clientHandle == OPCAddress.motor_current.ClientHandle)
                    {
                        //电流
                    }
                    else if (clientHandle == OPCAddress.time.ClientHandle)
                    {
                        //时间
                    }
                }
                else
                {
                    Logger.Error("获取句柄异常，句柄项为空引用");
                }
            }
        }

        /// <summary>
        /// 流程组数据变化事件处理程序
        /// </summary>
        /// <param name="TransactionID"></param>
        /// <param name="NumItems"></param>
        /// <param name="ClientHandles"></param>
        /// <param name="ItemValues"></param>
        /// <param name="Qualities"></param>
        /// <param name="TimeStamps"></param>
        private void step_group_data_change(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {

            if (info_display.Rows.Count == 500)
            {
                info_display.Rows.Clear();
            }

            object? value = ItemValues.GetValue(1);
            if (value != null)
            {
                Int16 step = (Int16)value;

                switch (step)
                {
                    case 0:
                        {
                            info_display.Rows.Add(DateTime.Now, "等待设备启动");
                            break;
                        }
                    case 10:
                        {
                            info_display.Rows.Add(DateTime.Now, "上下压紧气缸工作");
                            break;
                        }
                    case 20:
                        {
                            info_display.Rows.Add(DateTime.Now, "检测装车螺丝与缓冲块");
                            break;
                        }
                    case 30:
                        {
                            info_display.Rows.Add(DateTime.Now, "电机高低配选择");
                            break;
                        }

                    case 40:
                        {
                            info_display.Rows.Add(DateTime.Now, "滑块向下止点运行");
                            break;
                        }
                    case 50:
                        {
                            info_display.Rows.Add(DateTime.Now, "伺服电机带负载向最低点运行");
                            break;
                        }
                    case 60:
                        {
                            info_display.Rows.Add(DateTime.Now, "顶升平移气缸工作");
                            break;
                        }
                    case 70:
                        {
                            info_display.Rows.Add(DateTime.Now, "顶升气缸工作");
                            break;
                        }
                    case 80:
                        {
                            info_display.Rows.Add(DateTime.Now, "钢丝绳松紧检测");
                            break;
                        }
                    case 90:
                        {
                            info_display.Rows.Add(DateTime.Now, "铰接继电器工作");
                            break;
                        }
                    case 100:
                        {
                            info_display.Rows.Add(DateTime.Now, "钢丝绳铰接检测");
                            break;
                        }
                    case 110:
                        {
                            info_display.Rows.Add(DateTime.Now, "顶升气缸回基本位");
                            break;
                        }
                    case 120:
                        {
                            info_display.Rows.Add(DateTime.Now, "顶升平移气缸回基本位");
                            break;
                        }
                    case 130:
                        {
                            info_display.Rows.Add(DateTime.Now, "加载气缸工作");
                            break;
                        }
                    case 140:
                        {
                            info_display.Rows.Add(DateTime.Now, "滑块向上止点运行");
                            break;
                        }
                    case 150:
                        {
                            info_display.Rows.Add(DateTime.Now, "判断电机运行电流是否超差");
                            break;
                        }
                    case 151:
                        {
                            info_display.Rows.Add(DateTime.Now, "加载气缸回基本位");
                            break;
                        }
                    case 160:
                        {
                            info_display.Rows.Add(DateTime.Now, "顶升平移气缸工作");
                            break;
                        }
                    case 170:
                        {
                            info_display.Rows.Add(DateTime.Now, "顶升气缸工作");
                            break;
                        }
                    case 180:
                        {
                            info_display.Rows.Add(DateTime.Now, "钢丝绳松紧检测");
                            break;
                        }
                    case 190:
                        {
                            info_display.Rows.Add(DateTime.Now, "铰接继电器工作");
                            break;
                        }
                    case 200:
                        {
                            info_display.Rows.Add(DateTime.Now, "钢丝绳铰接检测");
                            break;
                        }
                    case 210:
                        {
                            info_display.Rows.Add(DateTime.Now, "顶升气缸回基本位");
                            break;
                        }
                    case 220:
                        {
                            info_display.Rows.Add(DateTime.Now, "顶升平移气缸回基本位");
                            break;
                        }
                    case 230:
                        {
                            info_display.Rows.Add(DateTime.Now, "交付气缸工作");
                            break;
                        }
                    case 240:
                        {
                            info_display.Rows.Add(DateTime.Now, "电机向交付位置运行，交付位置信号检测中");
                            break;
                        }
                    case 260:
                        {
                            info_display.Rows.Add(DateTime.Now, "交付位置确认");
                            break;
                        }
                    case 270:
                        {
                            info_display.Rows.Add(DateTime.Now, "交付气缸回基本位");
                            break;
                        }
                    case 280:
                        {
                            info_display.Rows.Add(DateTime.Now, "上下压紧气缸回基本位");
                            break;
                        }
                    case 290:
                        {
                            info_display.Rows.Add(DateTime.Now, "打印标签中");
                            break;
                        }
                    case 300:
                        {
                            info_display.Rows.Add(DateTime.Now, "请取走门板");
                            break;
                        }
                    default:
                        Logger.Error("未知流程步骤!");
                        break;
                }
            }
            else
            {
                Logger.Error("获取流程状态异常，流程状态为空引用");
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
                Server.Connect(Config["server_name"]);
                if (Server.ServerState == (int)OPCServerState.OPCRunning)
                {
                    this.server_connect_stratus.Text = "服务器连接状态：已连接";
                    this.server_connect_stratus.ForeColor = Color.Green;

                    Groups = Server.OPCGroups;
                    Groups.DefaultGroupDeadband = 0;
                    Groups.DefaultGroupIsActive = true;
                    Groups.DefaultGroupUpdateRate = 250;

                    //元数据组
                    MetaGroup = Groups.Add("meta_group");
                    MetaGroup.IsSubscribed = true;
                    MetaGroup.DataChange += meta_group_data_change;
                    MetaGroupItems = MetaGroup.OPCItems;
                    //加载模式
                    MetaGroupItems.AddItem($"{AddressPrefix}{OPCAddress.load_id.Name}", OPCAddress.load_id.ClientHandle);
                    //产品名称
                    MetaGroupItems.AddItem($"{AddressPrefix}{OPCAddress.product_name.Name}", OPCAddress.product_name.ClientHandle);
                    //当前电流
                    MetaGroupItems.AddItem($"{AddressPrefix}{OPCAddress.motor_current.Name}", OPCAddress.motor_current.ClientHandle);
                    //当前时间
                    MetaGroupItems.AddItem($"{AddressPrefix}{OPCAddress.time.Name}", OPCAddress.time.ClientHandle);

                    //流程组
                    StepGroup = Groups.Add("step_group");
                    StepGroup.IsSubscribed = true;
                    StepGroup.DataChange += step_group_data_change;
                    StepGroupItems = StepGroup.OPCItems;
                    //状态流转变量
                    StepGroupItems.AddItem($"{AddressPrefix}{OPCAddress.step.Name}", OPCAddress.step.ClientHandle);
                }
                else
                {
                    //连接失败
                    Logger.Error($"连接KepServer失败,服务端的状态为:{Enum.GetName<OPCServerState>((OPCServerState)Server.ServerState)}");
                }
            }
            catch (Exception ex)
            {
                //连接失败
                Logger.Error($"连接KepServer失败，{ex.Message}.请检查Kepserver是否正常运行以及配置文件中的服务器名称是否正确!");
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