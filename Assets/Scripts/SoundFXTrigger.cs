using UnityEngine;

public class SoundFXTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip[] soundClips;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        SoundFXManager.Instance.PlayRandomSoundFXClip(soundClips, transform, 1f);


    }
}
