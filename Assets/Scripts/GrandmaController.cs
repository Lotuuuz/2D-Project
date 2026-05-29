using UnityEngine;

public class GrandmaController : MonoBehaviour
{
    public bool isLooking = false;   // red light
    public bool isWarning = false;   // lookup-start

    public float warningTime = 1.5f; // hvor lenge hun er i lookup-start
    public float lookTime = 2f;      // hvor lenge hun er i lookup-loop
    public float idleTime = 3f;      // hvor lenge hun strikker

    private float timer;
    public Animator animator;

    void Start()
    {
        StartIdlePhase();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (!isWarning && !isLooking)
            {
                StartWarningPhase();   // Idle → Warning
            }
            else if (isWarning)
            {
                StartLookingPhase();   // Warning → Looking
            }
            else if (isLooking)
            {
                StartIdlePhase();      // Looking → Idle
            }
        }
    }

    void StartIdlePhase()
    {
        isWarning = false;
        isLooking = false;

        animator.SetBool("isLooking", false);
        animator.SetBool("isWarning", false);

        timer = idleTime;
    }

    void StartWarningPhase()
    {
        isWarning = true;
        isLooking = false;

        animator.SetBool("isWarning", true);
        animator.SetBool("isLooking", false);

        timer = warningTime;
    }

    void StartLookingPhase()
    {
        isWarning = false;
        isLooking = true;

        animator.SetBool("isWarning", false);
        animator.SetBool("isLooking", true);

        timer = lookTime;
    }
}
