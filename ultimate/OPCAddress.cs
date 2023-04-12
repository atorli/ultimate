using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ultimate
{
    internal static class OPCAddress
    {
        private static int client_handle = 0;

        public static AddressDesc load_id = new AddressDesc("load_id", client_handle++);

        public static AddressDesc product_name = new AddressDesc("product_name", client_handle++);

        public static AddressDesc motor_current = new AddressDesc("motor_current", client_handle++);

        public static AddressDesc step = new AddressDesc("step", client_handle++);

        public static AddressDesc time = new AddressDesc("time", client_handle++);

        public static AddressDesc warn_1 = new AddressDesc("OP40-1伺服跟随", client_handle++);

        public static AddressDesc warn_2 = new AddressDesc("OP40-1伺服最高电(原点)", client_handle++);

        public static AddressDesc warn_3 = new AddressDesc("OP40-1伺服下限位", client_handle++);

        public static AddressDesc warn_4 = new AddressDesc("OP40-2伺服跟随", client_handle++);

        public static AddressDesc warn_5 = new AddressDesc("OP40-2伺服最高点(原点)", client_handle++);

        public static AddressDesc warn_6 = new AddressDesc("OP40-2伺服下限位", client_handle++);

        public static AddressDesc warn_7 = new AddressDesc("OP40-1下压紧工作位", client_handle++);

        public static AddressDesc warn_8 = new AddressDesc("OP40-1泡棉漏装检测", client_handle++);

        public static AddressDesc warn_9 = new AddressDesc("OP40-1交付位置检测", client_handle++);

        public static AddressDesc warn_10 = new AddressDesc("OP40-1下料开始", client_handle++);

        public static AddressDesc warn_11 = new AddressDesc("OP40-1安全继电器检测", client_handle++);

        public static AddressDesc warn_12 = new AddressDesc("OP40-1上压紧基本位", client_handle++);

        public static AddressDesc warn_13 = new AddressDesc("OP40-1上压紧工作位", client_handle++);

        public static AddressDesc warn_14 = new AddressDesc("OP40-1下压紧基本位", client_handle++);

        public static AddressDesc warn_15 = new AddressDesc("OP40-1长导轨侧缓冲块检测", client_handle++);

        public static AddressDesc warn_16 = new AddressDesc("OP40-1短导轨侧缓冲块检测",client_handle++);

        public static AddressDesc warn_17 = new AddressDesc("OP40-1长导轨滚轮螺丝检测", client_handle++);

        public static AddressDesc warn_18 = new AddressDesc("OP40-1短导轨滚轮螺丝检测", client_handle++);

        public static AddressDesc warn_19 = new AddressDesc("OP40-1长导轨下止点检测", client_handle++);

        public static AddressDesc warn_20 = new AddressDesc("OP40-1短导轨下止点检测", client_handle++);

        public static AddressDesc warn_21 = new AddressDesc("OP40-1顶升平移气缸1基本位", client_handle++);

    }

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


        public AddressDesc(string name,int clientHandle) 
        {
            Name = name;
            ClientHandle = clientHandle;
        }
    }


}
