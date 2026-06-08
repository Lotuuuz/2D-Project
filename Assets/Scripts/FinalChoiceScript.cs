using UnityEngine;

public class FinalChoiceScript : MonoBehaviour
{
    public GameObject buttonPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            buttonPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            buttonPanel.SetActive(false);
        }
    }
}
