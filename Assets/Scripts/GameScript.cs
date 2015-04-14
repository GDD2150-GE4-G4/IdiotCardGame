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
            {
                for (int i = player.Hand.Count; i < 3; i++)
                    if (DrawDeck.TopCard != null)
                        DrawDeck.DealCard(player.Hand, player.Hand.AddCard);
            }

            if (Players[CurrentPlayer].type == PlayerType.AI)
            {
                Players[CurrentPlayer].AIPlay();
            }
        }
    }
}
