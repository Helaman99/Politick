namespace Politick.Api.Services;

public class ShopService
{
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
}
