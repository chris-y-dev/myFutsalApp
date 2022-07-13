using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace myFutsalApp.Controllers;

public class PlayersController : Controller
{
    // 
    // GET: /HelloWorld/

    public IActionResult Index()
    {
        return View();
    }

    // 
    // GET: /HelloWorld/Welcome/ 

    public string Welcome(string name, int numTimes = 1)
    {
        //HTML enconder protects from malicious input

        return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
    }
}