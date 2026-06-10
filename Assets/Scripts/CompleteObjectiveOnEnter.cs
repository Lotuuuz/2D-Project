using UnityEngine;

public class CompleteObjectiveOnEnter : MonoBehaviour
{
    [SerializeField] private int objectiveIndex;

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
    }
}
