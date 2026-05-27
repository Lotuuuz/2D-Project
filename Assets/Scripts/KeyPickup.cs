using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public string keyName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            KeyManager.Instance.AddKey(keyName);

            Destroy(gameObject);
        }
    }
}
