using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] private int finalObjectiveIndex;

    private void Start()
    {
        if (ObjectiveManager.Instance != null)
        {
            ObjectiveManager.Instance.OnObjectivesUpdated += CheckObjectives;
        }
    }

    private void OnDestroy()
    {
        if (ObjectiveManager.Instance != null)
        {
            ObjectiveManager.Instance.OnObjectivesUpdated -= CheckObjectives;
        }
    }

    private void CheckObjectives()
    {
        if (ObjectiveManager.Instance.IsCompleted(finalObjectiveIndex))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}