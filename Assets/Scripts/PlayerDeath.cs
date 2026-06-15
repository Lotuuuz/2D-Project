using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public void Die()
    {
        CheckpointManager.Instance.RespawnPlayer(gameObject);
    }
}