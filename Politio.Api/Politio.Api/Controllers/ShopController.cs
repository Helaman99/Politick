using Microsoft.AspNetCore.Mvc;

namespace Politio.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ShopController
{
    public ShopController() { }

    [HttpGet("GetAvatars")]
    public string[] GetAvatars()
    {
        return Directory.GetFiles("../../../Politio/src/assets/avatars/");
    }
}
