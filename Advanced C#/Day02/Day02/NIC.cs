using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    // 
    // NIC card must have these data: Manufacture, MAC Address, Type [Ethernet or token ring – use Enumeration here]…
    //
    enum Type:byte
    {
        Ethernet,
        TokenRing
    }
    internal class NIC
    {
        private StringBuilder Manfacture;
        private StringBuilder MACAddress;
        private Type ConnectionType;

        private NIC() {
            Manfacture = new StringBuilder("Samsung");
            MACAddress = new StringBuilder("00-B0-D0-63-C2-26");
            ConnectionType = Type.Ethernet;
        }
        public static NIC instance { get; } = new NIC();
        public void connectionData()
        {
            Console.WriteLine($"{ConnectionType} {Manfacture} Connection with {MACAddress} Address is connected");
        }
    }

    class X
    {
        public int x; // value type
        public Boolean y; // value type
        public int[] arr; // ref type
        public X(int _x, Boolean _y, int[] arr)
        {
            x = _x; y = _y;
            this.arr = arr;
        }

        public void clone(X V)
        {
            x=V.x; y = V.y ; arr=V.arr;
        }

        public override string ToString()
        {
            string str="";
            foreach (int e in arr)
                str += $" {e}";
            return $"X: {x} - Y:{y} - Arr:{str}";
        }
  
    }
}
