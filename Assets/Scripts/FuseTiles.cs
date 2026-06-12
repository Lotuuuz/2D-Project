using UnityEngine;
using UnityEngine.EventSystems;

public class FuseTiles : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private FusePuzzleManager puzzleManager;

    private int currentRotation;

    private void Start()
    {
        currentRotation = Random.Range(1, 4);

        transform.rotation =
            Quaternion.Euler(0f, 0f, -90f * currentRotation);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        currentRotation = (currentRotation + 1) % 4;

        transform.Rotate(0f, 0f, -90f);

        puzzleManager.CheckPuzzle();
    }

    public bool IsCorrect()
    {
        return currentRotation == 0;
    }
}