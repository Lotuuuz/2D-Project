using UnityEngine;

public class CompleteObjectiveOnEnter : MonoBehaviour
{
    [SerializeField] private int objectiveIndex;

    public PuzzleStartTrigger puzzleStartTrigger;              // Bestemor
    public FatherPuzzleStartTrigger fatherPuzzleStartTrigger;  // Faren
    public GameObject keyToActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        // Sjekk om forrige objective er fullført (gjelder ikke objective 0)
        if (objectiveIndex != 0 && !ObjectiveManager.Instance.IsCompleted(objectiveIndex - 1))
            return;

        if (ObjectiveManager.Instance.activeObjectives.Count <= objectiveIndex || ObjectiveManager.Instance.activeObjectives[objectiveIndex].completed == true)
            return;

        // Fullfør dette objective
        ObjectiveManager.Instance.CompleteObjective(objectiveIndex);

        // ⭐ BESTEMORA sitt puzzle (objective 1)
        if (objectiveIndex == 1)
        {
            if (keyToActivate != null)
                keyToActivate.SetActive(true);

            if (puzzleStartTrigger != null)
                puzzleStartTrigger.puzzleUnlocked = true;
        }

        // ⭐ FAREN sitt puzzle (objective 0)
        else if (objectiveIndex == 0)
        {
            if (keyToActivate != null)
                keyToActivate.SetActive(true);

            if (fatherPuzzleStartTrigger != null)
                fatherPuzzleStartTrigger.puzzleUnlocked = true;
        }
        gameObject.SetActive(false);

    }
}


