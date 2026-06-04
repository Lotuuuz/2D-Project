using UnityEngine;
using UnityEngine.Playables;

public class CutsceneDialogueEvent : MonoBehaviour
{
    public PlayableDirector director;
    public DialogueTriggerSystem dialogue;

    private void Start()
    {
        dialogue.OnDialogueFinished += ResumeTimeline;
    }

    private void ResumeTimeline()
    {
        director.Resume();
    }

    public void StartDialogue()
    {
        director.Pause();

        dialogue.TriggerDialogue();
    }
}
