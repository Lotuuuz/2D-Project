using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    public static KeyInventory Instance;

    public List<KeyData> collectedKeys;

    private void Awake()
    {
        Instance = this;

        if (collectedKeys== null)
            collectedKeys = new List<KeyData>();
    }

    public void AddKey(KeyData key)
    {

        Debug.Log("Inventory fikk nøkkel: " + key.keyName);

        if (!collectedKeys.Contains(key))
            collectedKeys.Add(key);
    }
}
