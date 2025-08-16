using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ATDDotNetTrainingBatch2.DISample.ConsoleClientApp
{
    public class RestClientService
    {
        public async Task RunAsync()
        {
            //await ReadAsync();
            await CreateAsync();
        }
        private async Task ReadAsync()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest("https://localhost:7131/api/ProductV2/List/1/10", Method.Get);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json =  response.Content!;
                Console.WriteLine(json);
            }

        }

        private async Task CreateAsync()
        {
            var item = new ProductModel
            {
                IsDelete = false,
                Price = 100,
                ProductCode = "Test",
                ProductItem = "Test Name"
            };
            //var jsonStr = JsonConvert.SerializeObject(item);
            //Console.WriteLine(jsonStr);

            //StringContent content = new StringContent(jsonStr, Encoding.UTF8, Application.Json);

            //HttpClient client = new HttpClient();
            //var response = await client.PostAsync("https://localhost:7131/api/ProductV2", content);

            RestClient client = new RestClient();
            RestRequest request = new RestRequest("https://localhost:7131/api/ProductV2", Method.Post);
            request.AddJsonBody(item);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content!;
                Console.WriteLine(json);
            }
            

        }

        private async Task UpdateAsync()
        {
            var item = new ProductModel
            {
                IsDelete = false,
                Price = 100,
                ProductCode = "Test",
                ProductItem = "Test Name",
                ProductId = 25
            };
            //var jsonStr = JsonConvert.SerializeObject(item);
            //Console.WriteLine(jsonStr);

            //StringContent content = new StringContent(jsonStr, Encoding.UTF8, Application.Json);

            //HttpClient client = new HttpClient();
            //var response = await client.PutAsync($"https://localhost:7131/api/ProductV2/{item.ProductId}", content);

            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"https://localhost:7131/api/ProductV2/{item.ProductId}", Method.Patch);
            request.AddJsonBody(item);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json =  response.Content!;
                Console.WriteLine(json);
            }

        }

        private async Task DeleteAsync()
        {
            //HttpClient client = new HttpClient();
            //var response = await client.DeleteAsync("https://localhost:7131/api/ProductV2/List/24");
            
            RestClient client = new RestClient();
            RestRequest request = new RestRequest($"https://localhost:7131/api/ProductV2/၂၄", Method.Delete);
           
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json =  response.Content!;
                Console.WriteLine(json);
            }
        }

        public partial class ProductModel
        {
            public int ProductId { get; set; }

            public string ProductCode { get; set; } = null!;

            public string ProductItem { get; set; } = null!;

            public decimal Price { get; set; }

            public bool IsDelete { get; set; }
        }
    }
}
