using UnityEngine;
using System.Collections.Generic;

public struct CardMaterials
{
	private static bool myIsInitialized = false;

	public static Dictionary<CardType, Material> MaterialDictionary = new Dictionary<CardType, Material>();

	public static void Initialize()
	{
		if (!myIsInitialized)
		{
			MaterialDictionary.Add(CardType.Two, Resources.Load<Material>("Materials/CardFront/CardFrontReset"));
			MaterialDictionary.Add(CardType.Three, Resources.Load<Material>("Materials/CardFront/CardFrontThree"));
			MaterialDictionary.Add(CardType.Four, Resources.Load<Material>("Materials/CardFront/CardFrontFour"));
			MaterialDictionary.Add(CardType.Five, Resources.Load<Material>("Materials/CardFront/CardFrontReverse"));
			MaterialDictionary.Add(CardType.Six, Resources.Load<Material>("Materials/CardFront/CardFrontSix"));
			MaterialDictionary.Add(CardType.Seven, Resources.Load<Material>("Materials/CardFront/CardFrontSeven"));
			MaterialDictionary.Add(CardType.Eight, Resources.Load<Material>("Materials/CardFront/CardFrontEight"));
			MaterialDictionary.Add(CardType.Nine, Resources.Load<Material>("Materials/CardFront/CardFrontNine"));
			MaterialDictionary.Add(CardType.Ten, Resources.Load<Material>("Materials/CardFront/CardFrontBurn"));
			MaterialDictionary.Add(CardType.Jack, Resources.Load<Material>("Materials/CardFront/CardFrontJack"));
			MaterialDictionary.Add(CardType.Queen, Resources.Load<Material>("Materials/CardFront/CardFrontQueen"));
			MaterialDictionary.Add(CardType.King, Resources.Load<Material>("Materials/CardFront/CardFrontKing"));
			MaterialDictionary.Add(CardType.Ace, Resources.Load<Material>("Materials/CardFront/CardFrontAce"));
			MaterialDictionary.Add(CardType.FaceDown, Resources.Load<Material>("Materials/CardFront/CardBack"));
		}
		myIsInitialized = true;
	}
}