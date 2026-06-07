using UnityEngine;

public class SceneObjectiveActivator : MonoBehaviour
{
    public int[] objectivesToActivate;

    void Start()
    {
        foreach (int index in objectivesToActivate)
        {
            ObjectiveManager.Instance.ActivateObjective(index);
        }
    }
}
