namespace Politick.Api.Services;
using Politick.Api.Data;

public static class TopicService
{
    public static int TopicCount => Topics.Length;
    public static readonly Topic[] Topics = new Topic[]
    {
        new Topic("Abortion", "Debate with someone about abortion", "", new Side[]
        {
            new("Support", "You believe that abortion should be legal, and that regulations should be put in place to prevent it from being made illegal.", new string[] { "Left", "Authoritarian" }),
            new("Support", "You believe that abortion should be legal.", new string[] { "Left" }),
            new("Neutral", "You do not support or oppose abortion, but believe that it should not be regulated by government in the first place.", new string[] { "Libertarian" }),
            new("Oppose", "You believe that abortion should be illegal, but with some exceptions (rape, health-risk to mother, etc.)", new string[] { "" }),
            new("Oppose", "You believe that abortion should be entirely illegal, without exception.", new string[] { "Authoritarian", "Right" }),
            new("Other", "You have an opinion that is not listed", new string[] { "Other" })
        }),
        new Topic("Climate Change", "Debate with someone about climate change", "", new Side[]
        {
            new("It's a complete hoax", "You believe that the theory climate change is entirely fabricated.", new string[] { "Right" }),
            new("We need to fix this NOW", "You believe that climate change is a real threat, and that governments should take legal action to fight it.", new string[] { "Left", "Authoritarian" }),
            new("We could do better...", "You don't necessarily believe that climate change is real or fake, but that we could definitely do better at taking care of our planet.", new string[] { "" }),
            new("Get off my lawn", "Whether or not climate change is real, government should not make regulations or pass laws about it.", new string[] { "Libertarian" }),
            new("Free market", "You believe that climate change may be real in one way or another, but that a free-market solution is better than a government solution.", new string[] { "Right", "Libertarian" }),
            new("We need to fix this", "You believe that climate change is a real threat.", new string[] { "Left" }),
            new("Other", "You have an opinion that is not listed", new string[] { "Other" })
        }),
        new Topic("Gun Control", "Debate with someone about gun control", "", new Side[]
        {
            new("Support", "You believe that guns are a threat to public safety, and should be made entirely illegal.", new string[] { "Left", "Authoritarian" }),
            new("Support", "You believe that guns are a threat to public safety, but only certain ones should be made illegal.", new string[] { "Left" }),
            new("Moderate", "You believe that guns shouldn't necessarily be banned or restricted, but that we should instead put in place gun-safety measures (education, training, mental health screening, etc.).", new string[] { "" }),
            new("Oppose", "You believe that guns are a constitutional right, and that the government should not pass any laws regulating guns.", new string[] { "Right", "Libertarian" }),
            new("Other", "You have an opinion that is not listed", new string[] { "Other" })
        }),
        new Topic("Health Care", "Debate with someone about health care", "", new Side[]
        {
            new("Free for everyone", "You believe that the government should provide universal health care.", new string[] { "Left" }),
            new("Hybrid system (\"Public Option\")", "You believe that citizens should be given a choice between government and private insurance options.", new string[] { "" }),
            new("No private insurance (\"Single-Payer\")", "You believe that the government should provide universal health care, and that private insurance companies should not be allowed.", new string[] { "Left", "Authoritarian" }),
            new("Free market", "You believe that the free market, through competition and consumer choice, is a better health care option than a government-run health care system.", new string[] { "Right", "Libertarian" }),
            new("Other", "You have an opinion that is not listed", new string[] { "Other" })
        })
    };
}
