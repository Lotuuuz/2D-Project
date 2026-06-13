using UnityEngine;
using UnityEngine.EventSystems;

public class FuseTiles : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private FusePuzzleManager puzzleManager;

    [SerializeField] private bool requiredForSolution = true;
    [SerializeField] private bool straightWire = false;

    private int currentRotation;

    private void Start()
    {
        currentRotation = Random.Range(1, 4);

        transform.rotation =
            Quaternion.Euler(0f, 0f, -90f * currentRotation);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked " + gameObject.name);

        currentRotation = (currentRotation + 1) % 4;

        transform.Rotate(0f, 0f, -90f);

        puzzleManager.CheckPuzzle();
    }

    public bool IsCorrect()
    {
        if (straightWire)
        {
            return currentRotation == 0 || currentRotation == 2;
        }

        return currentRotation == 0;
    }

    public bool IsRequiredForSolution()
    {
        return requiredForSolution;
    }
}