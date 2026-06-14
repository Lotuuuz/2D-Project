using UnityEngine;

public class FatherPuzzleManager : MonoBehaviour
{
    public FatherController father;
    public MovementPlayer player;
    public Transform failResetPoint;

    public bool puzzleActive = false;

    private Vector3 lastPosition;
    private bool justFailed = false;   // Grace-period flag

    void Start()
    {
        lastPosition = player.transform.position;
    }

    void Update()
    {
        if (!puzzleActive)
            return;

        // ⭐ Grace-period etter teleport
        if (justFailed)
        {
            player.isFrozen = false; // Spilleren skal kunne bevege seg
            return;                 // Ikke sjekk Warning/Looking enda
        }

        // ⭐ Spilleren fryses KUN i Warning
        if (father.IsWarning)
        {
            player.isFrozen = true;
        }
        else
        {
            player.isFrozen = false;
        }

        // ⭐ Hvis faren ser → sjekk om spilleren beveger seg
        if (father.IsLooking)
        {
            float distanceMoved = Vector3.Distance(player.transform.position, lastPosition);

            if (distanceMoved > 0.01f)
            {
                Fail();
            }
        }

        lastPosition = player.transform.position;
    }

    public void ActivatePuzzle()
    {
        puzzleActive = true;
        father.ActivatePuzzle();
    }

    void Fail()
    {
        Debug.Log("Du ble tatt av faren!");

        justFailed = true; // ⭐ Start grace-period

        // Reset spiller
        player.transform.position = failResetPoint.position;
        player.rb.linearVelocity = Vector2.zero;
        player.isFrozen = false;

        lastPosition = player.transform.position;

        // Reset faren
        father.puzzleActive = false;
        father.SetIdle();

        // Restart puzzle etter litt
        Invoke(nameof(RestartPuzzle), 0.5f);

        // ⭐ Slutt på grace-period etter 1 sekund
        Invoke(nameof(EndGracePeriod), 1f);
    }

    void RestartPuzzle()
    {
        puzzleActive = true;
        father.ActivatePuzzle();
    }

    void EndGracePeriod()
    {
        justFailed = false;
    }
}
