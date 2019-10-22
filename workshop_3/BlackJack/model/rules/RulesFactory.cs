using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
  class RulesFactory
  {
    public IHitStrategy GetHitRule()
    {
      return new BasicHitStrategy();
    }

    public INewGameStrategy GetAmericanGameRule()
    {
      return new AmericanNewGameStrategy();
    }

    public INewGameStrategy GetInternationalGameRule()
    {
      return new InternationalNewGameStrategy();
    }

    public IHitStrategy GetSoft17Rule()
    {
      return new Soft17HitStrategy();
    }

    public IWinnerStrategy GetDealerWinnerStrategy()
    {
      return new IsDealerWinnerStrategy();
    }

    public IWinnerStrategy GetPlayerWinnerStrategy()
    {
      return new IsPlayerWinnerStrategy();
    }
  }
}
