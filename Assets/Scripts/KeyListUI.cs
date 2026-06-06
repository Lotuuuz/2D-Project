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
            TMPro.TextMeshProUGUI text = entry.transform.Find("Text").GetComponent<TMPro.TextMeshProUGUI>();

            // Fyll inn data
            icon.sprite = key.keySprite;
            text.text = key.keyName + "\n" + key.keyDescription;
        }
    }
}
