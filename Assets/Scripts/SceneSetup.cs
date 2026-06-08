using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    public bool night;
    public int day;

    void Start()
    {
        if (night)
            GameProgressManager.Instance.StartNight(day);
        else
            GameProgressManager.Instance.StartDay(day);
    }
}
