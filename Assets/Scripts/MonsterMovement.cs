using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public enum MoveDirection
    {
        Left,
        Right
    }

    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private MoveDirection direction = MoveDirection.Right;

    public bool canMove = false;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!canMove || rb == null)
            return;

        Vector2 dir = direction == MoveDirection.Right
            ? Vector2.right
            : Vector2.left;

        rb.MovePosition(rb.position + dir * moveSpeed * Time.fixedDeltaTime);
    }
}