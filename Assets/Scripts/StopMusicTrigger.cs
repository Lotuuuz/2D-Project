using System;
using UnityEngine;

public class StopMusicTrigger : MonoBehaviour
{
    [SerializeField] private MusicManager musicManager;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            musicManager.FadeOutAndStop();
        }
    }
}
