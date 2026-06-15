using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        foreach (GameObject obj in objectsToActivate)
        {
            if (obj == null) continue;

            obj.SetActive(true);
        }
    }
}