using UnityEngine;

public class PuzzleKeyTrigger : MonoBehaviour
{
    public RedLightGreenLightManager puzzleManager;
    public GameObject keyObject; // selve nøkkelen spilleren skal plukke opp

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("TRIGGER HIT:");

        if (collision.CompareTag("Player"))
        {
            Debug.Log("PLAYER HIT TRIGGER!");
            // spilleren har nådd nøkkelen uten å bli tatt
            puzzleManager.puzzleCompleted = true;


            // fjern triggeren
            gameObject.SetActive(false);
        }
    }
}
