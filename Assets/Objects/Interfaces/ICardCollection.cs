using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class ICardCollection
{
	protected List<Card> myCards = null;

	public virtual List<Card> GetCards ()
	{
		return myCards;
	}

	public virtual void SetCards(List<Card> inCards)
	{
		myCards = inCards;
	}

	public virtual void AddCard(Card inCard)
	{
		myCards.Add (inCard);
		myCards.Sort ();
	}
}