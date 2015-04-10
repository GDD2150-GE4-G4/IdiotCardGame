using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts
{
    public class Deck : MonoBehaviour
    {
        public GameScript Game;
        public byte startCount;
        public bool isFaceUp = false;
        public GameObject DeckOf;

        protected Stack<Card> Cards = new Stack<Card>();

        private bool isEmpty = true;

        public Card TopCard
        {
            get
            {
                if (Cards.Count > 0)
                    return Cards.Peek();
                else
                    return null;
            }
        }

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

        void UpdateRendering()
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

                if (isFaceUp && Cards.Count > 0)
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

        public void DealCard(Deck destination, CardScript.AfterMove dealFunction)
        {
            var pos = transform.position;
            var rot = transform.rotation;
            rot.z += 180;
            pos.y += gameObject.GetComponent<BoxCollider>().bounds.extents.y;

            var cardObj = Instantiate(DeckOf, pos, rot) as GameObject;
            cardObj.GetComponent<CardScript>().Card = DrawCard();

            cardObj.GetComponent<CardScript>().DealTo(destination, dealFunction);
        }

        public virtual Card DrawCard()
        {
            Card retCard = null;

            if (Cards.Count > 0)            
                retCard = Cards.Pop();

            UpdateRendering();

            return retCard;
        }

        virtual protected void SetThickness()
        {
            transform.localScale = new Vector3(.25f, Cards.Count / (float)Utility.MAX_DECK_SIZE, .25f);

            var pos = transform.position;

            pos.y = 7.51f + gameObject.GetComponent<BoxCollider>().bounds.extents.y;

            transform.position = pos;
        }

        virtual public void AddCard(Card card)
        {
            Cards.Push(card);
            UpdateRendering();
        }
    }
}
