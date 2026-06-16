using UnityEngine;

public class GameProgressManager : MonoBehaviour
{
    public static GameProgressManager Instance;

    [HideInInspector] public int currentDay = 1;
    [HideInInspector] public bool isNight = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void SetTime(int day, bool night)
    {
        currentDay = day;
        isNight = night;
    }
}
