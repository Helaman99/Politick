using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Politick.Api.Data;

public class Player : IdentityUser
{
    public string Title { get; set; }
    public string Avatar { get; set; }
    public int CoinsTotal { get; set; }
    public int KudosTotal { get; set; }
    public int GamesTotal { get; set; }
    public int KudosOverall { get; set; }
    public int Authoritarian { get; set; }
    public int Left { get; set; }
    public int Libertarian { get; set; }
    public int Right { get; set; }
    public string UnlockedTitleFirstWords { get; set; }
    public string UnlockedTitleSecondWords { get; set; }
    public string UnlockedAvatars { get; set; }
    public int Strikes { get; set; }
    //public int BannedDay { get; set; }
    public string Theme { get; set; }

    public Player(string email) : base()
    {
        UserName = email;
        Email = email;
        Title = "Angry Tortoise";
        Avatar = "/Basic/starting_avatar_1.png";
        CoinsTotal = 0;
        KudosTotal = 0;
        GamesTotal = 0;
        KudosOverall = 0;
        Authoritarian = 0;
        Left = 0;
        Libertarian = 0;
        Right = 0;
        UnlockedTitleFirstWords = "Angry+Helpful+Slimy+Scared";
        UnlockedTitleSecondWords = "Tortoise+Explorer+Marshmallow+Racer";
        UnlockedAvatars = "/Basic/starting_avatar_1.png+/Basic/starting_avatar_2.png+/Basic/starting_avatar_3.png+/Basic/starting_avatar_4.png";
        Strikes = 0;
        //BannedDay = 0;
        Theme = "light";
    }

    public void IncAuthoritarian() { Authoritarian++; }
    public void IncLeft() { Left++; }
    public void IncLibertarian() { Libertarian++; }
    public void IncRight() { Right++; }

    public void AddTitleFirstWords(string[] newWords)
    {
        if (!newWords.IsNullOrEmpty())
            foreach (string word in newWords)
                UnlockedTitleFirstWords += $"+{word}";
        else throw new ArgumentNullException(nameof(newWords));
    }
    public void AddTitleSecondWords(string[] newWords)
    {
        if (!newWords.IsNullOrEmpty())
            foreach (string word in newWords)
                UnlockedTitleSecondWords += $"+{word}";
        else throw new ArgumentNullException(nameof(newWords));
    }

    public void AddAvatar(string avatar)
    {
        if (avatar is not null)
            UnlockedAvatars += $"+{avatar}";
        else throw new ArgumentNullException(nameof(avatar));
    }
}
