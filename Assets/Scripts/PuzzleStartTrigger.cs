using UnityEngine;

public class PuzzleStartTrigger : MonoBehaviour
{
    public GrandmaController grandma;
    public RedLightGreenLightManager puzzleManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            grandma.enabled = true;              // starter bestemoren 
            puzzleManager.enabled = true;        // aktiverer puzzlet
            gameObject.SetActive(false);         // fjerner triggeren så den ikke starter igjen
        }
    }
}

