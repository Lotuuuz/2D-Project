using UnityEngine;

public class StairTeleport : MonoBehaviour
{
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private GameObject promptUI; //So a prompt shows, asking if they want to go upstairs
    
    private bool playerInRange = false;
    private GameObject player; 
    
    
    // If the player is in the the trigger zone and presses e, they teleport
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TeleportPlayer();
        }
    }

    //When this method runs, move the player position, to the teleport target position (drag in in inspector)
    void TeleportPlayer()
    {
        player.transform.position = teleportTarget.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            player = collision.gameObject;

            if (promptUI != null)
                promptUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;

            if (promptUI != null)
                promptUI.SetActive(false);
        }
    }
}
