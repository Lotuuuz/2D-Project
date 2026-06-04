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
        foreach (Transform child in objectiveListParent)
            Destroy(child.gameObject);

        foreach (var obj in ObjectiveManager.Instance.activeObjectives)
        {
            var item = Instantiate(objectiveItemPrefab, objectiveListParent);
            item.GetComponent<ObjectiveItem>().SetText(obj.text, obj.completed);
        }
    }
}
