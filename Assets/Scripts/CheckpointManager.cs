using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    private Vector3 checkpointPosition;

    private List<MonsterController> monsters =
        new List<MonsterController>();

    private List<MonsterTrigger> triggers =
        new List<MonsterTrigger>();

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterMonster(MonsterController monster)
    {
        if (!monsters.Contains(monster))
            monsters.Add(monster);
    }

    public void RegisterTrigger(MonsterTrigger trigger)
    {
        if (!triggers.Contains(trigger))
            triggers.Add(trigger);
    }

    public void SaveCheckpoint(Vector3 playerPosition)
    {
        checkpointPosition = playerPosition;
        Debug.Log("Checkpoint Saved");
    }

    public void RespawnPlayer(GameObject player)
    {
        player.transform.position = checkpointPosition;

        // RESET MONSTERS
        foreach (var m in monsters)
        {
            m.ResetToCheckpoint();
        }

        // RESET TRIGGERS (THIS FIXES YOUR BUG)
        foreach (var t in triggers)
        {
            if (t != null)
                t.ResetTrigger();
        }

        Debug.Log("Checkpoint Restored");
    }
}