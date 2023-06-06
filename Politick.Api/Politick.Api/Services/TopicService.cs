namespace Politick.Api.Services;
using Politick.Api.Data;

public static class TopicService
{
    public static int TopicCount => Topics.Length;
    public static readonly Topic[] Topics = new Topic[]
    {
        new Topic("Topic 1", "This is topic 1", "/src/assets/topic_images/astronaut-synthwave.jpg", new Side[]
        {
            new("Topic 1 - Side 1", "This is side 1", new string[] { "Standing1", "Standing2" }),
            new("Topic 1 - Side 2", "This is side 2", new string[] { "Standing" })
        }),
        new Topic("Topic 2", "This is topic 2", "/src/assets/topic_images/astronaut-synthwave.jpg", new Side[]
        {
            new("Topic 2 - Side 1", "This is side 1", new string[] { "Standing" }),
            new("Topic 2 - Side 2", "This is side 2", new string[] { "Standing" })
        })
    };
}
