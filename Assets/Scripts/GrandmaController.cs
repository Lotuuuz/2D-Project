using UnityEngine;

public class GrandmaController : MonoBehaviour
{
    public bool isLooking = false;   // red light
    public bool isWarning = false;   // lookup-start

    public float warningTime = 1.5f; // hvor lenge hun er i lookup-start
    public float lookTime = 2f;      // hvor lenge hun er i lookup-loop
    public float idleTime = 3f;      // hvor lenge hun strikker

    public bool keyCollected = false;
    public bool puzzleActivate;

    private float timer;
    public Animator animator;
    [SerializeField] private AudioClip[] knittingSoundClip;

    void Start()
    {
        
    }

   public void Update()
    {
        //stopp alt hvis nøkkelen er plukket opp 
        if (keyCollected)

        {
            isLooking = false;
            isWarning = false;

            animator.SetBool("isLooking", false);
            animator.SetBool("isWarning", false);

            animator.Play("Idle-Knitting");
            return; // stopper all annen logikk 

        }


        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (!isWarning && !isLooking)
            {
                StartWarningPhase();   // idle → Warning
            }
            else if (isWarning)
            {
                StartLookingPhase();   // warning → Looking
            }
            else if (isLooking)
            {
                StartIdlePhase();      // looking → Idle
            }
        }

     
    }

  public  void StartIdlePhase()
    {
        isWarning = false;
        isLooking = false;

        animator.SetBool("isLooking", false);
        animator.SetBool("isWarning", false);

        timer = idleTime;
        SoundFXManager.Instance.PlayRandomSoundFXClip(knittingSoundClip, transform, 1f);

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
