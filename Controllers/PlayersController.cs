using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using myFutsalApp.Models;
using myFutsalApp.Models.PlayersPage;

namespace myFutsalApp.Controllers;

public class PlayersController : Controller
{
    //Base URL for HTTP requests
    string BaseUrl = "https://localhost:7120/";

    public async Task<IActionResult> Index()
    {

        List<Player?>? playersData = new List<Player?>();
        PlayersPageModel pageModel = new PlayersPageModel();

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

                pageModel.PlayerList = playersData;
            }
            else
            {
                TempData["status"] = Res.StatusCode.ToString();
            }

            //return player list to view
            return View(pageModel);
        }
    }

    [HttpPost("players/search")]
    public async Task<IActionResult> Search(PlayersPageModel model)
    {
        Console.WriteLine("\nSearch\n");
        List<Player?>? playersData = new List<Player?>();

        PlayersPageModel searchFilters = model;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();

            //Define request data format
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Sending request to find web api REST service resource GetAllEmployees using HttpClient

            string? queryName = searchFilters.FilterModel?.Name;
            string? queryField = searchFilters.FilterModel?.Field;
            string? queryOrder = searchFilters.FilterModel?.Order;

            HttpResponseMessage Res;

            ////////////////DIFFERENT SQL SEARCH////////////////

            if (queryName == null)
            {
                Res = await client.GetAsync($"player/search/{queryField}/{queryOrder}/");
            }
            else
            {
                Res = await client.GetAsync($"player/search/{queryName}/{queryField}/{queryOrder}/");
            }

            if (Res.IsSuccessStatusCode)
            {
                //if successful, store Json Data
                var PlayersResponse = Res.Content.ReadAsStringAsync().Result;

                Console.WriteLine(PlayersResponse); ////Print the data

                //Deserialise the response + store into List
                playersData = JsonConvert.DeserializeObject<List<Player?>>(PlayersResponse);

                searchFilters.PlayerList = playersData;
            }
            else
            {
                TempData["status"] = Res.StatusCode.ToString();
            }

            //return player list to view
            return View("index", searchFilters);
        }
    }



    ///Delete
    [HttpPost]
    public async Task<IActionResult> Index(PlayersPageModel model)
    {
        Console.WriteLine("\n\nDelete\n\n");
        int? id = model.PlayerIdDelete;

        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(BaseUrl);

            HttpResponseMessage Res = await client.DeleteAsync($"player/delete/{id}");

            if (!Res.IsSuccessStatusCode)
            {
                TempData["status"] = Res.StatusCode.ToString();
                return View("index");
            }

            return RedirectToAction();
        }
    }
}