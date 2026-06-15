using UnityEngine;

public class MonsterRegister : MonoBehaviour
{
    private void Awake()
    {
        MonsterController mc = GetComponent<MonsterController>();

        if (mc != null && CheckpointManager.Instance != null)
        {
            CheckpointManager.Instance.RegisterMonster(mc);
        }
    }
}