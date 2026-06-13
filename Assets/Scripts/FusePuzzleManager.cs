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
            if (!tile.IsRequiredForSolution())
                continue;

            if (!tile.IsCorrect())
            {
                Debug.Log(tile.name + " is not correct");
                return;
            }
        }

        solved = true;

        Debug.Log("Puzzle Solved!");

        if (fusePuzzle != null)
        {
            fusePuzzle.OnPuzzleSolved();
        }
    }
}