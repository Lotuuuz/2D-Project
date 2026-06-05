using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovementDisabler : MonoBehaviour
{
    public PlayableDirector director;
    public MovementPlayer movementPlayer;

    void Start()
    {
        director.played += OnTimelineStarted;
        director.stopped += OnTimelineStopped;
    }

    public void OnTimelineStarted(PlayableDirector pd)
    {
        movementPlayer.enabled = false;
    }

    public void OnTimelineStopped(PlayableDirector pd)
    {
        movementPlayer.enabled = true;
    }
}