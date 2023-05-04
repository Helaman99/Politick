using Microsoft.AspNetCore.Mvc;

namespace Politio.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ShopController
{
    public ShopController() { }

    [HttpGet("GetAvatars")]
    public IEnumerable<string> GetAvatars()
    {
        return Directory.EnumerateFiles("../../Politio/src/assets/avatars/").Select(f => Path.GetFileName(f)).ToList();
    }
}
