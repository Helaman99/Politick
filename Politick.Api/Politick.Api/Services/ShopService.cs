using Microsoft.IdentityModel.Tokens;
using Politick.Api.Models;

namespace Politick.Api.Services;

public class ShopService
{
    public static readonly List<CoinPack> CoinPacks = new List<CoinPack> 
    { 
        new CoinPack(2, 2),
        new CoinPack(5, 4),
        new CoinPack(10, 7),
    };

    public List<string> GetBasicAvatarImages()
    {
        List<string> fileNames = new();
        foreach (string path in Directory.GetFiles("./Assets/Avatars/Basic"))
        {
            fileNames.Add("/Basic/" + Path.GetFileName(path));
        }
        return fileNames;
    }

    public List<string> GetPremiumAvatarImages()
    {
        List<string> fileNames = new();
        foreach (string path in Directory.GetFiles("./Assets/Avatars/Premium"))
        {
            fileNames.Add("/Premium/" + Path.GetFileName(path));
        }
        return fileNames;
    }


    public string GetAvatarImage(string fileName)
        => "./Assets/Avatars" + fileName;

    public bool VerifyCoinPack(CoinPack coinPack)
    {
        if (CoinPacks.Where(x => x.CoinCount == coinPack.CoinCount && x.Price == coinPack.Price).IsNullOrEmpty())
        {
            return false;
        }
        return true;
    }
}
