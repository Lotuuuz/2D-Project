using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Die()
    {
        CheckpointManager.Instance.RespawnPlayer(gameObject);
    }
}
