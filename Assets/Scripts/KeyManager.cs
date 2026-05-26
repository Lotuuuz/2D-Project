using UnityEngine;
using System.Collections.Generic;
using JetBrains.Annotations;

public class KeyManager : MonoBehaviour
{
  public static KeyManager Instance;
  
  private HashSet<string> keys = new HashSet<string>();
  
  private void Awake()
  {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
  }

    public void AddKey(string keyName)
    {
        keys.Add(keyName);
        Debug.Log("Picked up: " +  keyName);
    }

    public bool HasKey(string keyName)
    {
        return keys.Contains(keyName);
    }
}
