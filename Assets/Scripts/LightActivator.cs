using UnityEngine;

public class LightActivator : MonoBehaviour
{
    [SerializeField] private GameObject blockingWall;
    [SerializeField] private GameObject basementLight;

    public void Activate()
    {

        if (blockingWall != null)
            blockingWall.SetActive(false);

        if (basementLight != null)
            basementLight.SetActive(true);
    }
}