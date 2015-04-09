using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class CardScript : MonoBehaviour
    {
        public Card Card { get; set; }
        public Hand hand;

        void Update()
        {
            if (Card != null)
                transform.FindChild("Front").GetComponent<Renderer>().material = Card.GetMaterial();
        }

        void OnMouseUpAsButton()
        {
            if (Card.CanBePlayed(hand.discardPile.TopCard))
            {
                hand.discardPile.PlayCard(Card, hand.player);

                Destroy(hand.RemoveCard(Card));
            }
        }
    }
}
