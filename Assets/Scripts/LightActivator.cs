using UnityEngine;

public class LightActivator : MonoBehaviour
{
    [SerializeField] private GameObject darknessOverlay;
    [SerializeField] private GameObject blockingWall;

    public void Activate()
    {
        if (darknessOverlay != null)
            darknessOverlay.SetActive(false);

        if (blockingWall != null)
            blockingWall.SetActive(false);
    }
}