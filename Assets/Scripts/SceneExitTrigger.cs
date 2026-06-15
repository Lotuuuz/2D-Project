using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExitTrigger : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] private int finalObjectiveIndex;

    [SerializeField] private SpriteRenderer keyIndicator; 

    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (ObjectiveManager.Instance.IsCompleted(finalObjectiveIndex))
            {
                SceneManager.LoadScene(nextSceneName);
            }
            else
            {
                Debug.Log("Complete all objectives first!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;

            keyIndicator.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;

            keyIndicator.enabled = false;
        }
    }
}
