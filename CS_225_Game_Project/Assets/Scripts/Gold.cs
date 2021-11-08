public class Gold : CoinDecorator
{
    private int GoldWorth = 20;

    // Constructor
    public Gold(ICoin coin) : base(coin) { }
    public override int GetWorth()
    {
        return base.GetWorth() + GoldWorth;
    }
}
