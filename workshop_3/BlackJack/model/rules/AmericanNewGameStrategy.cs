using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
  class AmericanNewGameStrategy : INewGameStrategy
  {
    public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
    {
      bool showCard = true;
      bool hideCard = false;

      a_dealer.Deal(a_player, showCard, a_deck.GetCard());
      a_dealer.Deal(a_dealer, showCard, a_deck.GetCard());
      a_dealer.Deal(a_player, showCard, a_deck.GetCard());
      a_dealer.Deal(a_dealer, hideCard, a_deck.GetCard());

      return true;
    }
  }
}
