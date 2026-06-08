using UnityEngine;

public class UIButtonActivator : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    public void ActivateObject1()
    {
        object1.SetActive(true);
    }

    public void ActivateObject2()
    {
        object2.SetActive(true);
    }

    public void ActivateObject3()
    {
        object3.SetActive(true);
    }
}
