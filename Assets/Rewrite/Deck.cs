using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class Deck : ICardCollection {

	private static Deck myInstance = null;

	public Deck()
	{
		if (myInstance == null)
		{
			myInstance = this;
			CreateDeck();
		}
	}

	private void CreateDeck()
	{
		Debug.Log ("Creating deck");
		CardMaterials.Initialize ();
		myCards = new List<Card> ();
		foreach (CardType cardType in Enum.GetValues(typeof(CardType)))
		{
			if (cardType != CardType.FaceDown)
			{
				for (int i = 0; i < 4; ++i)
				{
					Card toAdd = new Card();
					
					toAdd.SetFaceMaterial(CardMaterials.MaterialDictionary[CardType.FaceDown]);
					toAdd.SetValue(cardType);
					
					switch (cardType)
					{
					case CardType.Two:
						toAdd.SetAction(SpecialCardAction.Reset);
						break;
					case CardType.Five:
						toAdd.SetAction(SpecialCardAction.Reverse);
						break;
					case CardType.Ten:
						toAdd.SetAction(SpecialCardAction.Burn);
						break;
					default:
						toAdd.SetAction(SpecialCardAction.None);
						break;
					}
					
					toAdd.SetIsFaceUp(false);
					myCards.Add(toAdd);
					Debug.Log("Added " + toAdd.ToString());
				}
			}
		}
		Debug.Log (myCards.Count + " cards made");

		Shuffle ();

		foreach (Card c in myCards) {
			Debug.Log(c.ToString());
		}
	}

	private void Shuffle()
	{
		List<Card> myCardsCopy = new List<Card>();
		myCardsCopy.AddRange (myCards);
		
		myCards.Clear();
		
		for (int j = myCardsCopy.Count; j > 0; j--)
		{
			int k = UnityEngine.Random.Range(0, j);
			myCards.Add(myCardsCopy[k]);
			myCardsCopy.RemoveAt(k);
		}
	}
}
