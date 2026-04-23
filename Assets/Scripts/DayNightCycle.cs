using UnityEngine;

public class DayNightManager : MonoBehaviour
{
    [Header("References")]
    public Animator playerAnim;
    public GameObject dayLight;      // global Light 2D for dag
    public GameObject candleLight;   // point Light 2D på spilleren

    [Header("Settings")]
    public bool isNight = false;

    void Start()
    {
        ApplyTimeOfDay();
    }

    public void SwitchToDay()
    {
        isNight = false;
        ApplyTimeOfDay();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            SwitchToNight();

        if (Input.GetKeyDown(KeyCode.Y))
            SwitchToDay();
    }
    public void SwitchToNight()
    {
        isNight = true;
        ApplyTimeOfDay();
    }

    private void ApplyTimeOfDay()
    {
       
        playerAnim.SetBool("IsNight", isNight);

        
        dayLight.SetActive(!isNight);
        candleLight.SetActive(isNight);
    }
}
