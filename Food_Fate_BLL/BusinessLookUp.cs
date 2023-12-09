using RestSharp;
using System;
using System.Net.Http;
using System.Threading.Tasks;

class Lookup
{
    static async Task Main(string[] args)
    {
        // Insert your Yelp Fusion API key here
        string apiKey = GetMyKey.ApiKey();

        string businessId = "CHANGE ME!!";
        string baseUrl = "https://api.yelp.com/v3/" + businessId;
        

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

            // Construct the request URL with the business ID
            var request = new RestRequest(baseUrl);

            HttpResponseMessage response = await client.GetAsync(baseUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent); // Output the response content (JSON data)
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
            
        }
    }
}
