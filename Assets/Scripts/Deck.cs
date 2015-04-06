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

            do
            {
                Card card = new Card();

                if (Cards.Count(c => c == card) < 4)
                    Cards.Push(card);
            }
            while (Cards.Count < startCount);

            SetThickness();
            
            if (isFaceUp)
                transform.FindChild("Top").GetComponent<Renderer>().material = Cards.Peek().GetMaterial();

            isEmpty = Cards.Count <= 0;
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

            SetThickness();

            if (isFaceUp)
                transform.FindChild("Top").GetComponent<Renderer>().material = Cards.Peek().GetMaterial();
        }

        void SetThickness()
        {
            transform.localScale = new Vector3(.25f, Cards.Count / (float)Utility.MAX_DECK_SIZE, .25f);
        }

        public void AddCard(Card card)
        {
            Cards.Push(card);
        }

        void OnMouseDown()
        {
            if (discardPile && Cards.Count > 0)
            {
                discardPile.AddCard(Cards.Pop());
            }
        }
    }
}
