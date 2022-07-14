using Microsoft.AspNetCore.Mvc;
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



    }
}