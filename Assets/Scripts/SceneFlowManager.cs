using UnityEngine;

public class SceneFlowManager : MonoBehaviour
{
    public static SceneFlowManager Instance;

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

    // Returnerer riktig neste scene basert på dag/natt
    public string GetNextScene()
    {
        int day = GameProgressManager.Instance.currentDay;
        bool isNight = GameProgressManager.Instance.isNight;

        // Night 1 → Day 1
        if (day == 1 && isNight)
            return "Level 2 (Day 1)";

        // Day 1 → Night 2
        if (day == 1 && !isNight)
            return "Level 3 (Night 2)";

        // Night 2 → Day 2
        if (day == 2 && isNight)
            return "Level 4 (Day 2)";

        // Day 2 → Night 3
        if (day == 2 && !isNight)
            return "Level 5 (Night 3)";

        // Night 3 → ingen scene (spilleren får valg)
        return null;
    }
}
