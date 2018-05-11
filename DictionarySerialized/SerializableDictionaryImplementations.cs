using System;
 
using UnityEngine;

namespace SKU
{
    // ---------------
    //  string => LanguageElementText
    // ---------------
    [Serializable]
    public class StringLETextDictionary : SerializableDictionary<string, LanguageElementText> { }

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
}