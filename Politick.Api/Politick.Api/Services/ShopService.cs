namespace Politick.Api.Services;

public class ShopService
{
    public List<string> GetBasicAvatarImages()
    {
        List<string> fileNames = new();
        foreach (string path in Directory.GetFiles("./Assets/Avatars/Basic"))
        {
            fileNames.Add(Path.GetFileName(path));
        }
        return fileNames;
    }

    public List<string> GetPremiumAvatarImages()
    {
        List<string> fileNames = new();
        foreach (string path in Directory.GetFiles("./Assets/Avatars/Premium"))
        {
            fileNames.Add(Path.GetFileName(path));
        }
        return fileNames;
    }


    public string GetBasicAvatarImage(string fileName)
        => "./Assets/Avatars/Basic/" + fileName;

    public string GetPremiumAvatarImage(string fileName)
        => "./Assets/Avatars/Premium/" + fileName;
}
