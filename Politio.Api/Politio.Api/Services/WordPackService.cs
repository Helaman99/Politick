using Politio.Api.Data;
namespace Politio.Api.Services;

public class WordPackService
{
    public WordPackService() { }

    public WordPack BasicList = new("Basic Words", new string[] {"word1", "word2"});
}
