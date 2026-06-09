using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    [SerializeField] private int objectiveIndex = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        // *Sjekk om forrige objective er fullført*
        if (objectiveIndex > 0)
        {
            if (!ObjectiveManager.Instance.IsCompleted(objectiveIndex - 1))
            {
                return; // Ikke aktiver dette objective ennå
            }
        }

        ObjectiveManager.Instance.ActivateObjective(objectiveIndex);
        Destroy(gameObject);
    }

}
