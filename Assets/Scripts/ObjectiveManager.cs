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

    [Header("Alle objectives i spillet")]
    public List<Objective> predefinedObjectives = new List<Objective>();

    [Header("Objectives spilleren faktisk har fått")]
    public List<Objective> activeObjectives = new List<Objective>();

    public delegate void ObjectivesUpdated();
    public event ObjectivesUpdated OnObjectivesUpdated;

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

    public void ActivateObjective(int index)
    {
        if (index < 0 || index >= predefinedObjectives.Count)
        {
            Debug.LogWarning("Objective index er utenfor range!");
            return;
        }

        // Ikke aktiver samme objective to ganger
        if (activeObjectives.Count > index && activeObjectives[index] != null)
            return;

        // Lag en NY instans av objective
        Objective newObj = new Objective
        {
            text = predefinedObjectives[index].text,
            completed = false
        };

        activeObjectives.Add(newObj);
        OnObjectivesUpdated?.Invoke();
    }


    public void CompleteObjective(int index)
    {
        if (index < 0 || index >= activeObjectives.Count)
        {
            Debug.LogWarning("Objective index er utenfor range!");
            //return;
        }

        // Marker active objective som fullført
        activeObjectives[index].completed = true;

        // Marker det tilsvarende predefined objective som fullført
        predefinedObjectives[index].completed = true;
        //Debug.Log(activeObjectives.IndexOf(predefinedObjectives[index]));
        //activeObjectives[activeObjectives.IndexOf(predefinedObjectives[index])].completed = true;

        OnObjectivesUpdated?.Invoke();
    }


    // lar triggers sjekke om forrige objective er ferdig
    public bool IsCompleted(int index)
    {
        if (index < 0 || index >= predefinedObjectives.Count)
            return false;

        return predefinedObjectives[index].completed;
    }
}
