using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts
{
    public class Deck : MonoBehaviour
    {
        public byte startCount;
        public Deck discardPile;
        public bool isFaceUp = false;

        private Stack<Card> Cards = new Stack<Card>();

        private bool isEmpty;

        // Use this for initialization
        void Awake()
        {
            Utility.Initialize();

            while (Cards.Count < startCount)
            {
                Card card = new Card();

                if (Cards.Count(c => c == card) < 4)
                {
                    Cards.Push(card);
                }
            }

            Shuffle();

            if (startCount > 0)
            {
                SetThickness();

                if (isFaceUp)
                    transform.FindChild("Top").GetComponent<Renderer>().material = Cards.Peek().GetMaterial();
                else
                    transform.FindChild("Top").GetComponent<Renderer>().material = Utility.MaterialsDict["back"];

            }
        }

        void Update()
        {
            if (Cards.Count <= 0 && !isEmpty)
            {
                var renderers = GetComponentsInChildren<MeshRenderer>();

                foreach (var renderer in renderers)
                    renderer.enabled = false;

                isEmpty = true;
            }

            if (isEmpty && Cards.Count >= 1)
            {
                var renderers = GetComponentsInChildren<MeshRenderer>();

                foreach (var renderer in renderers)
                    renderer.enabled = true;

                isEmpty = false;
            }

            if (!isEmpty)
            {
                SetThickness();

                if (isFaceUp)
                    transform.FindChild("Top").GetComponent<Renderer>().material = Cards.Peek().GetMaterial();
                else
                    transform.FindChild("Top").GetComponent<Renderer>().material = Utility.MaterialsDict["back"];
            }
        }

        void Shuffle(int iterations = 1)
        {
            for (int i = 0; i < iterations; i++)
            {
                var cards = Cards.ToList<Card>();

                Cards.Clear();

                for (int j = cards.Count; j > 0; j--)
                {
                    int k = UnityEngine.Random.Range(0, j);
                    Cards.Push(cards[k]);
                    cards.RemoveAt(k);
                }
            }
        }

        public void DealCard(Deck destination)
        {
            if (Cards.Count > 0)
                destination.AddCard(Cards.Pop());
        }

        public virtual Card DrawCard()
        {
            return Cards.Pop();
        }

        void SetThickness()
        {
            transform.localScale = new Vector3(.25f, Cards.Count / (float)Utility.MAX_DECK_SIZE, .25f);
        }

        public void AddCard(Card card)
        {
            Cards.Push(card);
        }

        virtual protected void OnMouseDown()
        {
            DealCard(discardPile);
        }
    }
}
