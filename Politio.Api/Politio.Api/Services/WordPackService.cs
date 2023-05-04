using Politio.Api.Data;
namespace Politio.Api.Services;

public class WordPackService
{
    public readonly WordPack[] WordPacks = new WordPack[] {
        new("Basic Words", new string[] {"word1", "word2"}),
        new("Basic Words", new string[] {"word1", "word2"})
    };
}
