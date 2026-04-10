using UnityEngine;

public class PlayerMovement : MonoBehaviour

{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Rigidbody.MovePosition (position + movement + moveSpeed * Time.fixedDeltaTime); 
    }
}