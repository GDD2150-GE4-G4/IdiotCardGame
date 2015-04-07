using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts
{
    public static class Utility
    {
        public static Dictionary<string, Material> MaterialsDict = new Dictionary<string, Material>();

        public static byte MAX_DECK_SIZE = 52;

        private static bool initialized = false;

        public static void Initialize()
        {
            if (!initialized)
            {
                MaterialsDict.Add("ace", Resources.Load<Material>("Materials/CardFront/CardFrontAce"));
                MaterialsDict.Add("reset", Resources.Load<Material>("Materials/CardFront/CardFrontReset"));
                MaterialsDict.Add("three", Resources.Load<Material>("Materials/CardFront/CardFrontThree"));
                MaterialsDict.Add("four", Resources.Load<Material>("Materials/CardFront/CardFrontFour"));
                MaterialsDict.Add("reverse", Resources.Load<Material>("Materials/CardFront/CardFrontReverse"));
                MaterialsDict.Add("six", Resources.Load<Material>("Materials/CardFront/CardFrontSix"));
                MaterialsDict.Add("seven", Resources.Load<Material>("Materials/CardFront/CardFrontSeven"));
                MaterialsDict.Add("eight", Resources.Load<Material>("Materials/CardFront/CardFrontEight"));
                MaterialsDict.Add("nine", Resources.Load<Material>("Materials/CardFront/CardFrontNine"));
                MaterialsDict.Add("burn", Resources.Load<Material>("Materials/CardFront/CardFrontBurn"));
                MaterialsDict.Add("jack", Resources.Load<Material>("Materials/CardFront/CardFrontJack"));
                MaterialsDict.Add("queen", Resources.Load<Material>("Materials/CardFront/CardFrontQueen"));
                MaterialsDict.Add("king", Resources.Load<Material>("Materials/CardFront/CardFrontKing"));
                MaterialsDict.Add("back", Resources.Load<Material>("Materials/CardBack/CardBack"));

                initialized = true;
            }
        }
    }

    public enum SpecialCard
    {
        None,
        Reset,
        Reverse,
        Burn
    }

    public enum Player
    {
        None,
        PlayerOne,
        PlayerTwo
    }
}
