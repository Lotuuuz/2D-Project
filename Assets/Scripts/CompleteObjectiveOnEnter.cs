using UnityEngine;

public class CompleteObjectiveOnEnter : MonoBehaviour
{
    [SerializeField] private int objectiveIndex;
    public PuzzleStartTrigger puzzleStartTrigger;
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

            if (objectiveIndex == 1)
            {
                puzzleStartTrigger.puzzleUnlocked = true; 

            }

            Debug.Log("sletta");

            Destroy(gameObject);
        }
    }
}
