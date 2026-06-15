using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    [SerializeField] private MonsterController monster;

    private bool triggered = false;

    public void ResetTrigger()
    {
        triggered = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (triggered)
            return;

        monster.Activate();
        triggered = true;
    }
}