using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
  class Dealer : Player
  {
    private Deck m_deck = null;
    private const int g_maxScore = 21;

    private rules.INewGameStrategy m_newGameRule;
    private rules.IHitStrategy m_hitRule;
    private rules.IWinnerStrategy m_winnerRule;
    public Dealer(rules.RulesFactory a_rulesFactory)
    {
      m_newGameRule = a_rulesFactory.GetAmericanGameRule();
      m_hitRule = a_rulesFactory.GetSoft17Rule();
      m_winnerRule = a_rulesFactory.GetPlayerWinnerStrategy();
    }

    public bool NewGame(Player a_player)
    {
      if (m_deck == null || IsGameOver())
      {
        m_deck = new Deck();
        ClearHand();
        a_player.ClearHand();
        return m_newGameRule.NewGame(m_deck, this, a_player);
      }
      return false;
    }

    public bool Hit(Player a_player)
    {
      if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
      {

        Deal(a_player, true, m_deck.GetCard());

        return true;
      }
      return false;
    }

    public bool Stand()
    {
      if (m_deck != null)
      {
        ShowHand();
        while (m_hitRule.DoHit(this))
        {
          Deal(this, true, m_deck.GetCard());
        }
      }
      return true;
    }

    public bool IsDealerWinner(Player a_player)
    {
      return m_winnerRule.IsDealerWinner(this, a_player, g_maxScore);
    }

    public bool IsGameOver()
    {
      if (m_deck != null && m_hitRule.DoHit(this) == false)
      {
        return true;
      }
      return false;
    }

    public void Deal(Player a_player, bool showCard, Card c)
    {
      c.Show(showCard);
      a_player.DealCard(c);
      Update();
    }
  }
}
