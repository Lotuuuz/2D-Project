using UnityEngine;

public class FatherController : MonoBehaviour
{
    public Animator animator;

    public float idleTime = 2.5f;
    public float warningTime = 1.2f;
    public float lookTime = 1.8f;

    private float timer;

    public bool keyCollected = false;
    public bool puzzleActive = false;

    // Lesbare states for puzzle manager
    public bool IsIdle => !animator.GetBool("isWarning") && !animator.GetBool("isLooking");
    public bool IsWarning => animator.GetBool("isWarning");
    public bool IsLooking => animator.GetBool("isLooking");

    void Start()
    {
        SetIdle(); // faren starter alltid i Idle-Sleep
    }

    void Update()
    {
        // Puzzle ikke aktiv → faren skal sove
        if (!puzzleActive)
        {
            SetIdle();
            return;
        }

        // Hvis nøkkelen er tatt → avslutt puzzle og sett faren til Idle
        if (keyCollected)
        {
            SetIdle();
            puzzleActive = false;
            return;
        }

        // Puzzle er aktiv → kjør faseloopen
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (IsLooking)
                SetIdle();
            else if (IsWarning)
                SetLooking();
            else
                SetWarning();
        }
    }

    // -------------------------
    // FASEMETODER
    // -------------------------

    public void SetIdle()
    {
        animator.SetBool("isWarning", false);
        animator.SetBool("isLooking", false);
        timer = idleTime;
    }

    public void SetWarning()
    {
        animator.SetBool("isWarning", true);
        animator.SetBool("isLooking", false);
        timer = warningTime;
    }

    public void SetLooking()
    {
        animator.SetBool("isWarning", false);
        animator.SetBool("isLooking", true);
        timer = lookTime;
    }

    // Kalles av PuzzleStartTrigger
    public void ActivatePuzzle()
    {
        puzzleActive = true;
        SetWarning(); // faren begynner å våkne
    }
}
