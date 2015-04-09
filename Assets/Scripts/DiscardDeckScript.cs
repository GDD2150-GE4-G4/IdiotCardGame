using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    class DiscardDeckScript : Deck
    {
        public void PlayCard(Card card, PlayerScript player)
        {
            base.AddCard(card);

            if (card.Effect == SpecialCard.Burn)
            {
                while (Cards.Count > 0)
                    DrawCard();
            }
        }
    }
}
