using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingFakeClass
{
    public interface Dbinter
    {
        List<string> GetData(string d);
    }
    internal class FakeClasss : Dbinter
    {// stub: hardcoded value 
        //fake: simplified version of realone 
        public List<string> GetData(string d)//u
        {
            List<string> st = new List<string>()
            {
                "India", "Canada", "UK", "USA"
            };


            var res = st.Where(c=> c.Contains(d)).ToList();
            return res;
        }
    } 
}
