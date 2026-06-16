using UnityEngine;

public class FatherController : MonoBehaviour
{
    public bool isLooking = false;
    public bool isWarning = false;

    public float warningTime = 1.5f;
    public float lookTime = 2f;
    public float idleTime = 3f;

    public bool keyCollected = false;
    private float timer;
    public Animator animator;


    [SerializeField] private AudioClip[] fatherSnoreClips;

    void Update()
    {
        // ⭐ Stopp alt hvis nøkkelen er plukket opp
        if (keyCollected)
        {
            isLooking = false;
            isWarning = false;

            animator.SetBool("isLooking", false);
            animator.SetBool("isWarning", false);

            animator.Play("Idle-Sleep"); // farens idle animasjon
            return;
        }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (!isWarning && !isLooking)
            {
                StartWarningPhase();
            }
            else if (isWarning)
            {
                StartLookingPhase();
            }
            else if (isLooking)
            {
                StartIdlePhase();
            }
        }
    }

    public void StartIdlePhase()
    {
        isWarning = false;
        isLooking = false;

        animator.SetBool("isWarning", false);
        animator.SetBool("isLooking", false);

        timer = idleTime;


        SoundFXManager.Instance.PlayRandomSoundFXClip(fatherSnoreClips, transform, 1f);


    }

    public void StartWarningPhase()
    {
        isWarning = true;
        isLooking = false;

        animator.SetBool("isWarning", true);
        animator.SetBool("isLooking", false);

        timer = warningTime;
    }

    public void StartLookingPhase()
    {
        isWarning = false;
        isLooking = true;

        animator.SetBool("isWarning", false);
        animator.SetBool("isLooking", true);

        timer = lookTime;
    }
}
