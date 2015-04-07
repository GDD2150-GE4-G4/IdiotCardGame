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

                var renderers = GetComponentsInChildren<MeshRenderer>();

                foreach (var renderer in renderers)
                    renderer.enabled = true;
            }
        }

        void Awake()
        {            
            var renderers = GetComponentsInChildren<MeshRenderer>();

            foreach (var renderer in renderers)
                renderer.enabled = false;
        }

        void Update()
        {
        }
    }
}
