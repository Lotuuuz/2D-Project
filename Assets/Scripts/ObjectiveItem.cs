using TMPro;
using UnityEngine;

public class ObjectiveItem : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetObjective(ObjectiveManager.Objective obj)
    {
        string objective = obj.text;
        string processedText = objective;

        // Gå gjennom Family Colors-listen
        foreach (var pair in ObjectiveManager.Instance.familyColors)
        {
            // Sjekk om navnet finnes i objective-teksten
            if (!string.IsNullOrEmpty(pair.name) && objective.Contains(pair.name))
            {
                string hex = ColorUtility.ToHtmlStringRGB(pair.color);
                string coloredName = $"<color=#{hex}>{pair.name}</color>";

                // Bytt ut kun navnet, ikke resten
                processedText = objective.Replace(pair.name, coloredName);
                break;
            }
        }

        // Completed styling
        if (obj.completed)
        {
            text.text = $"<s>{processedText}</s>";
            text.color = Color.gray;
        }
        else
        {
            text.text = processedText;
            text.color = Color.black; 
        }
    }
}

