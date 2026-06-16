using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    public bool night;
    public int day;

    void Awake()
    {
        GameProgressManager.Instance.SetTime(day, night);
    }
}
