using System.Collections.Generic;
using UnityEngine;

public class KeyInventory : MonoBehaviour
{
    public static KeyInventory Instance;

    public List<KeyData> collectedKeys = new List<KeyData>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddKey(KeyData key)
    {

        Debug.Log("Inventory fikk nøkkel: " + key.keyName);

        if (!collectedKeys.Contains(key))
            collectedKeys.Add(key);
    }
}
