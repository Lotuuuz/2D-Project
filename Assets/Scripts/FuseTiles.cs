using UnityEngine;

public class FuseTiles : MonoBehaviour
{
    [SerializeField] private FusePuzzleManager puzzleManager;

    private int rotationIndex = 0;

    private void OnMouseDown()
    {
        RotateTile();
    }

    private void RotateTile()
    {
        rotationIndex = (rotationIndex + 1) % 4;

        transform.rotation = Quaternion.Euler(0f, 0f, -90f * rotationIndex);
        puzzleManager.CheckPuzzle();
    }

    public int GetRotationIndex()
    {
        return rotationIndex;
    }

}
