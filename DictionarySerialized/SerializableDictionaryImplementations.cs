using System;
 
using UnityEngine;

namespace SKU
{
    // ---------------
    //  String => Int
    // ---------------
    [Serializable]
    public class StringIntDictionary : SerializableDictionary<string, int> { }

    // ---------------
    //  GameObject => Float
    // ---------------
    [Serializable]
    public class GameObjectFloatDictionary : SerializableDictionary<GameObject, float> { }
}