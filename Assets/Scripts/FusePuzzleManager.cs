using UnityEngine;

public class FusePuzzleManager : MonoBehaviour
{
    [SerializeField] private FuseTiles[] tiles;
    [SerializeField] private FusePuzzle fusePuzzle;

    private bool solved;

    public void CheckPuzzle()
    {
        if (solved)
            return;

        foreach (FuseTiles tile in tiles)
        {
            if (!tile.IsCorrect())
                return;
        }

        solved = true;

        fusePuzzle.OnPuzzleSolved();
    }
}