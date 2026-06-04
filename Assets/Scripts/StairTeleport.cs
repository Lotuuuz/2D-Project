using System.Collections;
using UnityEngine;

public class StairTeleport : MonoBehaviour
{
    [SerializeField] private Transform teleportTarget;
    //[SerializeField] private GameObject promptUI; //So a prompt shows, asking if they want to go upstairs

    [SerializeField] private SpriteRenderer keyIndicator;


    [SerializeField] private float teleportDelay = 1.35f;

    [SerializeField] private AudioClip[] stairSoundClips;

    [SerializeField] private AudioClip[] doorSoundClips;


    private bool playerInRange = false;
    private GameObject player; 

    private Animator playerAnimator;

    [HideInInspector] public bool isTeleporting = false;

    public bool isDoor;

    public bool isStair;


    // If the player is in the the trigger zone and presses e, they teleport
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !isTeleporting)
        {
            StartCoroutine(TeleportSequence());
        }
    }

    //When this method runs, move the player position, to the teleport target position (drag in in inspector)
    IEnumerator TeleportSequence()
    {
        isTeleporting = true;

        playerAnimator.SetTrigger("DoorInteract");

        if (isDoor == true)
        {
            SoundFXManager.Instance.PlayRandomSoundFXClip(doorSoundClips, transform, 1f);
        }

        if (isStair == true)
        {
            SoundFXManager.Instance.PlayRandomSoundFXClip(stairSoundClips, transform, 1f);
        }

        yield return new WaitForSeconds(teleportDelay);

        player.transform.position = teleportTarget.position;

        isTeleporting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            player = collision.gameObject;

            playerAnimator = player.GetComponent<Animator>();

            if (keyIndicator != null)
                keyIndicator.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;

            if (keyIndicator != null)
                keyIndicator.enabled = false;
        }
    }
}
