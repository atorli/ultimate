using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ultimate
{
    internal class AddressDesc
    {
        public string Name
        {
            get;
        }

        public int ClientHandle
        {
            get;
        }


        public AddressDesc(string name, int clientHandle)
        {
            Name = name;
            ClientHandle = clientHandle;
        }
    }

    internal static class MetaGroup
    {
        private static int client_handle = 0;

        public static AddressDesc load_id = new AddressDesc("load_id", client_handle++);

        public static AddressDesc product_name = new AddressDesc("product_name", client_handle++);

        public static AddressDesc motor_current = new AddressDesc("motor_current", client_handle++);

        public static AddressDesc time = new AddressDesc("time", client_handle++);
    }

    internal static class StepGroup
    {
        private static int client_handle = 0;

        public static AddressDesc step = new AddressDesc("step", client_handle++);
    }

    internal static class WarnGroup
    {
        private static int client_handle = 0;

        public static Dictionary<int,AddressDesc> items {  get; private set; }

        static WarnGroup()
        {
            items = new Dictionary<int, AddressDesc>();
            items.Add(client_handle, new AddressDesc("OP40-1伺服跟随", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1伺服最高电(原点)", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1伺服下限位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-2伺服跟随", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-2伺服最高点(原点)", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-2伺服下限位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1下压紧工作位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1泡棉漏装检测", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1交付位置检测", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1下料开始", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1安全继电器检测", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1上压紧基本位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1上压紧工作位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1下压紧基本位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1长导轨侧缓冲块检测", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1短导轨侧缓冲块检测", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1长导轨滚轮螺丝检测", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1短导轨滚轮螺丝检测", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1长导轨下止点检测", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1短导轨下止点检测", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1顶升平移气缸1基本位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1顶升平移气缸1工作位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1顶升平移气缸2基本位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1顶升平移气缸2工作位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1顶升1基本位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1顶升1工作位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1顶升2基本位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1顶升2工作位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1顶升3基本位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1顶升3工作位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1钢丝绳松检测1", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1钢丝绳松检测2", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1钢丝绳松检测3", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1钢丝绳铰接检测1", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1钢丝绳铰接检测2", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1负载气缸基本位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1交付气缸基本位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1交付气缸工作位", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1滑块到位检测", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1防错检测1", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1防错检测2", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1防错检测3", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1防错检测4", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1手动选择", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1自动选择", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1启动(触摸屏)", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1回原点(触摸屏)", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1复位(触摸屏)", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1伺服报警", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1长导轨上止点检测", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1短导轨上止点检测", client_handle++));
            items.Add(client_handle, new AddressDesc("OP40-1门板识别", client_handle++));
            items.Add(client_handle, new AddressDesc("急停(触摸屏)", client_handle++));
            items.Add(client_handle, new AddressDesc("急停(机台)", client_handle++));
        }
    }




}
