using System.Collections.Generic;
using System.Linq;

namespace testHSEWebApi.Repository
{
    public class FakeDataBase
    {
        private static List<string> _publicListString = new List<string>();

        public void AddSomeString(string toInsterStr)
        {
            _publicListString.Add(toInsterStr);
        }

        public string PrintList()
        {
            return _publicListString.Aggregate("", (str, e) => str + e);
        }

        public List<string> GetListString()
        {
            return _publicListString;
        }
    }
}