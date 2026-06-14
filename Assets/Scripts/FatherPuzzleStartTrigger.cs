using UnityEngine;

public class FatherPuzzleStartTrigger : MonoBehaviour
{
    public FatherController father;   // Dra inn faren her
    public bool puzzleUnlocked = false;
    public GameObject keyToActivate;
    public FatherPuzzleManager puzzleManager;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Puzzle må være unlocked av CompleteObjectiveOnEnter
        if (!puzzleUnlocked) return;

        // Spilleren må gå inn i triggeren
        if (!collision.CompareTag("Player")) return;

        // Aktiver farens puzzle
        father.ActivatePuzzle();
        puzzleManager.ActivatePuzzle();

        // Triggeren brukes bare én gang
        Invoke(nameof(DisableTrigger), 0.1f);
    }

    void DisableTrigger()
    {
        gameObject.SetActive(false);
    }
}
