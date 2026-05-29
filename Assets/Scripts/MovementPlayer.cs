using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7.0f;


    public Rigidbody2D rb;

    private Vector2 movement;

    private Animator animator;
    public bool isFrozen = false;


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

        if (isFrozen)
        {
            movement = Vector2.zero;
            return;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
