using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class KeyListUI : MonoBehaviour
{
    [Header("UI References")]
    public Transform keyListParent;      // Containeren (Vertical Layout Group)
    public GameObject keyEntryPrefab;    // Prefaben for én nøkkelrad

    public void Refresh()
    {
        // Slett gamle entries
        foreach (Transform child in keyListParent)
        {
            Destroy(child.gameObject);
        }

        // Hent nøklene fra KeyInventory
        List<KeyData> keys = KeyInventory.Instance.collectedKeys;

        // Lag én entry per nøkkel
        foreach (KeyData key in keys)
        {
            GameObject entry = Instantiate(keyEntryPrefab, keyListParent);

            // Finn UI-elementene i prefaben
            Image icon = entry.transform.Find("Icon").GetComponent<Image>();
            TextMeshProUGUI text = entry.transform.Find("Text").GetComponent<TextMeshProUGUI>();

            // Sett ikon
            icon.sprite = key.keySprite;

            // hent farge fra sprite
            Texture2D tex = key.keySprite.texture;
            Color spriteColor = Color.white;

            if (tex.isReadable)
            {
                spriteColor = tex.GetPixel(tex.width / 2, tex.height / 2);
            }

            string hex = ColorUtility.ToHtmlStringRGB(spriteColor);

            // farg navnet, beskrivelse skal være svart
            text.text = $"<color=#{hex}>{key.keyName}</color>\n{key.keyDescription}";
            text.color = Color.black; // fallback for beskrivelsen
        }
    }
}
