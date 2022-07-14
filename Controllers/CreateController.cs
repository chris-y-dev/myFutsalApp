using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using myFutsalApp.Models;

public class CreateController : Controller
{
    string BaseUrl = "https://localhost:7120/";


    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(Player newPlayer)
    {
        Player player = newPlayer;

        player.Overall = (int)Math.Round(((player.Pace + player.Shooting + player.Passing + player.Dribbling + player.Defending + player.Physical) / 6.0), 0);

        string postUrl = BaseUrl + "player";

        using (var client = new HttpClient())
        {
            //
            var Res = await client.PostAsJsonAsync<Player>(postUrl, player);

            if (Res.IsSuccessStatusCode)
            {
                TempData["status"] = Res.StatusCode.ToString();
                return RedirectToAction("Index");
            }
            else
            {
                TempData["status"] = Res.StatusCode.ToString();
                return View();
            }
        }
    }
}