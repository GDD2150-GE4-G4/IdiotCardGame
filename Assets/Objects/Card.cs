using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class Card : IComparable<Card>, IEquatable<Card> {

	private Material myMaterial = null;
	private ushort myValue = 0;
	private bool myIsFaceUp = true;
	private SpecialCardAction myAction = SpecialCardAction.None;

	public Material GetFaceMaterial()
	{
		return myMaterial;
	}
	
	public void SetFaceMaterial(Material inMaterial)
	{
		myMaterial = inMaterial;
	}
	
	public ushort GetValue()
	{
		return myValue;
	}
	
	public void SetValue(ushort inValue)
	{
		myValue = inValue;
	}
	
	public bool IsFaceUp()
	{
		return myIsFaceUp;
	}
	
	public void SetIsFaceUp(bool inIsFaceUp)
	{
		myIsFaceUp = inIsFaceUp;
	}

	public SpecialCardAction GetAction ()
	{
		return myAction;
	}

	public void SetAction (SpecialCardAction inAction)
	{
		myAction = inAction;
	}

	public int CompareTo(Card inOther)
	{
		return this.GetValue () - inOther.GetValue ();
	}
	
	public bool Equals(Card inOther)
	{
		return CompareTo (inOther) == 0;
	}
	
	public override bool Equals(object inOther)
	{
		return Equals (inOther as Card);
	}
	
	public override int GetHashCode ()
	{
		return base.GetHashCode ();
	}
	
	public override string ToString ()
	{
		return GetValue().ToString();
	}
}
