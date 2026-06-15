using UnityEngine;

public class ObjectToggler : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToToggle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        foreach (GameObject obj in objectsToToggle)
        {
            if (obj == null) continue;

            bool nextState = !obj.activeSelf;
            obj.SetActive(nextState);
        }
    }
}