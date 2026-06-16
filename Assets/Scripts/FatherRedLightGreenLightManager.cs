using UnityEngine;

public class FatherRedLightGreenLightManager : MonoBehaviour
{
    public FatherController father;
    public MovementPlayer player;
    public Transform FailResetPoint;

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = player.transform.position;
    }

    void Update()
    {
        if (father.isLooking)
        {
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
        Debug.Log("Du ble tatt av faren!");

        // Reset spiller
        player.transform.position = FailResetPoint.position;
        player.rb.linearVelocity = Vector2.zero;
        player.isFrozen = false;

        lastPosition = player.transform.position;

        // Reset faren
        father.isLooking = false;
        father.animator.SetBool("isLooking", false);
    }
}
