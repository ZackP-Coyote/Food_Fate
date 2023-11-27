using System;
using System.Net.Http;
using System.Threading.Tasks;

class Lookup
{
    static async Task Main(string[] args)
    {
        // Insert your Yelp Fusion API key here
        string apiKey = GetMyKey.ApiKey();

        string baseUrl = "https://api.yelp.com/v3/";
        string businessId = "CHANGE ME!!";

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            // Construct the request URL with the business ID
            string requestUrl = $"{baseUrl}/businesses/{businessId}";

            HttpResponseMessage response = await client.GetAsync(requestUrl);

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
