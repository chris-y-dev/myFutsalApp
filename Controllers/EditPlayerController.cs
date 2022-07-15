using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using myFutsalApp.Models.PlayersPage;
using myFutsalApp.Models;

public class EditPlayerController : Controller
{
    string BaseUrl = "https://localhost:7120/";

    [HttpPost("editplayer/{Id}")]
    public ActionResult Index(int id)
    {
        Console.WriteLine($"\n\nPost called\n\n");
        TempData["playerId"] = id;
        return Redirect("~/Editplayer");
    }

    [HttpGet]
    /////Get the player's data + auto add to form
    public async Task<IActionResult> Index()
    {
        var id = TempData["playerId"];

        //retrieve player object
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage Res = await client.GetAsync($"player/id/{id}");

            if (Res.IsSuccessStatusCode)
            {
                var playerRes = Res.Content.ReadAsStringAsync().Result;

                Player? playerData = JsonConvert.DeserializeObject<Player?>(playerRes);

                return View(playerData);
            }
            else
            {
                TempData["status"] = Res.StatusCode.ToString();
                return View();
            }
        }
    }

    //Post player data + change to Players page
    [HttpPost]
    public async Task<IActionResult> Index(Player player)
    {
        // PlayersPageModel pageModel = model;
        Player? selectedPlayer = player;

        selectedPlayer.Overall = (int)Math.Round(((selectedPlayer.Pace + selectedPlayer.Shooting + selectedPlayer.Passing + selectedPlayer.Dribbling + selectedPlayer.Defending + selectedPlayer.Physical) / 6.0), 0);

        string putUrl = BaseUrl + "player/edit/" + selectedPlayer.Id;

        using (var client = new HttpClient())
        {
            //
            var Res = await client.PutAsJsonAsync<Player>(putUrl, selectedPlayer);

            if (Res.IsSuccessStatusCode)
            {
                // TempData["status"] = Res.StatusCode.ToString();
                return Redirect("~/Players");
            }
            else
            {
                Console.WriteLine($"\n\n{Res.StatusCode}\n\n");
                TempData["status"] = Res.StatusCode.ToString();
                return Redirect("~/Players");
            }
        }
    }
}