using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Management;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

public class YelpApi
{
    public async Task Main(string[] args)
    {

        string shopSearch = args[2];
        string radiusInMeters = args[1];
        string searchArea = args[0];


        int radInMeters = int.Parse(radiusInMeters);
        radInMeters = radInMeters * 1609;
        if (radInMeters > 40000)
        {
            radInMeters = 40000;
        }
        else if (radInMeters < 1000)
        {
            radInMeters = 1000;
        }


        if (shopSearch == null)
        {
            shopSearch = "restaurant";
        }
        
        
        if (searchArea == null)
        {
            searchArea = "San Bernardino, CA";
        }

        // Information to be searched
        var parameters = new Dictionary<string, string>
        {
            { "term", shopSearch },
            { "radius", radiusInMeters },
            { "location", searchArea }
        };

        shopSearch = shopSearch.Replace(" ", "_");
        searchArea = searchArea.Replace(" ", "_");
        

        string apiKey = GetMyKey.ApiKey();
        string endpoint = "https://api.yelp.com/v3/businesses/search" + "?" + "term=" + shopSearch + "&location=" + searchArea + "&radius=" + radInMeters;
        string authorizationHeader = "Bearer " + apiKey;

        List<string[]> allBusinessInfo = new List<string[]>();
        //int numBusinesses = 50;

        // Make request to Yelp API
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", authorizationHeader);

            var queryString = new FormUrlEncodedContent(parameters);
            var request = new RestRequest();

            //request.AddJsonBody(parameters.ToString(), DataFormat.Json);
            //request.AddParameter(parameters);
            //request.AddStringBody(payload.ToString(), "application/json");
            //request.AddStringBody(payload.ToString(), DataFormat.Json);


            var response = await client.GetAsync(endpoint).Result.Content.ReadAsStringAsync();


            var jsonString = response;
            var content = JsonConvert.DeserializeObject<YelpApiResponse>(jsonString);
            var businesses = content.Businesses;

            foreach (var business in businesses)
            {
                string[] businessSet =
                {
                        business.Id,
                        business.Name,
                        business.Is_closed.ToString(),
                        business.Rating.ToString(),
                        business.Image_url,
                        business.Url,
                        business.Location.Address1
                    };
                allBusinessInfo.Add(businessSet);
            }

            // Shuffle the list of businesses
            Shuffle(allBusinessInfo);


        }
    }

    // Shuffle the list of businesses
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
        public List<Business> Businesses { get; set; }
    }

    public class Business
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Is_closed { get; set; }
        public double Rating { get; set; }
        public string Image_url { get; set; }
        public string Url { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public string Address1 { get; set; }
    }
}

public class GetMyKey
{
    public static string ApiKey()
    {
        return "rU9x88OG4P4xmlrQAiuq44l6DLl0wpVy8CKzKQeXnj72Xz086wx46zMjGwPLsgLXqZ9s4SG0LWZvV-JoS_XPGWy2HMx-psS3rXEsr9xvij8RSLevnlQRd_djeAgnZXYx";
    }
}
