
using TMPro;
using UnityEngine;

public class ObjectiveItem : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetText(string objective, bool completed)
    {
        Debug.Log("Completed status: " + completed);

        if (completed)
        {
            text.text = $"<s>{objective}</s>";
            text.color = Color.gray;
        }
        else
        {
            text.text = objective;
            text.color = Color.black;
        }
    }
}
