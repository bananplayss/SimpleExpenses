using System;
using System.Collections.Generic;

namespace SimpleExpenses
{

    public class Expenses
    {

        public string ExpenseName { get; set; }
        public decimal ExpensePrice { get; set; }
        public string ExpenseReason { get; set; }
        public DateTime ExpenseDateTime { get; set; }

        public Expenses(string name, decimal price, string reason, DateTime dateTime)
        {
            ExpenseName = name;
            ExpensePrice = price;
            ExpenseReason = reason;
            ExpenseDateTime = dateTime;
        }

        static void Main(string[] args)
        {
            List<Expenses> expenseList = new List<Expenses>();

            void PrintOptions()
            {
                Console.WriteLine($"\nPlease choose from one of the options below...");
                Console.WriteLine("1. Register New Expense");
                Console.WriteLine("2. Check All Expenses");
                Console.WriteLine("3. Exit");
            }

            void RegisterNewExpense(Expenses User)
            {
                Console.WriteLine($"\nPlease specify the name of your expense: ");
                string newExpenseName = Console.ReadLine();
                User.ExpenseName = newExpenseName;
                Console.WriteLine($"Expense has been added as {newExpenseName}!");

                Console.WriteLine($"\nPlease specify the price of your expense in USD: ");
                decimal newExpensePrice = decimal.Parse(Console.ReadLine());
                User.ExpensePrice = newExpensePrice;
                Console.WriteLine($"Expense has a price added as ${newExpensePrice}!");

                Console.WriteLine($"\nPlease specify the reason of your expense: ");
                string newExpenseReason = Console.ReadLine();
                User.ExpenseReason = newExpenseReason;
                Console.WriteLine($"Expense has a reason added as ${newExpenseReason}!");

                DateTime dateTime = DateTime.UtcNow;

                Expenses newExpense = new Expenses(newExpenseName, newExpensePrice, newExpenseReason, dateTime);
                expenseList.Add(newExpense);
                Console.WriteLine("NewExpense name: " + newExpense.ExpenseName);
                Console.WriteLine($"\n\nYour new expense has been added:");
                Console.WriteLine($"Name:\t{newExpenseName}\nPrice:\t${newExpensePrice}\nReason:\t{newExpenseReason}\nDate:\t{dateTime}");
                Console.WriteLine($"\n");

            }

            void CheckAllExpenses(Expenses User)
            {
                int index = 0;
                foreach (Expenses expense in expenseList)
                {
                    Console.WriteLine($"{index}. =>\tName:\t{expense.ExpenseName}\n\tPrice:\t${expense.ExpensePrice}\n\tReason:\t{expense.ExpenseReason}\n\tDate:\t{expense.ExpenseDateTime}\n");
                    index++;
                }

                if(expenseList.Count == 0)
                {
                    Console.WriteLine($"\nYou have no expenses!");
                }
            }

            //Prompt
            Console.WriteLine("SimpleExpenses\t\tVersion: 1.0");
            Console.WriteLine($"------------------------------\n");

            Console.WriteLine("Please enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Welcome to SimpleExpenses, {name}! ");
            Expenses user = new Expenses(name,0,"",DateTime.Now);

            int option = 0;
            do
            {
                PrintOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch
                {

                }
                if (option == 1) { RegisterNewExpense(user); }
                else if (option == 2) { CheckAllExpenses(user); }
                else if (option == 3) { break; }
                else { option = 0; }
            }
            while (option != 3);
            Console.WriteLine("Thank you, have a nice day");
        }
    }
}