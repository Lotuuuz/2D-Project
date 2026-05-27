using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.0f;


    private Rigidbody2D rb;

    private Vector2 movement;

    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector2.zero;

        movement.x = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(movement.x));

        animator.SetFloat("Direction", movement.x);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
