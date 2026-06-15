using UnityEngine;

public class ResettableObject : MonoBehaviour
{
    private Vector3 startPosition;
    private bool startActive;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        startActive = gameObject.activeSelf;
    }

    public void ResetState()
    {
        gameObject.SetActive(true);

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.position = startPosition;
        }
        else
        {
            transform.position = startPosition;
        }

        gameObject.SetActive(startActive);
    }
}