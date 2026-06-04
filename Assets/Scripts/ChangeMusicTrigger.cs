using UnityEngine;

public class ChangeMusicTrigger : MonoBehaviour
{
    public MusicManager musicManager;

    [SerializeField] private bool playNormalMusic = true;

    [SerializeField] private bool playChaseMusic = false;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (playNormalMusic == true)
            {
                musicManager.PlayNormalMusic();
            }

            if (playChaseMusic == true)
            {
                musicManager.PlayChaseMusic();
            }


        }
    }
}
