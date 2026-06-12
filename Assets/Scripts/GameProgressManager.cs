using UnityEngine;

public class GameProgressManager : MonoBehaviour
{
    public static GameProgressManager Instance;

    public int currentDay = 1;   // 1, 2, 3
    public bool isNight = true; // false = dag, true = natt

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
        }
    }

    public void StartDay(int day)
    {
        currentDay = day;
        isNight = false;
    }

    public void StartNight(int day)
    {
        currentDay = day;
        isNight = true;
    }
}
