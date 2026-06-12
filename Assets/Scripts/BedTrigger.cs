using UnityEngine;

public class BedTrigger : MonoBehaviour
{
    public SleepInteraction sleep;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            sleep.CanSleep();
        }
    }
}
