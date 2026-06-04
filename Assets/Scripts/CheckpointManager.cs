using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    private Vector3 checkpointPosition;

    private Dictionary<GameObject, bool> savedStates =
        new Dictionary<GameObject, bool>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        else
            Destroy(gameObject);
    }


    public void SaveCheckpoint(Vector3 playerposition, List<GameObject> objectsToTrack)
    {
        checkpointPosition = playerposition;

        savedStates.Clear();

        foreach (GameObject obj in objectsToTrack)
        {
            if (obj != null)
            {
                savedStates[obj] = obj.activeSelf;
            }
        }

        Debug.Log("Checkpoint Saved");
    }

    public void RespawnPlayer(GameObject player)
    {
        player.transform.position = checkpointPosition;

        foreach (var pair in savedStates)
        {
            if (pair.Key != null)
            {
                pair.Key.SetActive(pair.Value);
            }
        }

        Debug.Log("Checkpoint Restored");
    }

}
