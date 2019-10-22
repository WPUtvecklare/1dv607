namespace BlackJack.model.rules
{
    interface IHitStrategy
    {
        bool DoHit(model.Player a_dealer);
    }
}
