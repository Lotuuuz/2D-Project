using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;

    [System.Serializable]
    public class Objective
    {
        public string text;
        public bool completed;
    }

    [Header("Alle objectives du skriver inn i Inspector")]
    public List<Objective> predefinedObjectives = new List<Objective>();

    [Header("Objectives spilleren faktisk har fått")]
    public List<Objective> activeObjectives = new List<Objective>();

    public delegate void ObjectivesUpdated();
    public event ObjectivesUpdated OnObjectivesUpdated;

    private void Awake()
    {
        Instance = this;
    }
   
    public void ActivateObjective(int index)
    {
        if (index < 0 || index >= predefinedObjectives.Count)
        {
            Debug.LogWarning("Objective index er utenfor range!");
            return;
        }

        activeObjectives.Add(predefinedObjectives[index]);
        OnObjectivesUpdated?.Invoke();
    }

    public void CompleteObjective(int index)
    {
        if (index < 0 || index >= activeObjectives.Count)
        {
            Debug.LogWarning("Objective index er utenfor range!");
            return;
        }

        activeObjectives[index].completed = true;
        OnObjectivesUpdated?.Invoke();
    }
}
