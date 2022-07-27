namespace MoneyOrg.Client.Shared
{
    public class IncExp
    {
        public int Id { get; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public double Amount { get; set; }

        public double Balance { get; set; }

        public double PrevBalance { get; set; }

        public DateTime Time { get; set; }





        public IncExp(int id, string type, string subType,double PrevBalance, double amount, DateTime time)
        {
            Id = id;
            Type = type;
            SubType = subType;
            Amount = amount;
            Time = time;
            if (type.Equals("Expense"))
            {
                Balance = PrevBalance - Balance;

            }
            else Balance = PrevBalance+Balance;
           
        }

    }
}
