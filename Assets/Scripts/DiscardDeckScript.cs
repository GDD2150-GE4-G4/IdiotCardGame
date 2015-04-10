using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class DiscardDeckScript : Deck
    {
        public void PlayCard(Card card)
        {
            PlayerScript player = Game.GetComponent<GameScript>().Players[Game.GetComponent<GameScript>().CurrentPlayer];
            Card old = TopCard;
            base.AddCard(card);

            if (card.Effect == SpecialCard.Burn)
            {
                while (Cards.Count > 0)
                    DrawCard();
            }
            else
            {
                if (old != null && !card.CanBePlayed(old))
                {
                    while (TopCard != null)
                        player.Hand.AddCard(DrawCard());
                }
                Game.EndTurn();
            }
        }
    }
}
