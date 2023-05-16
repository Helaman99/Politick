namespace Politick.Api.Services;

public class ShopService
{
    public string[] GetAvatarImages()
        => Directory.GetFiles("../Assets/Avatars");
}
