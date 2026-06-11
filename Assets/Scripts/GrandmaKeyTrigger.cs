using UnityEngine;

public class GrandmaKeyTrigger : MonoBehaviour
{
    [Header("Key Settings")]
    public KeyData keyData;               // Hvilken nøkkel dette er
    public GameObject pickupPrompt;       // E-indikator
    public GameObject keyObject;          // Selve nøkkelobjektet

    [Header("Puzzle Settings")]
    public GrandmaController grandma;     // Bestemoren
    public int objectiveIndexToComplete;  // Hvilket objective som skal fullføres

    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Legg nøkkelen i inventory
            KeyInventory.Instance.AddKey(keyData);

            // Fortell bestemoren at nøkkelen er plukket opp
            if (grandma != null)
                grandma.keyCollected = true;

            // Fullfør objective
            ObjectiveManager.Instance.CompleteObjective(objectiveIndexToComplete);

            // Skjul E-indikator
            if (pickupPrompt != null)
                pickupPrompt.SetActive(false);

            // Fjern nøkkelen
            Destroy(keyObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;

            if (pickupPrompt != null)
                pickupPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;

            if (pickupPrompt != null)
                pickupPrompt.SetActive(false);
        }
    }
}
