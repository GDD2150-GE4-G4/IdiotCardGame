using UnityEngine;
using System;
using System.Collections.Generic;

public class Hand : ICardCollection
{

	public Card GetLowestCard()
	{
		return myCards[0];
	}

	public override List<Card> GetCards ()
	{
		return myCards;
	}
	
	public override void SetCards (List<Card> inCards)
	{
		myCards = inCards;
	}
	
	public override void AddCard (Card inCard)
	{
		myCards.Add (inCard);
	}
}