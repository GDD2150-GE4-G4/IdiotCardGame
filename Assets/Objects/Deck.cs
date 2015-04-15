using UnityEngine;
using System.Collections.Generic;

public class Deck : ICardCollection {

	private static Deck myInstance = null;

	public Deck()
	{
		if (myInstance == null)
			myInstance = new Deck ();
	}
}
