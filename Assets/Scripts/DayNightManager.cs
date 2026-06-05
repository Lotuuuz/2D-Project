using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    public static DayNightManager Instance;

    [Header("References")]
    public Animator playerAnim;
    public GameObject dayLight;
    public GameObject candleLight;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ApplyTimeOfDay();
    }

    public void ApplyTimeOfDay()
    {
        bool isNight = GameProgressManager.Instance.isNight;

        playerAnim.SetBool("IsNight", isNight);
        dayLight.SetActive(!isNight);
        candleLight.SetActive(isNight);
    }
}
