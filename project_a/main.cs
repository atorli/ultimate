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
        /// ���������һ����ʾʱ����ʼ���ӷ����������ҿ�ʼ��һЩ
        /// �������ݵĲ���
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
                    this.server_connect_stratus.Text = "����������״̬��������";
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
                    _logger.Info("�������ݳ�ʼ����ɣ���ʼ������......");
                }
                else
                {
                    //����ʧ��
                    _logger.Error($"����KepServerʧ��,����˵�״̬Ϊ:{Enum.GetName<OPCServerState>((OPCServerState)server.ServerState)}");
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