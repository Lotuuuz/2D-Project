using UnityEngine;

public class LockedTeleport : MonoBehaviour
{
    [Header("Key Needed")]
    public string requiredKey;

    [Header("Teleport Destination")]
    public Transform teleportPoint;

    private bool playerInRange;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TryTeleport();
        }
    }
    void TryTeleport()
    {
        if (KeyManager.Instance.HasKey(requiredKey))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            player.transform.position = teleportPoint.position;

            Debug.Log("Teleported!");
        }
        else
        {
            Debug.Log("Locked! Need key: " + requiredKey);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
