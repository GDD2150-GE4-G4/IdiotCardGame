using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerScript : MonoBehaviour
    {
        public Hand Hand;
        public BlindDeckScript[] Blinds;
        public DiscardDeckScript DiscardPile;
        public int PlayerID;
        public PlayerType type;

        public void AIPlay()
        {
            try
            {
                Card topCard = DiscardPile.TopCard;
                List<KeyValuePair<GameObject, Card>> playableCards = Hand.Cards.Where(c => c.Value.CanBePlayed(topCard)).ToList();
                playableCards.Sort((kvp1, kvp2) => kvp1.Value.CompareTo(kvp2.Value));

                if (playableCards.Count <= 0)
                    Hand.drawPile.OnMouseUpAsButton();
                else if (playableCards[0].Value.Effect == SpecialCard.None)
                    playableCards[0].Key.GetComponent<CardScript>().OnMouseUpAsButton();
                else if (playableCards.Exists(kvp => kvp.Value.Effect == SpecialCard.Reverse) && Hand.Cards.Exists(kvp => kvp.Value.Rank <= 5))
                    playableCards.First(kvp => kvp.Value.Effect == SpecialCard.Reverse).Key.GetComponent<CardScript>().OnMouseUpAsButton();
                else if (playableCards.Exists(kvp => kvp.Value.Effect == SpecialCard.Reset))
                    playableCards.First(kvp => kvp.Value.Effect == SpecialCard.Reset).Key.GetComponent<CardScript>().OnMouseUpAsButton();
                else if (playableCards.Exists(kvp => kvp.Value.Effect == SpecialCard.Burn))
                    playableCards.First(kvp => kvp.Value.Effect == SpecialCard.Burn).Key.GetComponent<CardScript>().OnMouseUpAsButton();
                else
                    playableCards[0].Key.GetComponent<CardScript>().OnMouseUpAsButton();
            }
            catch
            {
                Hand.Cards.RemoveAll(kvp => kvp.Key == null);
                foreach (var card in Hand.transform.GetComponentsInChildren<CardScript>())
                {
                    if (!Hand.Cards.Exists(kvp => kvp.Key == card.gameObject))
                        Destroy(card.gameObject);
                }
                AIPlay();
            }
        }
    }
}
