using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
  class PlayGame : model.ICardDealObserver
  {
    private model.Game m_game;
    private view.IView m_view;
    public PlayGame(model.Game a_game, view.IView a_view)
    {
      m_game = a_game;
      m_view = a_view;
      m_game.AddSubscribers(this);
    }
    public bool Play()
    {
      DisplayCard();

      if (m_game.IsGameOver())
      {
        m_view.DisplayGameOver(m_game.IsDealerWinner());
      }

      view.Input input = m_view.GetInput();

      if (input == view.Input.Play)
      {
        m_game.NewGame();
      }
      else if (input == view.Input.Hit)
      {
        m_game.Hit();
      }
      else if (input == view.Input.Stand)
      {
        m_game.Stand();
      }

      return input != view.Input.Quit;
    }

    public void DisplayCard()
    {
      Thread.Sleep(1000);

      m_view.DisplayWelcomeMessage();

      m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
      m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

    }
  }
}
