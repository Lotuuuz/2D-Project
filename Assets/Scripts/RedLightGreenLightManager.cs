using UnityEngine;

public class RedLightGreenLightManager : MonoBehaviour
{
    public GrandmaController grandma;
    public MovementPlayer player;
    public Transform failResetPoint;

    public bool puzzleCompleted = false;

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = player.transform.position;
    }

    void Update()
    {
        if (grandma.isLooking)
        {
            // sjekker om spilleren beveger seg
            float distanceMoved = Vector3.Distance(player.transform.position, lastPosition);

            if (distanceMoved > 0.01f)
            {
                Fail();
            }
        }

        lastPosition = player.transform.position;
    }

    void Fail()
    {
        Debug.Log("Du ble tatt!");

        
        player.transform.position = failResetPoint.position;

        
        player.isFrozen = false;
       player.rb.linearVelocity = Vector2.zero;



        lastPosition = player.transform.position;

        grandma.isLooking = false;
        grandma.animator.SetBool("isLooking", false);
    }
}
