using OPCAutomation;

namespace ProjectA
{
    public partial class main : Form
    {
        private OPCServer server;
        private OPCGroups groups;
        private OPCGroup group;
        private OPCItems items;
        private OPCItem item;


        public main()
        {
            InitializeComponent();
            server = new OPCServer();
            server.Connect("Kepware.KEPServerEX.V6");
            if (server.ServerState == (int)OPCServerState.OPCRunning)
            {
                groups = server.OPCGroups;
                groups.DefaultGroupDeadband = 0;
                groups.DefaultGroupIsActive = true;
                groups.DefaultGroupUpdateRate = 250;
                group = groups.Add("group1");
                group.IsSubscribed = true;
                items = group.OPCItems;
                item = items.AddItem("ch1.dev1.item1", 1);
                group.DataChange += Group_DataChange;
            }
        }

        private void Group_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 1; i <= NumItems; i++)
            {
                //int tmpClientHandle = Convert.ToInt32(ClientHandles.GetValue(i));
                //string tmpValue = ItemValues.GetValue(i).ToString();
                //string tmpTime = ((DateTime)(TimeStamps.GetValue(i))).ToString();
                //Console.WriteLine("Time:" + tmpTime);
                //Console.WriteLine("ClientHandle : " + tmpClientHandle.ToString());
                //Console.WriteLine("tag value " + tmpValue);

            }
        }



    }
}