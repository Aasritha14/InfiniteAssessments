using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stub_MOQ
{
    internal class Stub_Moq
    {
        public interface IMath
        {
            string Add(int x, int y);
        }
        internal class RealClass : IMath
        {
            public string Add(int x, int y)
            {
                return " the sum is  " + (x + y);
            }
        }
    }
}
