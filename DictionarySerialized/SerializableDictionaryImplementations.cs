using System;
 
using UnityEngine;

namespace SKU
{
    // ---------------
    //  string => LanguageElementSprite
    // ---------------
    [Serializable]
    public class StringLESpriteDictionary : SerializableDictionary<string, LanguageElementSprite> { }

    // ---------------
    //  string => LanguageElementAudioClip
    // ---------------
    [Serializable]
    public class StringLEAudioClipDictionary : SerializableDictionary<string, LanguageElementAudioClip> { }

    // ---------------
    //  string => Language
    // ---------------
    [Serializable]
    public class StringLanguageDictionary : SerializableDictionary<string, Language> { }

    // ---------------
    //  string => GameObject
    // ---------------
    [Serializable]
    public class StringGameObjectDictionary : SerializableDictionary<string, GameObject> { }
}