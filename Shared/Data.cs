
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyOrg.Client.Shared;
using static MoneyOrg.Client.Shared.IncExp;

namespace MoneyOrg.Shared
{
    internal class Data
    {
        public List<IncExp>? Lst { get; set; }
        public double Bal { get; set; }

        public Data(List<IncExp>? lst)
        {
            Lst = lst;
            Bal = 0.0;
        }
    }
}
