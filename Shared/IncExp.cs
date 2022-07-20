namespace MoneyOrg.Client.Shared
{
    public class IncExp
    {
        public int Id { get; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public double Amount { get; set; }

        public double Balance { get; set; }

        public DateTime Time { get; set; }

        public List<IncExp> IncExpList;

        public void addTolist(IncExp incexp) {
            IncExpList.Add(incexp);
        
        }

        public List<IncExp> getList()
        {
            return IncExpList;
        }

        public IncExp(int id, string type, string subType, double amount,double balance, DateTime time)
        {
            Id = id;
            Type = type;
            SubType = subType;
            Amount = amount;
            Balance = balance;
            Time = time;
           
        }

    }
}
