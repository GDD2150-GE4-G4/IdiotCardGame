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
    }
}
