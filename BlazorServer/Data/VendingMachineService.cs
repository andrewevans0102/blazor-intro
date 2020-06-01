using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlazorServer.Data
{
    public class VendingMachineService
    {
        public Task<List<Drink>> RetrieveDrinks()
        {
            List<Drink> drinks = new List<Drink>();
            drinks.Add(new Drink
            {
                name = "Water",
                cost = "$00.50"
            });
            drinks.Add(new Drink
            {
                name = "Soda",
                cost = "$1.00"
            });
            drinks.Add(new Drink
            {
                name = "Coffee",
                cost = "$1.50"
            });
            drinks.Add(new Drink
            {
                name = "Orange Juice",
                cost = "$2.00"
            });

            return Task.FromResult(drinks);
        }

        public Task<string> DispenseDrinks(string name, string cash)
        {
            List<Drink> drinks = new List<Drink>();
            drinks.Add(new Drink
            {
                name = "Water",
                cost = "$00.50"
            });
            drinks.Add(new Drink
            {
                name = "Soda",
                cost = "$1.00"
            });
            drinks.Add(new Drink
            {
                name = "Coffee",
                cost = "$1.50"
            });
            drinks.Add(new Drink
            {
                name = "Orange Juice",
                cost = "$2.00"
            });

            Drink drinkRequest = drinks.Find(x => x.name.Equals(name));

            string response = "";

            if (drinkRequest == null)
            {
                response = "drink was not found";
            }
            else
            {
                cash = cash.Replace("$", "");
                drinkRequest.cost = drinkRequest.cost.Replace("$", "");
                double cashSent = Double.Parse(cash);
                double cashRequired = Double.Parse(drinkRequest.cost);

                if (cashSent == cashRequired)
                {
                    response = "here is your drink, you inserted the correct amount";
                }
                else
                {

                    if (cashSent < cashRequired)
                    {
                        double differenceLess = cashRequired - cashSent;
                        response = "you did not provide enough money, please insert an additional $" + differenceLess.ToString("F");
                    }
                    else if (cashSent > cashRequired)
                    {
                        double differenceMore = cashSent - cashRequired;
                        response = "you provided too much money, you will get back $" + differenceMore.ToString("F");
                    }
                }
            }

            return Task.FromResult(response);
        }
    }
}
