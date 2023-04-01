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

        public main(IConfigurationRoot root, NLog.Logger logger)
        {
            InitializeComponent();
            _root = root;
            _logger = logger;
            _server = new OPCServer();
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
                    group.DataChange += (int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps) =>
                    {
                        for (int i = 1; i <= NumItems; i++)
                        {
                            object? idx = ClientHandles.GetValue(i);
                            if (idx is not null)
                            {
                                this.opc_item_table.Rows[(int)idx].Cells[2].Value = ItemValues.GetValue(i);
                            }
                        }
                    };

                    _items = group.OPCItems;
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
        /// ����csv��ʽ�ĵ�ַ�ļ�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void import_csv_file_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "csv�ļ�(*.csv)|*.csv";

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
                _logger.Error($"������ĵ�ַ�ļ�ʧ�ܣ�ʧ����Ϣ:{ex.Message}");
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