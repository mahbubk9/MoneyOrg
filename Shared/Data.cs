
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

        public List<IncExp> DataList = new List<IncExp>();
        public void AddToList(IncExp incexp)
        {
            DataList.Add(incexp);

        }

        public List<IncExp> getDataList()
        {
            return DataList;
        }

        public double getBalance(List<IncExp> lst)
        {
            double balance = 0.0;
            for (int i = 0; i < lst.Count; i++)
            {
                balance+=lst[i].Amount;
            }
            return balance;
        }
        //Dictionary<List<IncExp>, double> Dt = new Dictionary<List<IncExp>, double>();




    }
}
