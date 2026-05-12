using UnityEngine;

public class ObjectFollowPoint : MonoBehaviour
{
    [SerializeField] private Transform pointToFollow;

    [SerializeField] private float movementFactorX = 1.0f;

    [SerializeField] private float movementFactorY = 1.0f;

    [SerializeField] private float positionOffsetZ = 0.0f;

    private void LateUpdate()
    {
        transform.position = new Vector3(pointToFollow.position.x * movementFactorX, pointToFollow.position.y * movementFactorY, positionOffsetZ);
    }
}
