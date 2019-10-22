namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Dealer a_dealer, Player a_player)
        {
            bool showCard = true;
            bool hideCard = false;

            a_dealer.Deal(a_player, showCard);
            a_dealer.Deal(a_dealer, showCard);
            a_dealer.Deal(a_player, showCard);
            a_dealer.Deal(a_dealer, hideCard);

            return true;
        }
    }
}
