public interface ISerializableDictionary
{
    void OnAfterDeserialize();
    void OnBeforeSerialize();
}