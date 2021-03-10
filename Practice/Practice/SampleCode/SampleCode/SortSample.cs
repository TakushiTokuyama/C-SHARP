using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleCode
{
    public class SortSample
    {
        Dictionary<string, int> fruits = new Dictionary<string, int>
        {
            ["apple"] = 100,
            ["orange"] = 80,
            ["banana"] = 60,
        };

        public static IOrderedEnumerable<KeyValuePair<string, int>> Sorted(Dictionary<string, int> dic)
        {
            var sortDic = dic.OrderBy(o => o.Value);

            return sortDic;
        }
    }
}
