using UnityEngine;


//The list of sound effects
public enum SoundType
{
    //These are examples from my previous project. Write the name of the sound effect like this, and drag the sound into the list in the inspector
    
    //LONGJUMP,
    //SHORTJUMP,
    //LAND,
    //GRAB,
    //FOOTSTEP
}

//It has to have an audiosource, and adds one if there isn't
[RequireComponent(typeof(AudioSource))]

public class SoundEffectsManager : MonoBehaviour
{
    //The list in inspector
    [SerializeField] private AudioClip[] soundList;
    
    private static SoundEffectsManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //Reference this method in other scripts where you want a sound effect.
    //Like this for example: SoundEffectsManager.PlaySound(SoundType.GRAB, 1); It needs SoundType, name of the sound effect, and the volume it should play at
    public static void PlaySound(SoundType sound, float volume)
    {
        instance.audioSource.PlayOneShot(instance.soundList[(int)sound], volume);
    }
}
