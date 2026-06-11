using UnityEngine;

public class PuzzleStartTrigger : MonoBehaviour
{
    public GrandmaController grandma;
    public RedLightGreenLightManager puzzleManager;

    public bool puzzleUnlocked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!puzzleUnlocked) return;

        if (collision.CompareTag("Player"))
        {
            grandma.enabled = true;
            grandma.StartWarningPhase();   // start rett i lookup-start

            puzzleManager.enabled = true;

            gameObject.SetActive(false);
        }
    }
}
