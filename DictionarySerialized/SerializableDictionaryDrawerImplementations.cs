namespace SKU
{
    // ---------------
    //  String => LanguageElementText
    // ---------------
    [UnityEditor.CustomPropertyDrawer(typeof(StringLETextDictionary))]
    public class StringLEText : SerializableDictionaryDrawer<string, LanguageElementText>
    {
        protected override SerializableKeyValueTemplate<string, LanguageElementText> GetTemplate()
        {
            return GetGenericTemplate<SerializableStringLETextTemplate>();
        }
    }
    internal class SerializableStringLETextTemplate : SerializableKeyValueTemplate<string, LanguageElementText> { }

    // ---------------
    //  String => LanguageElementSprite
    // ---------------
    [UnityEditor.CustomPropertyDrawer(typeof(StringLESpriteDictionary))]
    public class StringLESprite : SerializableDictionaryDrawer<string, LanguageElementSprite>
    {
        protected override SerializableKeyValueTemplate<string, LanguageElementSprite> GetTemplate()
        {
            return GetGenericTemplate<SerializableStringLESpriteTemplate>();
        }
    }
    internal class SerializableStringLESpriteTemplate : SerializableKeyValueTemplate<string, LanguageElementSprite> { }

    // ---------------
    //  String => LanguageElementAudioSource
    // ---------------
    [UnityEditor.CustomPropertyDrawer(typeof(StringLEAudioClipDictionary))]
    public class StringLEAudioClip : SerializableDictionaryDrawer<string, LanguageElementAudioClip>
    {
        protected override SerializableKeyValueTemplate<string, LanguageElementAudioClip> GetTemplate()
        {
            return GetGenericTemplate<SerializableStringLEAudioClipTemplate>();
        }
    }
    internal class SerializableStringLEAudioClipTemplate : SerializableKeyValueTemplate<string, LanguageElementAudioClip> { }

    // ---------------
    //  String => Language
    // ---------------
    [UnityEditor.CustomPropertyDrawer(typeof(StringLanguageDictionary))]
    public class StringLanguage : SerializableDictionaryDrawer<string, Language>
    {
        protected override SerializableKeyValueTemplate<string, Language> GetTemplate()
        {
            return GetGenericTemplate<SerializableStringLanguageTemplate>();
        }
    }
    internal class SerializableStringLanguageTemplate : SerializableKeyValueTemplate<string, Language> { }
}