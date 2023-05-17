namespace Politick.Api.Services;

public class ShopService
{
    public List<string> GetAvatarImages()
    {
        List<string> fileNames = new();
        foreach (string path in Directory.GetFiles("./Assets/Avatars"))
        {
            fileNames.Add(Path.GetFileName(path));
        }
        return fileNames;
    }
       

    public string GetAvatarImage(string fileName)
        => "./Assets/Avatars/" + fileName;
}
