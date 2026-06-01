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
            obj.SetActive(!obj.activeSelf);
        }
    }
}
