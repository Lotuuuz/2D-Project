using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovementDisabler : MonoBehaviour
{
    public PlayableDirector director;
    public MovementPlayer movementPlayer;

    public void OnTimelineStarted(PlayableDirector pd)
    {
#pragma warning disable CS0618
        if (movementPlayer == null)
            movementPlayer = FindObjectOfType<MovementPlayer>();
#pragma warning restore CS0618

        // Bare bruk movementPlayer hvis den faktisk finnes
        if (movementPlayer != null)
            movementPlayer.enabled = false;
    }

    public void OnTimelineStopped(PlayableDirector pd)
    {
#pragma warning disable CS0618
        if (movementPlayer == null)
            movementPlayer = FindObjectOfType<MovementPlayer>();
#pragma warning restore CS0618


        // Bare bruk movementPlayer hvis den faktisk finnes
        if (movementPlayer != null)
            movementPlayer.enabled = true;
    }

}