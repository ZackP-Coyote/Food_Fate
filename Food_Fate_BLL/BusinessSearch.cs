using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

class YelpApi
{
    static async Task Main(string[] args)
    {
        // Define API Key
        string apiKey = GetMyKey();
        string endpoint = "https://api.yelp.com/v3/businesses/search";
        string authorizationHeader = "Bearer " + apiKey;


        string shopSearch = "lunch"; // TODO: Change this to the user's search
        string radiusInMeters = "10000"; // TODO: Change this to the user's search
        string searchArea = "San Bernadino"; // TODO: Change this to the user's search

        // Information to be searched
        Dictionary<string, string> parameters = new Dictionary<string, string>
        {
            { "term", shopSearch },
            { "limit", "50" },
            { "radius", radiusInMeters },
            { "location", searchArea }
        };

        List<string[]> allBusinessInfo = new List<string[]>();
        int numBusinesses = int.Parse(parameters["limit"]);

        // Make request to Yelp API
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", authorizationHeader);

            var queryString = new FormUrlEncodedContent(parameters);
            var response = await client.GetAsync(endpoint + "?" + await queryString.ReadAsStringAsync());

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<YelpApiResponse>(jsonString);
                var businesses = content.businesses;

                foreach (var business in businesses)
                {
                    string[] businessSet =
                    {
                        business.id,
                        business.name,
                        business.is_closed.ToString(),
                        business.rating.ToString(),
                        business.image_url,
                        business.location.address1
                    };
                    allBusinessInfo.Add(businessSet);
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }

        // Shuffle the list of businesses
        Shuffle(allBusinessInfo);
    }

    static string GetMyKey()
    {
        
        return "rU9x88OG4P4xmlrQAiuq44l6DLl0wpVy8CKzKQeXnj72Xz086wx46zMjGwPLsgLXqZ9s4SG0LWZvV-JoS_XPGWy2HMx-psS3rXEsr9xvij8RSLevnlQRd_djeAgnZXYx";
    }

    //Shuffle the list of businesses
    static void Shuffle<T>(List<T> list)
    {
        Random rng = new Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    // Define classes to deserialize JSON response
    public class YelpApiResponse
    {
        public List<Business> businesses { get; set; }
    }

    public class Business
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool is_closed { get; set; }
        public double rating { get; set; }
        public string image_url { get; set; }
        public Location location { get; set; }
    }

    public class Location
    {
        public string address1 { get; set; }
    }
}
