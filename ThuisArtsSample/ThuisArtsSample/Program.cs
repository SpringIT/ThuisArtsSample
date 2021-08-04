using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThuisArtsSample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Create http client with nuget package
            var client = RestEase.RestClient.For<IThuisArtsApi>("https://webservice.thuisarts.nl/");

            //Username and password for ThuisArts

            var username = "test"; //Fill this if you don't wanna use command line arguments
            var password = "test"; //Fill this if you don't wanna use command line arguments

            if (args.Length > 1)
            {
                username = args[0];
                password = args[1];
            }

            Console.WriteLine("Prepare login data");
            var data = new Dictionary<string, object>
            {
                {"name", username},
                {"pass", password},
                {"form_id", "user_login_form"}
            };

            Console.WriteLine("Starting to login");
            var response = await client.Login(data);

            if (!response.ResponseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("Login failed");
                return;
            }
            Console.WriteLine("Login successful");

            Console.WriteLine("Get token for subject request");
            string token = await client.GetToken();

            //Set token on client so it sends it in the header as configured in the interface
            client.Token = token;

            Console.WriteLine("Get subjects");
            var subjects = await client.GetSubjects("json");

            Console.WriteLine($"Found {subjects.Data.Count} articles");
            Console.ReadKey();
        }
    }
}
