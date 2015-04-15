﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class BlindDeckScript : Deck
	{
		public Card Card;
		public Hand hand;
		Vector3 initPos;
		Deck Destination;
		float t = 0;
		
		public delegate void AfterMove(Card card);
		
		AfterMove moveFunc;

        public override Card DrawCard()
        {
            isFaceUp = false;
            return base.DrawCard();
        }

        protected void OnMouseUpAsButton()
        {
			hand.RemoveCard(Card);	
			DealTo(hand.discardPile, hand.discardPile.PlayCard);
        }

		public void DealTo(Deck destination, AfterMove func)
		{
			Destination = destination;
			initPos = transform.position;
			moveFunc = func;
			InvokeRepeating("MoveToDestination", 0.0f, 0.02f);
		}
		
		void MoveToDestination()
		{
			if (t <= 1)
			{
				transform.position = Vector3.Lerp(initPos, Destination.gameObject.transform.position, t);
				t += 0.05f;
			}
			else
			{
				t = 0;
				CancelInvoke("MoveToDestination");
				moveFunc.Invoke(Card);
				if (gameObject != null)
					Destroy(gameObject);
			}
		}
    }
}
