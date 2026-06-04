using UnityEngine;

public class MonsterDeath : MonoBehaviour
{
    public StairTeleport teleportBool;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerDeath playerDeath = other.GetComponent<PlayerDeath>();

        if (playerDeath != null && teleportBool.isTeleporting == false)
        {
            playerDeath.Die();
        }

    }
}
