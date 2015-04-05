using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    public static class Deck
    {
        static List<Card> Cards;

        public static void Initialize()
        {
            Cards = new List<Card>();
        }
    }
}
