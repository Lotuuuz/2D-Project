using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public enum MoveDirection
    {
        Left,
        Right
    }

    [SerializeField] private float moveSpeed = 7.0f;
    [SerializeField] private MoveDirection direction = MoveDirection.Right;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 movement;

        if (direction == MoveDirection.Right)
        {
            movement = Vector2.right;
        }
        else
        {
            movement = Vector2.left;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

