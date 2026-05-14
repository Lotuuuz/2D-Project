using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(movement.x));
        anim.SetFloat("Direction", movement.x);

        // Start door interact ONCE
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("IsDoor", true);
        }

        // Reset IsDoor when animation finishes
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);

        if (state.IsName("Interact_Door_Day") && state.normalizedTime >= 1f)
        {
            anim.SetBool("IsDoor", false);
        }

        if (state.IsName("Interact_Door_Night") && state.normalizedTime >= 1f)
        {
            anim.SetBool("IsDoor", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
