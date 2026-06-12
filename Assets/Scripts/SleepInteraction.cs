using UnityEngine;
using UnityEngine.SceneManagement;

public class SleepInteraction : MonoBehaviour
{
    public GameObject indicator; // vises når alle objectives er ferdige

    private void Start()
    {
        indicator.SetActive(false);
        ObjectiveManager.Instance.OnObjectivesUpdated += CheckObjectives;
        CheckObjectives();
    }

    private void CheckObjectives()
    {
        indicator.SetActive(AllObjectivesCompleted());
    }

    private bool AllObjectivesCompleted()
    {
        foreach (var obj in ObjectiveManager.Instance.activeObjectives)
        {
            if (!obj.completed)
                return false;
        }
        return true;
    }

    public void TrySleep()
    {
        // Night 3 → ingen soving
        if (GameProgressManager.Instance.currentDay == 3 && GameProgressManager.Instance.isNight)
        {
            Debug.Log("Night 3: Spilleren skal ta et valg, ikke sove.");
            return;
        }

        if (!AllObjectivesCompleted())
        {
            Debug.Log("Du kan ikke sove ennå. Fullfør alle objectives først.");
            return;
        }

        string nextScene = SceneFlowManager.Instance.GetNextScene();

        if (string.IsNullOrEmpty(nextScene))
        {
            Debug.Log("Ingen neste scene definert.");
            return;
        }

        SceneManager.LoadScene(nextScene);
    }
}
