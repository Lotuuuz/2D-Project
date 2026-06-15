using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;

        if (!other.CompareTag("Player")) return;

        CheckpointManager.Instance.SaveCheckpoint(other.transform.position);

        activated = true;
    }
}