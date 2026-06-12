using UnityEngine;

public class SleepIndicator : MonoBehaviour
{
    public GameObject indicator; // UI eller ikon du vil vise

    private void Start()
    {
        indicator.SetActive(false);

        // Lytt på objective-oppdateringer
        ObjectiveManager.Instance.OnObjectivesUpdated += CheckObjectives;

        // Sjekk ved start
        CheckObjectives();
    }

    private void CheckObjectives()
    {
        // Hvis alle objectives er fullført → vis indicator
        bool allDone = true;

        foreach (var obj in ObjectiveManager.Instance.activeObjectives)
        {
            if (!obj.completed)
            {
                allDone = false;
                break;
            }
        }

        indicator.SetActive(allDone);
    }
}
