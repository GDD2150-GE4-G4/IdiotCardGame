using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class CardScript : MonoBehaviour
    {
        private Card card;
        public Card Card
        {
            get
            {
                return card;
            }
            set
            {
                card = value;
            }
        }

        void Update()
        {
            if (card != null)
                transform.FindChild("Front").GetComponent<Renderer>().material = card.GetMaterial();
        }
    }
}
