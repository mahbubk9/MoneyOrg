using Microsoft.AspNetCore.Mvc;
using MoneyOrg.Client.Shared;

namespace MoneyOrg.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IncExpController : ControllerBase
    {
        private readonly MoneyOrgDbContext db;

        public IncExpController(MoneyOrgDbContext db) => this.db = db;



        private static readonly List<IncExp> IncomeExpense = new List<IncExp>
{
new IncExp(001,DateTime.Now, "Income","Employment",5000.0, 10000.0 ),
new IncExp(002,DateTime.Now, "Expense","Utility",15000.0, 100.0 ),
new IncExp(003,DateTime.Now, "Expense","Grocery",14900.0, 100.0 ),



};

        
        [HttpGet("/IncomeExpense")]
        public IQueryable<IncExp> GetIncExp()
        {
            return db.IncomeExpense;
        }

        [HttpPost("/IncomeExpense")]
        public IActionResult InsertIncExp([FromBody] IncExp data)
        {
            db.IncomeExpense?.Add(data);
            db.SaveChanges();
            return Created($"IncomeExpense/{data.Id}", IncomeExpense);
        }
    }










}

