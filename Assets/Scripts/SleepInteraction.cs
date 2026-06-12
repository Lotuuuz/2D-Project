using UnityEngine;

public class SleepInteraction : MonoBehaviour
{
    public GameObject indicator;

    private void Update()
    {
        if (SceneObjectiveTracker.Instance == null)
        {
            indicator.SetActive(false);
            return;
        }

        indicator.SetActive(SceneObjectiveTracker.Instance.AllCompleted());
    }

    public bool CanSleep()
    {
        return SceneObjectiveTracker.Instance != null &&
               SceneObjectiveTracker.Instance.AllCompleted();
    }
}
