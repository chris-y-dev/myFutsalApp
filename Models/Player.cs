namespace myFutsalApp.Models;

public class Player
{
    public int Id { get; set; }

    public string NickName { get; set; } = string.Empty;

    public string Thumbnail { get; set; } = string.Empty;

    public string Flag { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    //stats
    public int Pace { get; set; }

    public int Shooting { get; set; }

    public int Passing { get; set; }

    public int Dribbling { get; set; }

    public int Defending { get; set; }

    public int Physical { get; set; }

    public int Overall { get; set; }

    public int SkillMoves { get; set; }

    public int WeakFoot { get; set; }
}
