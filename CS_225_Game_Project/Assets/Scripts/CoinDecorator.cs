abstract public class CoinDecorator : ICoin
{
    protected ICoin DecCoin;
    public CoinDecorator(ICoin coin)
    {
        DecCoin = coin;
    }
    public virtual int GetWorth()
    {
        return DecCoin.GetWorth();
    }
}

