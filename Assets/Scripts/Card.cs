using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Assets.Scripts
{
    public class Card : IComparable<Card>, IEquatable<Card>
    {
        public byte Rank = 0;
        public SpecialCard Effect = SpecialCard.Reset;

        public Card()
            :this((byte)UnityEngine.Random.Range(2, 15))
        {
        }

        public Card (byte rank)
        {
            Rank = rank;
            switch (rank)
	        {
                case 2:
                    Effect = SpecialCard.Reset;
                    break;
                case 5:
                    Effect = SpecialCard.Reverse;
                    break;
                case 10:
                    Effect = SpecialCard.Burn;
                    break;
                default:
                    Effect = SpecialCard.None;
                    break;
	        }
        }

        public Card (SpecialCard effect)
        {
            Effect = effect;
            switch (effect)
	        {
                case SpecialCard.None:
                    throw new ArgumentException("None is not a valid effect for constructing a card by effect.");
                case SpecialCard.Reset:
                    Rank = 2;
                    break;
                case SpecialCard.Reverse:
                    Rank = 5;
                    break;
                case SpecialCard.Burn:
                    Rank = 10;
                    break;
            }
        }

        public Material GetMaterial()
        {
            switch (Rank)
	        {
                case 2: //reset
                    return Utility.MaterialsDict["reset"];
                case 3:
                    return Utility.MaterialsDict["three"];
                case 4:
                    return Utility.MaterialsDict["four"];
                case 5: //reverse
                    return Utility.MaterialsDict["reverse"];
                case 6:
                    return Utility.MaterialsDict["six"];
                case 7:
                    return Utility.MaterialsDict["seven"];
                case 8:
                    return Utility.MaterialsDict["eight"];
                case 9:
                    return Utility.MaterialsDict["nine"];
                case 10:    //burn
                    return Utility.MaterialsDict["burn"];
                case 11:    //jack
                    return Utility.MaterialsDict["jack"];
                case 12:    //queen
                    return Utility.MaterialsDict["queen"];
                case 13:    //king
                    return Utility.MaterialsDict["king"];
                case 14:    //ace
                    return Utility.MaterialsDict["ace"];
	        }

            throw new KeyNotFoundException("Material not found for " + Rank + " " + Effect);
        }

        public int CompareTo(Card other)
        {
            if (Rank > other.Rank)
                return 1;
            else if (Rank == other.Rank)
                return 0;
            else
                return -1;
        }

        public bool Equals(Card other)
        {
            return CompareTo(other) == 0;
        }

        public bool CanBePlayed(Card other)
        {
            return (Effect != SpecialCard.None) || (CompareTo(other) >= 0);
        }
        public static bool operator ==(Card c1, Card c2)
        {
            return c1.Equals(c2);
        }
        public static bool operator !=(Card c1, Card c2)
        {
            return !c1.Equals(c2);
        }

        public override bool Equals(object obj)
        {
            if (obj is Card)
                return Equals(obj as Card);
            else
                return false;
        }

        public override int GetHashCode()
        {
            return Rank;
        }

        public override string ToString()
        {
            if (Effect != SpecialCard.None)
                return Effect.ToString();
            else if (Rank < 11)
                return Rank.ToString();
            else
                switch(Rank)
                {
                    case 11:
                        return "Jack";
                    case 12:
                        return "Queen";
                    case 13:
                        return "King";
                    case 14:
                        return "Ace";
                    default:
                        return "Unknown";
                }
        }
    }
}
