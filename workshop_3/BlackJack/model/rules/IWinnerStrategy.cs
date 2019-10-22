namespace BlackJack.model.rules
{
    interface IWinnerStrategy
    {
        bool IsDealerWinner(model.Player a_dealer, model.Player a_player, int g_maxScore);
    }
}