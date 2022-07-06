using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace Budget
{

    class Program
    {

        static void Main(string[] args)
        {
            CashFlow flow = new CashFlow();

            flow.Description = "School";
            flow.Amount = 1200;
            flow.Expense();

            Console.WriteLine(flow.Description);
            Console.WriteLine(flow.Amount);
            Console.WriteLine(flow.RemainingAmount);
        }

        /// <summary>
        /// This class stores the name and description of the monthly cash flow
        /// </summary>
        public class CashFlow
        {
            private decimal amount = 0;
            private string description = "";
            static private decimal totalExpense = 0;
            static private decimal totalIncome = 0;
            static private decimal remainingAmount = 0;

            // will show true if expense and subtract amount or false if income
            // and add amount
            private bool expense = true;

            // the amount of the cash flow
            public decimal Amount
            {
                get { return amount; }
                set { amount = value; }
            }

            // The description of the cash flow
            public string Description
            {
                get { return description; }
                set { description = value; }
            }

            public decimal RemainingAmount { get { return remainingAmount; } }

            /// <summary>
            /// Takes user input and then makes proper calculations depending on if 
            /// it is expense or income
            /// </summary>
            /// <param name="exp">The input from user: i for income or e for expense</param>
            public void Expense()
            {
                char exp;
                do
                {
                    Console.Write("Please enter 'i' for income or 'e' for expense: ");
                    exp = char.Parse(Console.ReadLine());

                    if (char.ToLower(exp) == 'e')
                    {
                        expense = true;
                        totalExpense -= amount;
                    }
                    else if (char.ToLower(exp) == 'i')
                    {
                        expense = false;
                        totalIncome += amount;
                    }
                } while (char.ToLower(exp) != 'e' || char.ToLower(exp) == 'i');

                remainingAmount = totalIncome + totalExpense;
            }




        }
    }
}
