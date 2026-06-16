using UnityEngine;
using System.Collections;

public class MonsterDeath : MonoBehaviour
{
    public StairTeleport teleportBool;

    [SerializeField] private float secondsToWait = 2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerDeath playerDeath = other.GetComponent<PlayerDeath>();

        if (playerDeath != null && teleportBool.isTeleporting == false)
        {
            StartCoroutine(DelayedDeath(playerDeath));
        }
    }

    private IEnumerator DelayedDeath(PlayerDeath playerDeath)
    {
        yield return new WaitForSeconds(secondsToWait);

        if (playerDeath != null)
        {
            playerDeath.Die();
        }
    }
}
