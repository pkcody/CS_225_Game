public class Diomand : CoinDecorator
{
    private int DiomandWorth = 50;

    // Constructor
    public Diomand(ICoin coin) : base(coin) { }
    public override int GetWorth()
    {
        return base.GetWorth() + DiomandWorth;
    }
}
