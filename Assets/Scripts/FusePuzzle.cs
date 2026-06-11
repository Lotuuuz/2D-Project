using Unity.Cinemachine;
using UnityEngine;

public class FusePuzzle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject puzzleUI;
    [SerializeField] private MonoBehaviour playerController;
    [SerializeField] private LightActivator lightActivator;

    private bool PlayerInRange;
    private bool puzzleSolved;
    private bool puzzleOpen;

    private void Update()
    {
        if (puzzleSolved)
            return;

        if (PlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!puzzleOpen)
            {
                OpenPuzzle();
            }
        }
    }

    public void OpenPuzzle()
    {
        puzzleOpen = true;

        puzzleUI.SetActive(true);

        if (playerController != null)
            playerController.enabled = false;
    }

    private void ClosePuzzle()
    {
        puzzleOpen = false;

        puzzleUI.SetActive(false);

        if (playerController != null)
            playerController.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }
}
