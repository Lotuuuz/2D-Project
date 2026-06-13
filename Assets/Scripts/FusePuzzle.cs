using UnityEngine;

public class FusePuzzle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject puzzleUI;
    [SerializeField] private GameObject interactionIndicator;
    [SerializeField] private MonoBehaviour playerMovement;
    [SerializeField] private LightActivator lightActivator;

    private bool playerInRange;
    private bool puzzleSolved;

    private void Start()
    {
        if (interactionIndicator != null)
            interactionIndicator.SetActive(false);

        if (puzzleUI != null)
            puzzleUI.SetActive(false);
    }

    private void Update()
    {
        if (puzzleSolved)
            return;

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed");
            OpenPuzzle();
        }
    }

    private void OpenPuzzle()
    {
        Debug.Log("Opening puzzle");

        if (interactionIndicator != null)
            interactionIndicator.SetActive(false);

        if (puzzleUI != null)
            puzzleUI.SetActive(true);

        if (playerMovement != null)
            ((MovementPlayer)playerMovement).isFrozen = true;
    }

    public void ClosePuzzle()
    {
        if (puzzleUI != null)
            puzzleUI.SetActive(false);

        if (playerMovement != null)
            ((MovementPlayer)playerMovement).isFrozen = false;

        if (!puzzleSolved && playerInRange && interactionIndicator != null)
            interactionIndicator.SetActive(true);
    }

    public void OnPuzzleSolved()
    {
        puzzleSolved = true;

        if (interactionIndicator != null)
            interactionIndicator.SetActive(false);

        if (lightActivator != null)
            lightActivator.Activate();

        ClosePuzzle();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        Debug.Log("Player entered trigger");

        playerInRange = true;

        if (!puzzleSolved && interactionIndicator != null)
            interactionIndicator.SetActive(true);

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInRange = false;

        if (interactionIndicator != null)
            interactionIndicator.SetActive(false);
    }
}