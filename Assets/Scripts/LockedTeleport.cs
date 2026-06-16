using UnityEngine;

public class LockedTeleport : MonoBehaviour
{
    [Header("Key Needed")]
    public string requiredKey;

    [Header("Teleport Destination")]
    public Transform teleportPoint;

    [Header("UI")]
    public GameObject eIndicator;

    private bool playerInRange;

    private void Start()
    {
        if (eIndicator != null)
            eIndicator.SetActive(false);
    }

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

            if (eIndicator != null)
                eIndicator.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (eIndicator != null)
                eIndicator.SetActive(false);
        }
    }
}
