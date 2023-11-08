namespace Politick.Api.Models;

public class CoinPack
{
    public int CoinCount { get; set; }
    public int Price { get; set; }

    public CoinPack(int coinCount, int price)
    {
        CoinCount = coinCount;
        Price = price;
    }
}
