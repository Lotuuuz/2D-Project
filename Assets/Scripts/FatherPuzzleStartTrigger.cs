using UnityEngine;

public class FatherPuzzleStartTrigger : MonoBehaviour
{
    public FatherController father;
    public FatherRedLightGreenLightManager puzzleManager;

    public bool puzzleUnlocked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!puzzleUnlocked) return;

        if (collision.CompareTag("Player"))
        {
            father.enabled = true;
            father.StartWarningPhase();   // start rett i lookup-start

            puzzleManager.enabled = true;

            gameObject.SetActive(false);
        }
    }
}
