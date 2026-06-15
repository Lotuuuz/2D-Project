using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Collider2D col;
    [SerializeField] private MonsterMovement movement;

    private Rigidbody2D rb;
    private Vector3 startPosition;

    //private bool startActive = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        DeactivateImmediate();
    }

    public void Activate()
    {
        sprite.enabled = true;
        col.enabled = true;
        movement.canMove = true;
    }

    public void Deactivate()
    {
        sprite.enabled = false;
        col.enabled = false;
        movement.canMove = false;

        if (rb != null)
            rb.linearVelocity = Vector2.zero;
    }

    public void ResetToCheckpoint()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.position = startPosition;
        }
        else
        {
            transform.position = startPosition;
        }

        DeactivateImmediate();
    }

    private void DeactivateImmediate()
    {
        sprite.enabled = false;
        col.enabled = false;
        movement.canMove = false;
    }
}