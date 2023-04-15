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

        public static AddressDesc x428_3 = new AddressDesc("x428_3", client_handle++);

        public static List<string> x428_3_warn_message = new List<string> { "急停已拍下！", "载具不匹配！", "伺服报警！" };

        public static AddressDesc x430_8 = new AddressDesc("x430_8", client_handle++);

        public static List<string> x430_8_warn_message = new List<string> 
        { 
            "搭接平移１气缸回基本位异常！", 
            "搭接平移１气缸去工作位异常！", 
            "搭接平移2气缸回基本位异常！" ,
            "搭接平移2气缸去工作位异常！",
            "工装上压紧气缸回基本位异常！",
            "工装上压紧气缸去工作位异常！",
            "工装下压紧气缸回基本位异常！",
            "工装下压紧气缸去工作位异常！",
        };

        public static AddressDesc x431_8 = new AddressDesc("x431_8", client_handle++);

        public static List<string> x431_8_warn_message = new List<string>
        {
            "搭接1气缸回基本位异常！",
            "搭接1气缸去工作位异常！",
            "搭接2气缸回基本位异常！",
            "搭接2气缸去工作位异常！",
            "搭接3气缸回基本位异常！",
            "搭接3气缸去工作位异常！",
            "交付气缸回基本位异常！",
            "交付气缸去工作位异常！",
        };

        public static AddressDesc x432_2 = new AddressDesc("x432_2", client_handle++);

        public static List<string> x432_2_warn_message = new List<string>
        {
            "负载气缸回基本位异常！",
            "负载气缸去工作位异常！",
        };

        public static AddressDesc x434_8 = new AddressDesc("x434_8", client_handle++);

        public static List<string> x434_8_warn_message = new List<string>
        {
            "长导轨缓冲块检测报警！",
            "短导轨缓冲块缺失报警！",
            "长导轨装车螺丝缺失报警！",
            "短导轨装车螺丝缺失报警！",
            "长导轨侧滑块装反！",
            "短导轨侧滑块装反！",
            "滑块装反！",
            "钢丝绳1松报警！",
        };

        public static AddressDesc x435_8 = new AddressDesc("x435_8", client_handle++);

        public static List<string> x435_8_warn_message = new List<string>
        {
            "钢丝绳2松报警！",
            "钢丝绳3松报警！",
            "钢丝绳铰接1报警！",
            "钢丝绳铰接2报警！",
            "钢丝绳铰接报警！",
            "上止点检测异常！",
            "电机电流超限！",
            "电机上升时间超限！"
        };

        public static AddressDesc x436_5 = new AddressDesc("x436_5", client_handle++);

        public static List<string> x436_5_warn_message = new List<string>
        {
            "缓冲块缺失报警！",
            "装车螺丝缺失报警！",
            "上钢丝绳松报警！",
            "下钢丝绳松报警！",
            "电机停交付位置不准确！"
        };

        public static AddressDesc x438_8 = new AddressDesc("x438_8", client_handle++);

        public static List<string> x438_8_warn_message = new List<string>
        {
            "伺服不在原点！",
            "负载气缸不在基本位！",
            "上压紧气缸不在基本位！",
            "下压紧气缸不在基本位！",
            "顶升平移气缸1不在基本位！",
            "顶升平移气缸2不在基本位！",
            "搭接气缸1不在基本位！",
            "搭接气缸2不在基本位！",
        };

        public static AddressDesc x439_3 = new AddressDesc("x439_3", client_handle++);

        public static List<string> x439_3_warn_message = new List<string>
        {
            "搭接气缸3不在基本位！",
            "交付气缸不在基本位！",
            "未放产品！"
        };
    }
}
