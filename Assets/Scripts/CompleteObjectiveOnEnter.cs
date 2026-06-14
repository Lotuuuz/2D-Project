using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteObjectiveOnEnter : MonoBehaviour
{
    [SerializeField] private int objectiveIndex;
    public PuzzleStartTrigger puzzleStartTrigger;
    public GameObject keyToActivate;
    public  FatherPuzzleStartTrigger fatherPuzzleStartTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!ObjectiveManager.Instance.IsCompleted(objectiveIndex - 1) && objectiveIndex != 0)
        {
            Debug.Log("hgfhg");
            return;

        }
        if (collision.CompareTag("Player"))
        {
            ObjectiveManager.Instance.CompleteObjective(objectiveIndex);

            // Når objective 1 fullføres:
            if (objectiveIndex == 1)
            {
                // 1. Vis nøkkelen
                if (keyToActivate != null)
                    keyToActivate.SetActive(true);

                // 2. Unlock puzzlet
                if (puzzleStartTrigger != null)
                    puzzleStartTrigger.puzzleUnlocked = true;
            }
        }

        if (collision.CompareTag("Player"))
        {
            ObjectiveManager.Instance.CompleteObjective(objectiveIndex);

            // ⭐ FAR-PUZZLE STARTER HER
            if (objectiveIndex == 0) // dette er objective som unlocker far-puzzlet
            {
                // 1. Unlock puzzle
                if (fatherPuzzleStartTrigger != null)
                    fatherPuzzleStartTrigger.puzzleUnlocked = true;

                // 2. Vis nøkkelen (Study Key)
                if (keyToActivate != null)
                    keyToActivate.SetActive(true);
            }
        }



        Debug.Log("sletta");
            Destroy(gameObject);
        }



    }

