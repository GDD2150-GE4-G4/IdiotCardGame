public class Dealer
{
	private Deck myDeck = null;
	private static Dealer myInstance = null;

	public Dealer(Deck inDeck)
	{
		if (myInstance == null)
		{
			myInstance = this;
		}
		myDeck = inDeck;
	}
}