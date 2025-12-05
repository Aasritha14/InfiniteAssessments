using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Stub_MOQ.Stub_Moq;

namespace Stub_MOQ
{
    internal class Stub_MOQ
    {
        public class Client
        {
            IMath math;
            public Client(IMath m)
            {
                math = m;
            }

            public string AddClient(int x , int y)
            {
                //other logic goes here
                return math.Add(x, y);
            }
        }
    }
}
