using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	private Deck myDeck;
	private Dealer myDealer;

	// Use this for initialization
	void Start () {
		myDeck = new Deck ();
		myDealer = new Dealer (myDeck);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
