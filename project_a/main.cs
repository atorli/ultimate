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
                    //fd.Filter = "csv�ļ�(*.csv)|*.csv";
                    //fd.ShowDialog();
                    _logger.Info("�������ݳ�ʼ����ɣ���ʼ������......");
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
    }
}