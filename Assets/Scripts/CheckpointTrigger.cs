using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public List<GameObject> objectsToTrack = new List<GameObject>();

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated)
            return;

        if (other.CompareTag("Player"))
        {
            CheckpointManager.Instance.SaveCheckpoint(other.transform.position, objectsToTrack);

            activated = true;


        }

    }
}
