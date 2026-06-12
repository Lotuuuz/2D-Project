using UnityEngine;

public class LightActivator : MonoBehaviour
{
    [SerializeField] private GameObject lightObject;

    public void Activate()
    {
        lightObject.SetActive(true);
    }
}