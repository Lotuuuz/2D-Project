using UnityEngine;

public class CompleteObjectiveOnEnter : MonoBehaviour
{
    [SerializeField] private int objectiveIndex;
    public PuzzleStartTrigger puzzleStartTrigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (ObjectiveManager.Instance.activeObjectives.Count < objectiveIndex + 1)
        {
          
            return;

        }

        if (collision.CompareTag("Player"))
        {
          
            ObjectiveManager.Instance.CompleteObjective(objectiveIndex);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            ObjectiveManager.Instance.CompleteObjective(objectiveIndex);

            if (objectiveIndex == 7)
            {
                puzzleStartTrigger.puzzleUnlocked = true; 

            }

            Destroy(gameObject);
        }
    }
}
