using UnityEngine;

public class ObjectDeactivator : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToDeactivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj == null) continue;

            obj.SetActive(false);
        }
    }
}