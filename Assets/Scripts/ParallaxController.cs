using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private float startPos;

    private float lenght;

    [SerializeField] private GameObject cam;

    [SerializeField] private float parallaxEffect;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.x;

        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect; // 0 = move with camera || 1 = won't move 
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3 (startPos + distance, transform.position.y, transform.position.z);
    }
}
