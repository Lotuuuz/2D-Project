using UnityEngine;

public class ObjectiveMenuUI : MonoBehaviour
{
    public Transform objectiveListParent;
    public GameObject objectiveItemPrefab;

    private void OnEnable()
    {
        if (ObjectiveManager.Instance != null)
        {
            UpdateUI();
            ObjectiveManager.Instance.OnObjectivesUpdated += UpdateUI;
        }
    }

    private void OnDisable()
    {
        if (ObjectiveManager.Instance != null)
            ObjectiveManager.Instance.OnObjectivesUpdated -= UpdateUI;
    }

    private void UpdateUI()
    {
        // fjern gamle items
        foreach (Transform child in objectiveListParent)
            Destroy(child.gameObject);

        // hvis ingen objectives er aktive → stopp her
        if (ObjectiveManager.Instance.activeObjectives.Count == 0)
            return;

        // lag nye items
        foreach (var obj in ObjectiveManager.Instance.activeObjectives)
        {
            var item = Instantiate(objectiveItemPrefab, objectiveListParent);

            // RIKTIG METODE:
            item.GetComponent<ObjectiveItem>().SetObjective(obj);
        }
    }
}
