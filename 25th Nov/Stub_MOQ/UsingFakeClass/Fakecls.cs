using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingFakeClass
{
    public interface DbInter
    {
        List<string> GetData(string d);

    }
    internal class Fakecls : DbInter
    {// stub: hardcoded value
     // fake : simplified version of realone
        public List<string> GetData(string d)//u
        {
            List<string> st = new List<string>()
        {
            "India","canada","uk","us"
        };


            var res = st.Where(c => c.Contains(d)).ToList();
            return res;

        }



    }


}




