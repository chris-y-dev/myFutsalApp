using myFutsalApp.Models.PlayersPage;
using myFutsalApp.Models;

namespace myFutsalApp.Models.PlayersPage;

public class PlayersPageModel
{
    public Player? PlayerModel { get; set; }

    public IEnumerable<Player>? PlayerList { get; set; } = new List<Player>();

    public PlayerSearchFilter? FilterModel { get; set; }
}