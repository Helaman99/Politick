using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Politio.Api.Data;

public class Player
{
    [Key]public string Email { get; set; }
    [JsonIgnore]public string Password { get; set; }
    public string Title { get; set; }
    public string Avatar { get; set; }
    public int CoinsTotal { get; set; }
    public int GudosTotal { get; set; }
    public int GamesTotal { get; set; }
    public int KudosOverall { get; set; }
    public List<int>? ModeChoices { get; set; }
    public List<int> StandingChoices { get; set; }
    public List<string> UnlockedTitleFirstWords { get; }
    public List<string> UnlockedTitleSecondWords { get; }
    public List<string> UnlockedAvatars { get; }
    public int Strikes { get; set; }
    public string Theme { get; set; }
    public bool Activated { get; set; }
    public string ActualStanding { get; set; }

    public Player(string email, string password)
    {
        Email = email;
        Password = password;
        Title = "Scared Banana";
        Avatar = "starting_avatar_1.png";
        CoinsTotal = 0;
        GudosTotal = 0;
        GamesTotal = 0;
        KudosOverall = 0;
        ModeChoices = null;
        StandingChoices = new List<int> { 0, 0, 0, 0 }; // Authoritarian, Left, Libertarian, Right
        UnlockedTitleFirstWords = new List<string> { "Angry", "Helpful", "Slimy", "Scared" };
        UnlockedTitleSecondWords = new List<string> { "Banana", "Explorer", "Marshmallow", "Racer" }; ;
        UnlockedAvatars = new List<string> { "starting_avatar_1.png", "starting_avatar_2.png", "starting_avatar_3.png", "starting_avatar_4.png", };
        Strikes = 0;
        Theme = "light";
        Activated = false;
        ActualStanding = "Unknown";
    }

    public string GetData()
    {
        return JsonSerializer.Serialize(this);
    }

    public bool CheckPassword(string password)
    {
        return Password.CompareTo(password) == 0;
    }

    public void IncAuthoritarian() { StandingChoices[0]++; }
    public void IncLeft() { StandingChoices[1]++; }
    public void IncLibertarian() { StandingChoices[2]++; }
    public void IncRight() { StandingChoices[3]++; }

    public void AddTitleFirstWords(string[] newWords)
    {
        if (!newWords.IsNullOrEmpty())
            foreach (string word in newWords)
                UnlockedTitleFirstWords.Add(word);

        throw new ArgumentNullException(nameof(newWords));
    }
    public void AddTitleSecondWords(string[] newWords)
    {
        if (!newWords.IsNullOrEmpty())
            foreach (string word in newWords)
                UnlockedTitleSecondWords.Add(word);

        throw new ArgumentNullException(nameof(newWords));
    }

    public void AddAvatar(string avatar)
    {
        if (avatar is not null)
            UnlockedAvatars.Add(avatar);
        
        throw new ArgumentNullException(nameof(avatar));
    }
}
