using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public KeyData keyData;

    [SerializeField] private GameObject pickupPrompt;
    [SerializeField] private GameObject keyObject; // nøkkelen

    private bool playerInRange = false;

    private void Start()
    {
        if (pickupPrompt != null)
            pickupPrompt.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            KeyInventory.Instance.AddKey(keyData);

            // Fortell bestemoren at nøkkelen er plukket opp
           Object.FindFirstObjectByType<GrandmaController>().keyCollected = true;

            ObjectiveManager.Instance.CompleteObjective(0);

            // Skjul E-indikatoren
            if (pickupPrompt != null)
                pickupPrompt.SetActive(false);

            // Ødelegg nøkkelen
            Destroy(keyObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;

            if (pickupPrompt != null)
                pickupPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            if (pickupPrompt != null)
                pickupPrompt.SetActive(false);
        }
    }
}
