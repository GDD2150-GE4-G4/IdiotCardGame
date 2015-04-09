using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class BlindDeckScript : Deck
    {
        public override Card DrawCard()
        {
            isFaceUp = false;
            return base.DrawCard();
        }

        protected void OnMouseUpAsButton()
        {
            DrawCard();
        }
    }
}
