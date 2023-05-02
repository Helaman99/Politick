using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Politio.Api.Data;

public class MyString
{
    [Key]
    public int Id { get; set; }
    public string? Value { get; set; }

    public MyString() { }
    public MyString(int id, string value)
    {
        Id = id;
        Value = value;
    }
}

public class Player
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [JsonIgnore]public string Email { get; set; }
    [JsonIgnore]public string Password { get; set; }
    public string Title { get; set; }
    public string Avatar { get; set; }
    public int CoinsTotal { get; set; }
    public int GudosTotal { get; set; }
    public int GamesTotal { get; set; }
    public int KudosOverall { get; set; }
    public int Authoritarian { get; set; }
    public int Left { get; set; }
    public int Libertarian { get; set; }
    public int Right { get; set; }
    public List<MyString> UnlockedTitleFirstWords { get; }
    public List<MyString> UnlockedTitleSecondWords { get; }
    public List<MyString> UnlockedAvatars { get; }
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
        Authoritarian = 0;
        Left = 0;
        Libertarian = 0;
        Right = 0;
        UnlockedTitleFirstWords = new List<MyString> { new MyString(1, "Angry"), new MyString(2, "Helpful"), new MyString(3, "Slimy"),
                                                        new MyString(4, "Scared") };
        UnlockedTitleSecondWords = new List<MyString> { new MyString(1, "Banana"), new MyString(2, "Explorer"), new MyString(3, "Marshmallow"), 
                                                         new MyString(4, "Racer") }; ;
        UnlockedAvatars = new List<MyString> { new MyString(1, "starting_avatar_1.png"), new MyString(2, "starting_avatar_2.png"), 
                                                new MyString(3, "starting_avatar_3.png"), new MyString(4, "starting_avatar_4.png") };
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

    public void IncAuthoritarian() { Authoritarian++; }
    public void IncLeft() { Left++; }
    public void IncLibertarian() { Libertarian++; }
    public void IncRight() { Right++; }

    public void AddTitleFirstWords(string[] newWords)
    {
        if (!newWords.IsNullOrEmpty())
            foreach (string word in newWords)
                UnlockedTitleFirstWords.Add(new MyString(UnlockedTitleFirstWords.Count + 1, word));

        throw new ArgumentNullException(nameof(newWords));
    }
    public void AddTitleSecondWords(string[] newWords)
    {
        if (!newWords.IsNullOrEmpty())
            foreach (string word in newWords)
                UnlockedTitleSecondWords.Add(new MyString(UnlockedTitleSecondWords.Count + 1, word));

        throw new ArgumentNullException(nameof(newWords));
    }

    public void AddAvatar(string avatar)
    {
        if (avatar is not null)
            UnlockedAvatars.Add(new MyString(UnlockedAvatars.Count + 1, avatar));
        
        throw new ArgumentNullException(nameof(avatar));
    }
}
