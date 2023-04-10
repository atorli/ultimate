using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ultimate
{
    internal static class OPCAddress
    {
        public static AddressDesc load_id = new AddressDesc("load_id", 0);

        public static AddressDesc product_name = new AddressDesc("product_name", 1);

        public static AddressDesc motor_current = new AddressDesc("motor_current", 2);

        public static AddressDesc step = new AddressDesc("step", 3);

        public static AddressDesc time = new AddressDesc("time", 4);

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
