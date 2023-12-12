using RestSharp;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static YelpApi;

public class LookUp
{
    public async Task<string[]> BL(string args)
    {
        // Insert your Yelp Fusion API key here
        string apiKey = GetMyKey.ApiKey();

        string businessId = args;
        string baseUrl = "https://api.yelp.com/v3/" + businessId;


        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

            // Construct the request URL with the business ID
            var request = new RestRequest();
            //Request info for the Api
            var response = await client.GetAsync(baseUrl).Result.Content.ReadAsStringAsync();

            string jSonRespose = response;
            var businessDetails = JsonConvert.DeserializeObject<Business>(jSonRespose);

            //get the information from the Api
            string id = businessDetails.Id;
            string name = businessDetails.Name;
            //string address = businessDetails.Location.Address1;
            string rating = businessDetails.Rating.ToString();
            string url = businessDetails.Url;
            string image = businessDetails.Image_url;

            //make into a string array
            string[] businessInfo = { id, name/*, address*/, rating, url, image };

            //return the string array
            return businessInfo;


        }
    }
}