using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using myFutsalApp.Models;

namespace myFutsalApp.Controllers;

public class PlayersController : Controller
{
    //Base URL for HTTP requests
    string BaseUrl = "https://localhost:7120/";

    public async Task<IActionResult> Index()
    {

        List<Player?>? playersData = new List<Player?>();
        using (var client = new HttpClient())
        {
            //Passing service base url
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();

            //Define request data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Sending request to find web api REST service resource GetAllEmployees using HttpClient
            HttpResponseMessage Res = await client.GetAsync("player/allplayers");

            if (Res.IsSuccessStatusCode)
            {
                //if successful, store Json Data
                var PlayersResponse = Res.Content.ReadAsStringAsync().Result;

                Console.WriteLine(PlayersResponse); ////Print the data
                //Deserialise the response + store into List
                playersData = JsonConvert.DeserializeObject<List<Player?>>(PlayersResponse);
            }

            //return player list to view
            return View(playersData);
        }
    }


    // [HttpPost]
    // public ActionResult Index(string name, string field, string order)
    // {

    // }
}