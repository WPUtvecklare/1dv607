namespace BlackJack.model.rules
{
    interface INewGameStrategy
    {
        bool NewGame(Dealer a_dealer, Player a_player);
    }
}
