using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameScript : MonoBehaviour
    {
        public int CurrentPlayer = 0;
        public PlayerScript[] Players;
        public DrawDeckScript DrawDeck;

        public void EndTurn()
        {
            CurrentPlayer++;

            if (CurrentPlayer >= Players.Count())
                CurrentPlayer = 0;

            foreach (PlayerScript player in Players)
                while (DrawDeck.TopCard != null && player.Hand.Count < 3)
                    player.Hand.AddCard(DrawDeck.DrawCard());
        }
    }
}
