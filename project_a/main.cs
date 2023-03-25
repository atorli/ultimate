using OPCAutomation;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace ProjectA
{
    public partial class main : Form
    {
        private OPCServer server;
        private OPCGroups? groups;
        private OPCGroup? group;
        private OPCItems? items;
        private OPCItem? item;
        private IConfigurationRoot _root;

        public main(IConfigurationRoot root)
        {
            InitializeComponent();
            _root = root;
            server = new OPCServer();
            server.Connect(_root["server_name"]);
            if (server.ServerState == (int)OPCServerState.OPCRunning)
            {
                this.server_connect_stratus.Text = "服务器连接状态：已连接";
                this.server_connect_stratus.ForeColor = Color.Green;
                groups = server.OPCGroups;
                groups.DefaultGroupDeadband = 0;
                groups.DefaultGroupIsActive = true;
                groups.DefaultGroupUpdateRate = 250;
                group = groups.Add("group1");
                group.IsSubscribed = true;
                items = group.OPCItems;
                item = items.AddItem("ch1.dev1.item1", 0);
                this.dataGridView1.Rows.Add("ch1.dev1.item1", 0);
                group.DataChange += Group_DataChange;
            }
        }

        private void Group_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            this.dataGridView1.Rows[(int)ClientHandles.GetValue(1)].Cells[1].Value = ItemValues.GetValue(1).ToString();
        }
    }
}