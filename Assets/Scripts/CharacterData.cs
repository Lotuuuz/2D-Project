using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public string name;

    public Sprite dayPortrait;
    public Sprite nightPortrait;

    [TextArea] public string[] dayDescriptions = new string[3];
    [TextArea] public string[] nightDescriptions = new string[3];
}
