namespace MoneyOrg.Client.Shared
{
    public class IncExp
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public double Amount { get; set; }

        public double Balance { get; set; }

        public double PrevBalance { get; set; }

        public DateTime Time { get; set; }

        public IncExp[] IncExpData { get; set; }

        /*public enum Type
        {
            Employment,
            SelfEmployment,
            Business,
            Investment,
            Loan,
            Grant,
            Gift

        }
        */




        public IncExp( int id ,DateTime time, string type, string subType, double prevBalance, double amount)
        {
            Id = id;
            Time = time;
            Type = type;
            SubType = subType;
            Amount = amount;
            PrevBalance = prevBalance ;

            if (type.Equals("Expense"))
            {
                Balance = prevBalance - amount;

            }
            else Balance = prevBalance + amount;

        }

    }
}
