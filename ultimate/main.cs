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
        /// opc���������󣬱����ڴ��������ʱ�򴴽���
        /// </summary>
        private OPCServer _server;

        /// <summary>
        /// opc��Ⱥ�������ڰ������飬����Ϊnull
        /// </summary>
        private OPCGroups? _groups;

        /// <summary>
        /// opc����������ڰ���items,����Ϊnull
        /// </summary>
        private OPCGroup? _group;

        /// <summary>
        /// opc��ַ����������ڰ���������ַ��
        /// </summary>
        private OPCItems? _items;

        /// <summary>
        /// ���ö���
        /// </summary>
        private IConfigurationRoot _root;

        /// <summary>
        /// ��־����
        /// </summary>
        private NLog.Logger _logger;

        /// <summary>
        /// ���ڱ��浼���������
        /// </summary>
        private DataTable? _dt;


        private Dictionary<int, Image> images = new Dictionary<int, Image>();


        /// <summary>
        /// opc��ַǰ׺
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
        /// ���������һ����ʾʱ����ʼ���ӷ����������ҿ�ʼ��һЩ
        /// �������ݵĲ���
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
                    this.server_connect_stratus.Text = "����������״̬��������";
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
                    //����ʧ��
                    _logger.Error($"����KepServerʧ��,����˵�״̬Ϊ:{Enum.GetName<OPCServerState>((OPCServerState)_server.ServerState)}");
                }
            }
            catch (Exception ex)
            {
                //����ʧ��
                _logger.Error($"����KepServerʧ�ܣ�{ex.Message}.����Kepserver�Ƿ����������Լ������ļ��еķ����������Ƿ���ȷ!");
            }
        }

        /// <summary>
        /// ��˸��ʱ�����ؼ���ͷ����˸
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