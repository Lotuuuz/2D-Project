using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField]  private float moveSpeed = 7f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator anim;
    private SpriteRenderer sprite;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
      

        

        anim.SetFloat("Speed", Mathf.Abs(movement.x));
        anim.SetFloat("Direction", movement.x);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}