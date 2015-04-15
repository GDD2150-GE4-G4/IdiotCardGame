using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class DrawDeckScript : Deck
    {
        public Hand Player1_Hand;
        public Hand Player2_Hand;

        public DiscardDeckScript DiscardPile;

        private int dealStage = 0;

        void Start()
        {
            InvokeRepeating("Deal", 0.2f, 0.2f);
        }

        void Deal()
        {
            switch (dealStage)
	        {
                case 0:
                    DealCard(Player1_Hand, Player1_Hand.AddCard);
                    dealStage++;
                    break;
                case 1:
                    DealCard(Player2_Hand, Player2_Hand.AddCard);
                    dealStage++;
                    break;
                case 2:
                    DealCard(Player1_Hand, Player1_Hand.AddCard);
                    dealStage++;
                    break;
                case 3:
                    DealCard(Player2_Hand, Player2_Hand.AddCard);
                    dealStage++;
                    break;
                case 4:
                    DealCard(Player1_Hand, Player1_Hand.AddCard);
                    dealStage++;
                    break;
                case 5:
                    DealCard(Player2_Hand, Player2_Hand.AddCard);
                    dealStage++;
                    break;
                default:
                    CancelInvoke("Deal");
                    break;
	        }
        }
    
        public void OnMouseUpAsButton()
        {
            if (Cards.Count > 0)
            {
                DealCard(DiscardPile, DiscardPile.PlayCard);
            }
        }
    }
}
