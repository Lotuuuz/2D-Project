using UnityEngine;
using TMPro;

public class KeyPickup : MonoBehaviour
{
    public string keyName;

    [SerializeField] private GameObject pickupPrompt;

    private bool playerInRange = false;

    private void Start()
    {
        pickupPrompt.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            KeyManager.Instance.AddKey(keyName);

            Debug.Log("Picked up:" + keyName);

            pickupPrompt.SetActive(false);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            pickupPrompt.SetActive(true);

            Debug.Log("Press E to pick up key");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            pickupPrompt.SetActive(false);
        }
    }
}
