using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class DrawDeckScript : Deck
    {
        public Deck Blind_p1_1;
        public Deck Blind_p1_2;
        public Deck Blind_p1_3;

        public Deck Blind_p2_1;
        public Deck Blind_p2_2;
        public Deck Blind_p2_3;

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
                    Blind_p1_1.isFaceUp = false;
                    Blind_p1_1.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 1:
                    Blind_p2_1.isFaceUp = false;
                    Blind_p2_1.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 2:
                    Blind_p1_2.isFaceUp = false;
                    Blind_p1_2.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 3:
                    Blind_p2_2.isFaceUp = false;
                    Blind_p2_2.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 4:
                    Blind_p1_3.isFaceUp = false;
                    Blind_p1_3.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 5:
                    Blind_p2_3.isFaceUp = false;
                    Blind_p2_3.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 6:
                    Blind_p1_1.isFaceUp = true;
                    Blind_p1_1.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 7:
                    Blind_p2_1.isFaceUp = true;
                    Blind_p2_1.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 8:
                    Blind_p1_2.isFaceUp = true;
                    Blind_p1_2.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 9:
                    Blind_p2_2.isFaceUp = true;
                    Blind_p2_2.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 10:
                    Blind_p1_3.isFaceUp = true;
                    Blind_p1_3.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 11:
                    Blind_p2_3.isFaceUp = true;
                    Blind_p2_3.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 12:
                    Player1_Hand.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 13:
                    Player2_Hand.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 14:
                    Player1_Hand.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 15:
                    Player2_Hand.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 16:
                    Player1_Hand.AddCard(DrawCard());
                    dealStage++;
                    break;
                case 17:
                    Player2_Hand.AddCard(DrawCard());
                    dealStage++;
                    break;
                default:
                    CancelInvoke("Deal");
                    break;
	        }
        }
    
        void OnMouseUpAsButton()
        {
            if (Cards.Count > 0)
            {
                DiscardPile.PlayCard(DrawCard(), Game.Players[Game.CurrentPlayer]);
            }
        }
    }
}
