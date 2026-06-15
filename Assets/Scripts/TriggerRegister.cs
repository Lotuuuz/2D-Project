using UnityEngine;

public class TriggerRegister : MonoBehaviour
{
    private void Awake()
    {
        MonsterTrigger t = GetComponent<MonsterTrigger>();

        if (t != null && CheckpointManager.Instance != null)
        {
            CheckpointManager.Instance.RegisterTrigger(t);
        }
    }
}