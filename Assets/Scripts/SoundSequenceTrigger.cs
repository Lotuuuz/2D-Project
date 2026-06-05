using System.Collections;
using UnityEngine;

public class SoundSequenceTrigger : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip sound1;
    [SerializeField] private AudioClip sound2;
    [SerializeField] private AudioClip sound3;

    [Header("Activation")]
    [SerializeField] private GameObject objectToActivate;

    private Collider2D triggerCollider;
    private bool hasTriggered = false;

    private void Awake()
    {
        triggerCollider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered)
            return;

        if (other.CompareTag("Player"))
        {
            hasTriggered = true;
            StartCoroutine(PlaySoundsAndActivate());
        }
    }

    private IEnumerator PlaySoundsAndActivate()
    {
        // Play first sound
        audioSource.clip = sound1;
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);

        // Play second sound
        audioSource.clip = sound2;
        audioSource.Play();
        yield return new WaitWhile(() => audioSource.isPlaying);

        yield return new WaitForSeconds(1.0f);

        audioSource.clip = sound3;
        audioSource.Play();
        

        // Activate object
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }

        // Disable this trigger
        if (triggerCollider != null)
        {
            triggerCollider.enabled = false;
        }
    }
}
