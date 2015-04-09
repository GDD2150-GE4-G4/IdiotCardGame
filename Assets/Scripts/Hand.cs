using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class Hand : Deck
    {
        new private List<KeyValuePair<GameObject, Card>> Cards = new List<KeyValuePair<GameObject, Card>>();
        public GameObject cardPrefab;

        public Deck discardPile;
        public Deck drawPile;

        private const float HAND_MAX_WIDTH = 5.25f;
        private const float CARD_WIDTH = 0.625f;

        public int Count
        {
            get
            {
                return Cards.Count;
            }
        }

        public override void AddCard(Card card)
        {
            KeyValuePair<GameObject, Card> kvp = new KeyValuePair<GameObject, Card>(Instantiate(cardPrefab, transform.position, transform.rotation) as GameObject, card);
            kvp.Key.transform.parent = transform;
            kvp.Key.GetComponent<CardScript>().Card = kvp.Value;
            Cards.Add(kvp);
            UpdatePositioning();
        }

        public void UpdatePositioning()
        {
            Cards.Sort((kvp1, kvp2) => kvp1.Value.CompareTo(kvp2.Value));

            float gutter;
            float width = Cards.Count * CARD_WIDTH;

            if (Cards.Count > 1)
                gutter = (HAND_MAX_WIDTH - width) / (Cards.Count - 1);
            else
                gutter = 0;

            gutter = Mathf.Clamp(gutter, -CARD_WIDTH / 2, CARD_WIDTH / 2);

            width = width + gutter * (Cards.Count - 1);

            foreach (var kvp in Cards)
            {
                GameObject obj = kvp.Key;
                Card card = kvp.Value;
                Vector3 pos = obj.transform.position;
                int i = Cards.IndexOf(kvp);

                pos.y = transform.position.y + i/1000.0f;
                pos.x = -(width / 2) + i*CARD_WIDTH + i*gutter + CARD_WIDTH/2;

                obj.transform.position = pos;
            }
        }

        public GameObject RemoveCard(Card card)
        {
            var kvp = Cards.FirstOrDefault(c => c.Value == card);

            Cards.Remove(kvp);

            UpdatePositioning();

            return kvp.Key;
        }
    }
}
