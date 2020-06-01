using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Net.Http;

namespace AzureFunctions
{
    public static class DispenseDrinks
    {
        [FunctionName("DispenseDrinks")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "drinks/dispense")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("POST request");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

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

            string name = data.name;
            string cash = data.cash;

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

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(response, Formatting.Indented), Encoding.UTF8, "application/json")
            };
        }
    }
}
