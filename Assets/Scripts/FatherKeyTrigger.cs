using UnityEngine;

public class FatherKeyTrigger : MonoBehaviour
{
    [Header("Key Settings")]
    public KeyData keyData;
    public GameObject pickupPrompt;
    public GameObject keyObject;

    [Header("Puzzle Settings")]
    public FatherController father;
    public int objectiveIndexToComplete;

    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            // Legg nøkkelen i inventory
            KeyInventory.Instance.AddKey(keyData);

            // Fortell faren at nøkkelen er plukket opp
            if (father != null)
                father.keyCollected = true;

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
