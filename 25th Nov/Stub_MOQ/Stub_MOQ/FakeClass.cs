using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Stub_MOQ.Stub_Moq;

namespace Stub_MOQ
{
    internal class FakeClass : IMath
    {

        public string Add(int x, int y)
        {
            return "the sum is 30";
        }
    }
}
