using UnityEngine;
using System.Collections.Generic;

public class KeyManager : MonoBehaviour
{
    public static KeyManager Instance;

    public List<KeyData> collectedKeys = new List<KeyData>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddKey(KeyData key)
    {
        if (!collectedKeys.Contains(key))
        {
            collectedKeys.Add(key);
            Debug.Log("Picked up: " + key.keyName);
        }
    }

    public bool HasKey(KeyData key)
    {
        return collectedKeys.Contains(key);
    }

    public bool HasKey(string keyName)
    {
        foreach (var k in collectedKeys)
        {
            if (k.keyName == keyName)
                return true;
        }
        return false;
    }
}
