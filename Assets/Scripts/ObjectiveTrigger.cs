using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    [SerializeField] private int objectiveIndex = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        Debug.Log("Trigger funker!");

        // aktiver objective når spilleren går inn i triggeren
        ObjectiveManager.Instance.ActivateObjective(objectiveIndex);

        // slett triggeren så den ikke kjører igjen
        Destroy(gameObject);
    }
}
