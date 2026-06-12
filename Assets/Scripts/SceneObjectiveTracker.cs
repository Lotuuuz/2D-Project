using UnityEngine;

public class SceneObjectiveTracker : MonoBehaviour
{
    public int totalObjectives;   // Hvor mange objectives denne scenen har
    public int completed;         // Hvor mange som er ferdige

    public static SceneObjectiveTracker Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void CompleteOne()
    {
        completed++;
        Debug.Log("Scene objectives completed: " + completed + "/" + totalObjectives);
    }

    public bool AllCompleted()
    {
        return completed >= totalObjectives;
    }
}
